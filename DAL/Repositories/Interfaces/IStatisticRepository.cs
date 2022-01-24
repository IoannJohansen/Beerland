using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IStatisticRepository
    {
        Task<List<ProductionStatistic>> GetStatisticByDateAsync(DateTime day);

        Task<ProductionStatistic> AddStartStatisticAsync(ProductionStatistic statistic);

        Task<ProductionStatistic> UpdateStatisticAsync(ProductionStatistic statistic);
        
        Task<ProductionStatistic> GetByDateAndMarkAsync(DateTime date, long beerMarkId);

        Task Save();
    }
}
