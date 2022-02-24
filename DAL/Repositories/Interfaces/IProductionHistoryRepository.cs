using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IProductionHistoryRepository
{
    Task<List<ProductionHistory>> GetProductionHistoryAsync(long beerMarkId);

    Task<ProductionHistory> AddHistoryAsync(ProductionHistory history);

    Task<double> GetPreviousVolumeByBeermarkAsync(long beerMarkId);

    Task SaveAsync();
}