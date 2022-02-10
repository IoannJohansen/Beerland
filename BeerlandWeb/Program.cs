using AutoMapper;
using BeerlandWeb.Config;
using BeerlandWeb.Core;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.Repositories.Repositories;
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
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();


builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 4;
    opt.Password.RequireDigit = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase = false;
    opt.User.RequireUniqueEmail = true;
    opt.User.AllowedUserNameCharacters = "abcçdefgðhýijklmnoöpqrsþtuüvwxyzABCÇDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
}).AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication()
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

