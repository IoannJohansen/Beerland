using BLL.ViewModels;
using DAL.Entities;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeerlandWeb.Controllers;

[Route("auth")]
public class AuthController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly UserManager<AppUser> _userManager;

    public AuthController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
    {
        _httpClientFactory = httpClientFactory;
        _userManager = userManager;
    }
    
    [Route("index")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<LoginResponseViewModel> Login([FromBody]LoginRequestViewModel loginRequestVm)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var tokenResponse = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest()
        {
            Address = "https://localhost:7169/connect/token",
            UserName = loginRequestVm.Login,
            Password = loginRequestVm.Password,
            ClientId = "BeerlandClient",
        });
        return new LoginResponseViewModel
        {
            Success = !tokenResponse.IsError,
            Access_token = tokenResponse.AccessToken
        };
    }
}