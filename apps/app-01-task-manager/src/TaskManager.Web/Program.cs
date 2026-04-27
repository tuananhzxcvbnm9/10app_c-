using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using TaskManager.Web;
using TaskManager.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddScoped<ThemeState>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ToastService>();

var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "/api/app-01";
if (!apiBaseUrl.EndsWith("/", StringComparison.Ordinal))
{
    apiBaseUrl += "/";
}

var resolvedApiBaseUri = Uri.TryCreate(apiBaseUrl, UriKind.Absolute, out var absoluteApiBaseUri)
    ? absoluteApiBaseUri
    : new Uri(new Uri(builder.HostEnvironment.BaseAddress), apiBaseUrl);

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = resolvedApiBaseUri });
builder.Services.AddScoped<ApiClient>();

await builder.Build().RunAsync();
