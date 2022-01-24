using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.Repositories.Repositories;
using BLL.ViewModels;

namespace BLL.Services
{
    public class StatisticService : IStatisticService
    {
        public StatisticService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            statisticRepository = new StatisticRepository(applicationDbContext);
            this.mapper = mapper;
        }

        private IStatisticRepository statisticRepository;

        private IMapper mapper;

        public async Task<List<StatisticViewModel>> GetByDate(DateTime date)
        {
            var statistics = await statisticRepository.GetStatisticByDateAsync(date);
            return mapper.Map<List<ProductionStatistic>, List<StatisticViewModel>>(statistics);
        }

        public async Task<ProductionStatistic> AddStartStatistic(CreateStatisticViewModel statisticDto)
        {
            var startStatistic = mapper.Map<CreateStatisticViewModel, ProductionStatistic>(statisticDto);
            startStatistic.Date = DateTime.Now;
            var createdStat = await statisticRepository.AddStartStatisticAsync(startStatistic);
            await statisticRepository.Save();
            return createdStat;
        }

        public async Task<StatisticViewModel> GetByNameAndDate(DateTime date, long beerMarkId)
        {
            var stat = await statisticRepository.GetByDateAndMarkAsync(date, beerMarkId);
            return mapper.Map<ProductionStatistic, StatisticViewModel>(stat);
        }

        public async Task<StatisticViewModel> AddFinalStatistic(FinalStatisticViewModel statistic)
        {
            var startStat = await statisticRepository.GetByDateAndMarkAsync(DateTime.Now, statistic.BeerMarkId);
            startStat.Produced = statistic.Produced;
            var updatedStat = await statisticRepository.UpdateStatisticAsync(startStat);
            await statisticRepository.Save();
            return mapper.Map<ProductionStatistic, StatisticViewModel>(updatedStat);
        }
    }
}