using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.Repositories.Repositories;
using BLL.ViewModels;

namespace BLL.Services;

public class ProductionUnitService : IProductionUnitService
{
    public ProductionUnitService(ApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _productionUnitRepository = new ProductionUnitRepository(applicationDbContext);
        _mapper = mapper;
    }

    private readonly IProductionUnitRepository _productionUnitRepository;

    private readonly IMapper _mapper;

    public async Task<List<StatisticViewModel>> GetByDate(DateTime date)
    {
        var statistics = await _productionUnitRepository.GetStatisticByDateAsync(date);
        return _mapper.Map<List<ProductionUnit>, List<StatisticViewModel>>(statistics);
    }

    public async Task<ProductionUnit> AddStartStatistic(CreateStatisticViewModel statisticDto)
    {
        var startStatistic = _mapper.Map<CreateStatisticViewModel, ProductionUnit>(statisticDto);
        startStatistic.Date = DateTime.Now;
        var createdStat = await _productionUnitRepository.AddStartStatisticAsync(startStatistic);
        await _productionUnitRepository.Save();
        return createdStat;
    }

    public async Task<StatisticViewModel> GetByNameAndDate(DateTime date, long beerMarkId)
    {
        var stat = await _productionUnitRepository.GetByDateAndMarkAsync(date, beerMarkId);
        return _mapper.Map<ProductionUnit, StatisticViewModel>(stat);
    }

    public async Task<StatisticViewModel> AddFinalStatistic(FinalStatisticViewModel statistic)
    {
        var startStat = await _productionUnitRepository.GetByDateAndMarkAsync(DateTime.Now, statistic.BeerMarkId);
        startStat.Produced = statistic.Produced;
        startStat.State = 0;
        var updatedStat = await _productionUnitRepository.UpdateStatisticAsync(startStat);
        await _productionUnitRepository.Save();
        return _mapper.Map<ProductionUnit, StatisticViewModel>(updatedStat);
    }

    public async Task<List<ProductionUnitViewModel>> GetUnapprovedUnits(DateTime date)
    {
        var units = await _productionUnitRepository.GetUnapprovedUnitsByDateAsync(date);
        return _mapper.Map<List<ProductionUnit>, List<ProductionUnitViewModel>>(units);
    }

    public async Task<ProductionUnitViewModel> ApproveProductionUnit(long id)
    {
        var unapprovedUnit = await _productionUnitRepository.GetByIdAsync(id);
        if (unapprovedUnit.State == null) throw new Exception("Can't approve unit without production statistic");
        var approvedUnit = await _productionUnitRepository.ApproveProductionUnitAsync(unapprovedUnit);
        await _productionUnitRepository.Save();
        return _mapper.Map<ProductionUnit, ProductionUnitViewModel>(approvedUnit);
    }
}