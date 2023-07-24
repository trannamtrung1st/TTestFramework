using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TTestFramework.Shared.Clients;
using TTestFramework.WebClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAntDesign();
builder.Services.AddSingleton<IProductClient, ProductClient>();

string apiUrl = builder.Configuration["ApiUrl"];
builder.Services.AddHttpClient(nameof(IProductClient), (provider, opt) =>
{
    opt.BaseAddress = new Uri(apiUrl, UriKind.Absolute);
});

await builder.Build().RunAsync();
