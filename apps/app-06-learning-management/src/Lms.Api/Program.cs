using System.Threading.RateLimiting;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Lms.Api.Middleware;
using Lms.Application.Abstractions;
using Lms.Infrastructure.Persistence;
using Lms.Infrastructure.Repositories;
using Lms.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, cfg) => cfg
    .ReadFrom.Configuration(ctx.Configuration)
    .Enrich.WithProperty("Application", "Lms.Api")
    .Enrich.WithProperty("Environment", builder.Environment.EnvironmentName)
    .WriteTo.Console(new Serilog.Formatting.Compact.RenderedCompactJsonFormatter()));

builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: context.Connection.RemoteIpAddress?.ToString() ?? "global",
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 120,
                Window = TimeSpan.FromMinutes(1),
                QueueLimit = 20,
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst
            }));
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Missing DB connection string.");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddHealthChecks().AddNpgSql(connectionString);

var allowedOrigins = builder.Configuration["Cors:AllowedOrigins"]?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries) ?? ["http://localhost"];
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCors", policy => policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

app.UseExceptionHandler();
app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<RequestAuditMiddleware>();
app.UseSerilogRequestLogging();
app.UseCors("DefaultCors");
app.UseRateLimiter();
app.UseSwagger();
app.UseSwaggerUI();
app.MapHealthChecks("/health");
app.MapMetrics();

var v1 = app.MapGroup("/api/v1");
var legacy = app.MapGroup(string.Empty);

static async Task<IResult> GetAll(ICourseRepository repo, CancellationToken ct)
    => Results.Ok(await repo.GetAllAsync(ct));

static async Task<IResult> CreateItem(string name, ICourseRepository repo, HttpContext httpContext, CancellationToken ct)
{
    var item = await repo.AddAsync(new Lms.Domain.Entities.Course { Name = name }, ct);
    var correlationId = httpContext.TraceIdentifier;
    httpContext.Response.Headers[CorrelationIdMiddleware.HeaderName] = correlationId;
    return Results.Created($"/courses/{item.Id}", item);
}

v1.MapGet("/courses", GetAll);
v1.MapPost("/courses", CreateItem);
legacy.MapGet("/courses", GetAll);
legacy.MapPost("/courses", CreateItem);

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var applyOnStartup = app.Configuration.GetValue("Database:ApplyMigrationsOnStartup", app.Environment.IsDevelopment());
    if (applyOnStartup)
    {
        await db.Database.MigrateAsync();
        await DataSeeder.SeedAsync(db, CancellationToken.None);
    }
}

app.Run();
