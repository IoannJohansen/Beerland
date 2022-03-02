using System.Text;
using AutoMapper;
using BeerlandWeb.Config;
using BeerlandWeb.Core;
using BeerlandWeb.Core.Middleware;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.Repositories.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Web;


try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    builder.Services.AddControllersWithViews();

    var connectionString = builder.Configuration.GetConnectionString("default");

    var mapperConfiguration = new MapperConfiguration(opt => { opt.AddProfile(new MappingProfile()); });
    var mapper = mapperConfiguration.CreateMapper();

    builder.Services.AddDbContext<ApplicationDbContext>(t =>
    {
        t.EnableSensitiveDataLogging();
        t.UseSqlite(connectionString);
    });

    builder.Services.AddSingleton(mapper);
    builder.Services.AddTransient<IUserPasswordStore<AppUser>, CustomUserPasswordStore>();
    builder.Services.AddTransient<IUserRepository, UserRepository>();
    builder.Services.AddTransient<IProductionHistoryRepository, ProductionHistoryRepository>();
    builder.Services.AddTransient<IBeerMarkRepository, BeerMarkRepository>();

    builder.Services.AddTransient<IProductionUnitService, ProductionUnitService>();
    builder.Services.AddTransient<IUserService, UserService>();
    builder.Services.AddTransient<IJwtTokenService<AppUser>, JwtTokenService>();
    builder.Services.AddTransient<IProductionHistoryService, ProductionHistoryService>();
    builder.Services.AddTransient<IBeerMarkService, BeerMarkService>();


    builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

    builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SecretKey"])),
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuer = false
            };
        });

    var app = builder.Build();
    app.UseMiddleware<ExceptionMiddleware>();
    if (!app.Environment.IsDevelopment()) app.UseHsts();

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        "default",
        "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
finally
{
    LogManager.Shutdown();
}