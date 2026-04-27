using System.Threading.RateLimiting;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Blog.Api.Middleware;
using Blog.Application.Abstractions;
using Blog.Infrastructure.Persistence;
using Blog.Infrastructure.Repositories;
using Blog.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, cfg) => cfg
    .ReadFrom.Configuration(ctx.Configuration)
    .Enrich.WithProperty("Application", "Blog.Api")
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
builder.Services.AddScoped<IPostRepository, PostRepository>();
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

static async Task<IResult> GetAll(IPostRepository repo, CancellationToken ct)
    => Results.Ok(await repo.GetAllAsync(ct));

static async Task<IResult> CreateItem(string name, IPostRepository repo, HttpContext httpContext, CancellationToken ct)
{
    var item = await repo.AddAsync(new Blog.Domain.Entities.Post { Name = name }, ct);
    var correlationId = httpContext.TraceIdentifier;
    httpContext.Response.Headers[CorrelationIdMiddleware.HeaderName] = correlationId;
    return Results.Created($"/posts/{item.Id}", item);
}

v1.MapGet("/posts", GetAll);
v1.MapPost("/posts", CreateItem);
legacy.MapGet("/posts", GetAll);
legacy.MapPost("/posts", CreateItem);

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
