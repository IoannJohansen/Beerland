using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Repositories
{
    public class StatisticRepository : IStatisticRepository
    {
        public StatisticRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        private readonly ApplicationDbContext applicationDbContext;

        public async Task<List<ProductionStatistic>> GetStatisticByDateAsync(DateTime date)
        {
            return await applicationDbContext.ProductionStatictics.Where(t => t.Date.Date == date.Date).Include(t => t.BeerMark).ToListAsync();
        }

        public async Task<ProductionStatistic> AddStartStatisticAsync(ProductionStatistic statistic)
        {
            return (await applicationDbContext.ProductionStatictics.AddAsync(statistic)).Entity;
        }

        public async Task Save()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<ProductionStatistic> GetByDateAndMarkAsync(DateTime date, long beerMarkId)
        {
            return await applicationDbContext.ProductionStatictics.Where(t => t.Date.Date == date.Date && t.BeerMarkId == beerMarkId).FirstOrDefaultAsync();
        }

        public async Task<ProductionStatistic> UpdateStatisticAsync(ProductionStatistic statistic) => await Task.Run(() => applicationDbContext.ProductionStatictics.Update(statistic).Entity);
    }
}