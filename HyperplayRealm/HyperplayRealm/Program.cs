using BLL.Configuration;
using BLL.Configuration.Model;
using BLL.DTOs;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services.Authentication;
using BLL.Services.Impl;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(config =>
{
    config.LoginPath = "/Users/Login"; //path of login
    config.AccessDeniedPath = "/Users/Login"; //bring back again if failed
    config.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    config.SlidingExpiration = true; //allows to continue even if the session expired
});

builder.Services.AddDbContext<HyperplayRealmDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddScoped<IDBOperations<User, UserDTO>, UsersServiceImpl>();
// App Settings
builder.Services.AddSingleton<IAppSettings, AppSettingsService>();
builder.Services.AddScoped<IAuthentication, AuthenticationServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Use online templates for login, etc

//use firebase or any other software for getting the pictures

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Authentication must come before authorization
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
