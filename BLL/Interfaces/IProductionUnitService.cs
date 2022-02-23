using DAL.Entities;
using BLL.ViewModels;

namespace BLL.Interfaces;

public interface IProductionUnitService
{
    Task<List<StatisticViewModel>> GetByDate(DateTime date);

    Task<ProductionUnit> AddStartStatistic(CreateStatisticViewModel statisticDto);

    Task<StatisticViewModel> GetByNameAndDate(DateTime date, long beerMarkId);

    Task<StatisticViewModel> AddFinalStatistic(FinalStatisticViewModel statistic);

    Task<List<ProductionUnitViewModel>> GetUnapprovedUnits(DateTime date);

    Task<ProductionUnitViewModel> ApproveProductionUnit(long id);
}