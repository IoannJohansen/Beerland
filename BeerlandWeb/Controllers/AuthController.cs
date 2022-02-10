using BLL.ViewModels;
using DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeerlandWeb.Controllers;

[Route("auth")]
public class AuthController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public AuthController(UserManager<AppUser> userManager)
    {
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
        var user = await _userManager.FindByNameAsync(loginRequestVm.Login);
        var authresult = await _userManager.CheckPasswordAsync(user, loginRequestVm.Password);
        return new LoginResponseViewModel
        {
            Success = authresult
        };
    }
    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet]
    [Route("test")]
    public string Test()
    {
        return "Test";
    }
}