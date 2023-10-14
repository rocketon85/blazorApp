using blazorApp;
using blazorApp.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.ConfigureServices();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7213/") });
//StartUp.addHubConnection();

await builder.Build().RunAsync();
