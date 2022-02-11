using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Dispose()
    {
        _userRepository.Dispose();
    }

    public async Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
    {
        return await Task.FromResult(user.Id);
    }

    public async Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken)
    {
        return await Task.FromResult(user.UserName);
    }

    public Task SetUserNameAsync(AppUser user, string userName, CancellationToken cancellationToken)
    {
        user.UserName = userName;
        return Task.CompletedTask;
    }

    public async Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
    {
        return await Task.FromResult(user.UserName.ToUpper());
    }

    public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken)
    {
        user.UserName = normalizedName;
        return Task.CompletedTask;
    }

    public async Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken)
    {
        try
        {
            await _userRepository.CreateAsync(user, cancellationToken);
            return IdentityResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return IdentityResult.Failed();
        }
    }

    public async Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
    {
        try
        {
            await _userRepository.Update(user, cancellationToken);
            return IdentityResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return IdentityResult.Failed();
        }
    }

    public async Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
    {
        try
        {
            await _userRepository.Delete(user, cancellationToken);
            return IdentityResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return IdentityResult.Failed();
        }
    }

    public async Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        return await _userRepository.FindByIdAsync(userId, cancellationToken);
    }

    public async Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        return await _userRepository.FindByNameAsync(normalizedUserName, cancellationToken);
    }

    public Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken)
    {
        user.PasswordHash = passwordHash;
        return Task.CompletedTask;
    }

    public async Task<string> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken)
    {
        return await Task.FromResult(user.PasswordHash);
    }

    public async Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken)
    {
        return await Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
    }
}