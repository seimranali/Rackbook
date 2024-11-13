using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.EntityFrameworkCore;
using Rackbook.Application;
using Rackbook.Infrastructure;
using Rackbook.WebUI.Components;
using Rackbook.WebUI.Services;
using Radzen;
using Newtonsoft;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents(options =>
    options.DetailedErrors = true)//builder.Environment.IsDevelopment())
    .AddInteractiveServerComponents()
    .AddCircuitOptions(options =>
    {
        options.DetailedErrors = true;
    }).AddHubOptions(options =>
    {
        options.EnableDetailedErrors = true;
        options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
        options.HandshakeTimeout = TimeSpan.FromSeconds(30);
        options.MaximumReceiveMessageSize = 10 * 1024 * 1024;
        options.StreamBufferCapacity = 10;

    });


builder.Services.AddRadzenComponents();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddLogging();

builder.Services.AddIdleCircuitHandler(options =>
    options.IdleTimeout = TimeSpan.FromSeconds(5));

builder.Services.AddScoped<CircuitHandler, TrackingCircuitHandler>();



builder.Services.AddDbContext<DbContext,AppDbContext>(config =>
{

    config.UseSqlServer(builder.Configuration?.GetConnectionString("ConStr")?.ToString());

}, ServiceLifetime.Scoped, ServiceLifetime.Scoped);

builder.Services.AddApplicationService();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CustomAuthenticationEvent>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(config =>
{

    config.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
    config.Cookie.HttpOnly = true;
    config.Cookie.SameSite = SameSiteMode.Lax;
    config.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    config.LoginPath = "/Login";
    config.LogoutPath = "/Logout";
    config.AccessDeniedPath = "/NotFound";
    config.ExpireTimeSpan = TimeSpan.FromDays(30);
    config.SlidingExpiration = true;
    config.EventsType = typeof(CustomAuthenticationEvent);


});

builder.Services.AddAuthenticationCore();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseStatusCodePagesWithRedirects("/Error");

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();
