using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;

namespace BLL.Interfaces;

public interface IJwtTokenService<T> where T : IdentityUser
{
    UserManager<T> UserManager { get; }
    
    Task<JwtSecurityToken> GenerateJwtToken(T user);

}