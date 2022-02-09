using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeerlandWeb.Core;

public class CustomUserPasswordStore : IUserPasswordStore<AppUser>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public CustomUserPasswordStore(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    public void Dispose() => _applicationDbContext.Dispose();

    public async Task<string?> GetUserIdAsync(AppUser user, CancellationToken cancellationToken) => await Task.Run(()=>
    {
        return _applicationDbContext.Users.FirstOrDefault(t => t.Id == user.Id)?.Id.ToString();
    }, cancellationToken);

    public async Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken)
    {
        return await Task.FromResult(user.UserName);
    }

    public async Task SetUserNameAsync(AppUser user, string userName, CancellationToken cancellationToken) =>
        await Task.Run(
            () =>
            {
                user.UserName = userName;
                _applicationDbContext.Users.Update(user);
                _applicationDbContext.SaveChanges();
            }, cancellationToken);

    public Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.UserName.ToUpper());
    }

    public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public async Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken)
    {
        await _applicationDbContext.Users.AddAsync(user, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return IdentityResult.Success;
    }

    public async Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken) => await Task.Run(
        () =>
        {
            _applicationDbContext.Users.Update(user);
            return IdentityResult.Success;
        }, cancellationToken);

    public async Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken) => await Task.Run(
        () =>
        {
            _applicationDbContext.Users.Remove(user);
            return IdentityResult.Success;
        }, cancellationToken);

    public async Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Users.FirstOrDefaultAsync(t => t.Id.ToString() == userId, cancellationToken: cancellationToken);
    }

    public async Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Users.FirstOrDefaultAsync(t => t.UserName.ToUpper() == normalizedUserName, cancellationToken: cancellationToken);
    }

    public Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken)
    {
        user.PasswordHash = passwordHash;
        return Task.CompletedTask;
    }

    public Task<string> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.PasswordHash);
    }

    public Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
    }
}