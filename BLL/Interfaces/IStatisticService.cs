using DAL.Entities;
using BLL.ViewModels;

namespace BLL.Interfaces
{
    public interface IStatisticService
    {
        Task<List<StatisticViewModel>> GetByDate(DateTime date);

        Task<ProductionStatistic> AddStartStatistic(CreateStatisticViewModel statisticDto);

        Task<StatisticViewModel> GetByNameAndDate(DateTime date, long beerMarkId);

        Task<StatisticViewModel> AddFinalStatistic(FinalStatisticViewModel statistic);
    }
}
