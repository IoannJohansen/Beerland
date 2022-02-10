using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Interfaces;

public interface IUserService
{
    void Dispose();

    Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken);

    Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken);

    Task SetUserNameAsync(AppUser user, string userName, CancellationToken cancellationToken);

    Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken);

    Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken);

    Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken);

    Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken);

    Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken);

    Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken);

    Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken);

    Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken);

    Task<string> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken);

    Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken);
}