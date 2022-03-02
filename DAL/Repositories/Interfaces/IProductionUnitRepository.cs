using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IProductionUnitRepository
{
    Task<List<ProductionUnit>> GetStatisticByDateAsync(DateTime day);

    Task<ProductionUnit> AddStartStatisticAsync(ProductionUnit unit);

    Task<ProductionUnit> UpdateStatisticAsync(ProductionUnit unit);

    Task<ProductionUnit> GetByDateAndMarkAsync(DateTime date, long beerMarkId);

    Task<List<ProductionUnit>> GetUnapprovedUnitsByDateAsync(DateTime date);

    Task<ProductionUnit> ApproveProductionUnitAsync(ProductionUnit unit);

    Task<ProductionUnit> GetByUnitIdAsync(long unitId);

    Task<List<int>> GetUnapprovedDays(DateTime date);

    Task Save();
}