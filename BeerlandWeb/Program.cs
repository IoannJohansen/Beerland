using AutoMapper;
using Beerland_server.Mapper;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console());
    
builder.Services.AddControllersWithViews();

var mapperConfiguration = new MapperConfiguration(opt =>
{
    opt.AddProfile(new MappingProfile());
});
var mapper = mapperConfiguration.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton<ApplicationDbContext>();
builder.Services.AddTransient<IStatisticService, StatisticService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Statistic}/{action=Index}/{id?}");

app.Run();