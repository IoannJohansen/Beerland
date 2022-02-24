using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Repositories;

public class ProductionHistoryRepository : IProductionHistoryRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ProductionHistoryRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<List<ProductionHistory>> GetProductionHistoryAsync(long beerMarkId)
    {
        return _applicationDbContext.ProductionHistories.Include(t => t.Beermark)
            .Where(t => t.BeerMarkId == beerMarkId).ToListAsync();
    }

    public async Task<ProductionHistory> AddHistoryAsync(ProductionHistory history)
    {
        return await Task.Run(() => _applicationDbContext.ProductionHistories.Add(history).Entity);
    }

    public async Task<double> GetPreviousVolumeByBeermarkAsync(long beerMarkId)
    {
        return await Task.Run(() =>
        {
            var previousHistoryEntry =
                _applicationDbContext.ProductionHistories.OrderByDescending(t => t.Date).FirstOrDefault(t =>
                    t.BeerMarkId == beerMarkId);
            return previousHistoryEntry?.ActualVolume ?? 0;
        });
    }

    public async Task SaveAsync()
    {
        await _applicationDbContext.SaveChangesAsync();
    }
}