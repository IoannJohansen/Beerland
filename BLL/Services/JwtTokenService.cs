using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BLL.Services;

public class JwtTokenService : IJwtTokenService<AppUser>
{
    private readonly IConfiguration _configuration;

    public JwtTokenService(IConfiguration configuration, UserManager<AppUser> userManager)
    {
        _configuration = configuration;
        UserManager = userManager;
    }

    public UserManager<AppUser> UserManager { get; }
    
    public async Task<JwtSecurityToken> GenerateJwtToken(AppUser user)
    {
        var role = await UserManager.GetRolesAsync(user);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtOptions:SecretKey"])), 
            SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>()
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Role, role[0]),
        };
        return new JwtSecurityToken(_configuration["JwtOptions:Issuer"], _configuration["JwtOptions:Audience"], claims, DateTime.Now, DateTime.Now.AddHours(2), credentials);
    }
}