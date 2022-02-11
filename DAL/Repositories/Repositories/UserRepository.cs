using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Save()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public async Task CreateAsync(AppUser user, CancellationToken cancellationToken)
    {
        await _dbContext.Users.AddAsync(user, cancellationToken);
    }

    public async Task Update(AppUser user, CancellationToken cancellationToken) => await Task.Run(() =>
    {
        _dbContext.Users.Update(user);
    }, cancellationToken);

    public async Task Delete(AppUser user, CancellationToken cancellationToken) => await Task.Run(() =>
    {
        _dbContext.Users.Remove(user);
    }, cancellationToken);

    public async Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(t => t.Id == userId, cancellationToken);
    }

    public async Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(t => t.UserName.ToUpper() == normalizedUserName, cancellationToken);
    }
    
    
}