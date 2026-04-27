using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Helpdesk.Web;
using Helpdesk.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddScoped<ThemeState>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ToastService>();

var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "/api/app-08";
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(apiBaseUrl, UriKind.RelativeOrAbsolute) });
builder.Services.AddScoped<ApiClient>();

await builder.Build().RunAsync();
