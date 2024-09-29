using Backend.Services;
using Frontend.Client.Pages;
using Frontend.Components;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var url = builder.Configuration["BackendUrl"];
builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44337/api/") });
// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Frontend.Client._Imports).Assembly);

app.Run();