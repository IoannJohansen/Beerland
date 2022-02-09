using AutoMapper;
using BeerlandWeb.Config;
using BeerlandWeb.Core;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console());

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("default");

var mapperConfiguration = new MapperConfiguration(opt =>
{
    opt.AddProfile(new MappingProfile());
});
var mapper = mapperConfiguration.CreateMapper();

builder.Services.AddDbContext<ApplicationDbContext>(t =>
{
    t.UseSqlite(connectionString);
});

builder.Services.AddSingleton(mapper);    
builder.Services.AddTransient<IStatisticService, StatisticService>();
builder.Services.AddTransient<IUserPasswordStore<AppUser>, CustomUserPasswordStore>();

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 3;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<AppUser>()
    .AddInMemoryClients(IdentityServerConfig.Clients)
    .AddInMemoryApiResources(IdentityServerConfig.ApiResources)
    .AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
    .AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources)
    .AddProfileService<ProfileService>()
    .AddDeveloperSigningCredential();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.Authority = "https://localhost:7169";
        options.Audience = "BeerlandApi";
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

