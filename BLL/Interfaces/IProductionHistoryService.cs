using DAL.Entities;

namespace BLL.Interfaces;

public interface IProductionHistoryService
{
    Task<List<ProductionHistory>> GetProductionHistoryAsync(long beerMarkId);

    Task<ProductionHistory> WriteHistory(long beerMarkId, DateTime date, double produced);

    Task<double> GetActualValue(long beerMarkId);
}