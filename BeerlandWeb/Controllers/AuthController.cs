using DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeerlandWeb.Controllers;

[Route("auth")]
public class AuthController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly UserManager<AppUser> _userManager;

    public AuthController(IHttpClientFactory clientFactory, UserManager<AppUser> userManager)
    {
        _clientFactory = clientFactory;
        _userManager = userManager;
    }
    
    [Route("index")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    #region Test methods
    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("authorized")]
    [HttpGet]
    public Task<string> Secured()
    {
        return Task.FromResult("Test");
    }
    
    [Authorize]
    [Route("unAuthorized")]
    [HttpGet]
    public Task<string> NotSecured()
    {
        return Task.FromResult("Test");
    }
    
    [Route("testAuth")]
    [HttpGet]
    public async Task<string> CreateUser()
    {
        var testU = new AppUser()
        {
            UserName = "bob1",
        };
        var addPassResult = await _userManager.AddPasswordAsync(testU, "bob");
        var result = await _userManager.CreateAsync(testU);
        return "true";
    }
    
    #endregion
}