using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Repositories;

public class ProductionUnitRepository : IProductionUnitRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ProductionUnitRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<ProductionUnit>> GetStatisticByDateAsync(DateTime date)
    {
        return await _applicationDbContext.ProductionUnits.Where(t => t.Date.Date == date.Date).Include(t => t.BeerMark)
            .ToListAsync();
    }

    public async Task<ProductionUnit> AddStartStatisticAsync(ProductionUnit unit)
    {
        return (await _applicationDbContext.ProductionUnits.AddAsync(unit)).Entity;
    }

    public Task<List<ProductionUnit>> GetUnapprovedUnitsByDateAsync(DateTime date)
    {
        return _applicationDbContext.ProductionUnits.Include(t => t.BeerMark)
            .Where(t => t.Date.Date == date.Date && t.State == 0)
            .ToListAsync();
    }

    public async Task<ProductionUnit> GetByIdAsync(long id)
    {
        return (await _applicationDbContext.ProductionUnits.Include(t => t.BeerMark)
            .FirstOrDefaultAsync(t => t.Id == id))!;
    }

    public async Task Save()
    {
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task<ProductionUnit> GetByDateAndMarkAsync(DateTime date, long beerMarkId)
    {
        return (await _applicationDbContext.ProductionUnits
            .Where(t => t.Date.Date == date.Date && t.BeerMarkId == beerMarkId).FirstOrDefaultAsync())!;
    }

    public async Task<ProductionUnit> UpdateStatisticAsync(ProductionUnit unit)
    {
        return await Task.Run(() => _applicationDbContext.ProductionUnits.Update(unit).Entity);
    }

    public async Task<ProductionUnit> ApproveProductionUnitAsync(ProductionUnit unit)
    {
        unit.State = 1;
        return _applicationDbContext.ProductionUnits.Update(unit).Entity;
    }
}