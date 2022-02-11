using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BeerlandWeb.Core;

public class CustomUserPasswordStore : IUserPasswordStore<AppUser>
{
    private readonly IUserService _userService;

    public CustomUserPasswordStore(IUserService userService)
    {
        _userService = userService;
    }

    public void Dispose()
    {
        _userService.Dispose();
    }

    public async Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
    {
        return await _userService.GetUserIdAsync(user, cancellationToken);
    }

    public async Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken)
    {
        return await _userService.GetUserNameAsync(user, cancellationToken);
    }

    public async Task SetUserNameAsync(AppUser user, string userName, CancellationToken cancellationToken)
    {
        await _userService.SetUserNameAsync(user, userName, cancellationToken);
    }

    public async Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
    {
        return await _userService.GetNormalizedUserNameAsync(user, cancellationToken);
    }

    public async Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken)
    {
        await _userService.SetNormalizedUserNameAsync(user, normalizedName, cancellationToken);
    }

    public async Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken)
    {
        return await _userService.CreateAsync(user, cancellationToken);
    }

    public async Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
    {
        return await _userService.UpdateAsync(user, cancellationToken);
    }

    public async Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
    {
        return await _userService.DeleteAsync(user, cancellationToken);
    }

    public async Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        return await _userService.FindByIdAsync(userId, cancellationToken);
    }

    public async Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        return await _userService.FindByNameAsync(normalizedUserName, cancellationToken);
    }

    public async Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken)
    {
        await _userService.SetPasswordHashAsync(user, passwordHash, cancellationToken);
    }

    public async Task<string> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken)
    {
        return await _userService.GetPasswordHashAsync(user, cancellationToken);
    }

    public async Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken)
    {
        return await _userService.HasPasswordAsync(user, cancellationToken);
    }
}