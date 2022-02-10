using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace DAL.Repositories.Interfaces;

public interface IUserRepository
{
    Task Save();

    void Dispose();

    Task CreateAsync(AppUser user, CancellationToken cancellationToken);

    Task Update(AppUser user, CancellationToken cancellationToken);

    Task Delete(AppUser user, CancellationToken cancellationToken);

    Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken);

    Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken);
    
    
}