using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using BLL.Interfaces;
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
    private readonly IJwtTokenService<AppUser> _jwtTokenService;

    public AuthController(UserManager<AppUser> userManager, IJwtTokenService<AppUser> jwtTokenService)
    {
        _userManager = userManager;
        _jwtTokenService = jwtTokenService;
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
        if (!await _userManager.CheckPasswordAsync(user, loginRequestVm.Password))
        {
            throw new AuthenticationException("Invalid login or password");
        }
        var token = await _jwtTokenService.GenerateJwtToken(user);
        return new LoginResponseViewModel
        {
            Access_token = new JwtSecurityTokenHandler().WriteToken(token)
        };
    }
    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Never")]
    [HttpGet]
    [Route("test")]
    public string Test()
    {
        #region Init users and data
        /*await _roleManager.CreateAsync(new IdentityRole("User"));
        await _roleManager.CreateAsync(new IdentityRole("Admin"));
        
        var test1 = new AppUser
        {
            UserName = "test1",
            Email = "test1@mail.com"
        };
        await _userManager.AddPasswordAsync(test1, "test1");
        await _userManager.CreateAsync(test1);
        await _userManager.AddToRoleAsync(test1, "User");
        
        var test2 = new AppUser
        {
            UserName = "test2",
            Email = "test2@mail.com"
        };
        await _userManager.AddPasswordAsync(test2, "test2");
        await _userManager.CreateAsync(test2);
        await _userManager.AddToRoleAsync(test2, "Admin");
        
        var test3 = new AppUser
        {
            UserName = "test3",
            Email = "test3@mail.com"
        };
        await _userManager.AddPasswordAsync(test3, "test3");
        await _userManager.CreateAsync(test3);
        await _userManager.AddToRoleAsync(test3, "User");*/
        #endregion
        return "Test";
    }
}