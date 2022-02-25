using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class ProductionHistoryService : IProductionHistoryService
{
    private readonly IProductionHistoryRepository _historyRepository;

    public ProductionHistoryService(IProductionHistoryRepository historyRepository)
    {
        _historyRepository = historyRepository;
    }

    public Task<List<ProductionHistory>> GetProductionHistoryAsync(long beerMarkId)
    {
        return _historyRepository.GetProductionHistoryAsync(beerMarkId);
    }

    public async Task<ProductionHistory> WriteHistory(long beerMarkId, DateTime date, double produced)
    {
        var previousVolume = await _historyRepository.GetPreviousVolumeByBeermarkAsync(beerMarkId);
        var historyOfUnit = new ProductionHistory
        {
            BeerMarkId = beerMarkId,
            ActualVolume = previousVolume + produced,
            Date = date
        };
        var writedHistory = await _historyRepository.AddHistoryAsync(historyOfUnit);
        await _historyRepository.SaveAsync();
        return writedHistory;
    }

    public async Task<double> GetActualValue(long beerMarkId)
    {
        return await _historyRepository.GetPreviousVolumeByBeermarkAsync(beerMarkId);
    }
}