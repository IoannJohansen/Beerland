using BLL.Interfaces;
using BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeerlandWeb.Controllers
{
    [Route("statistic")]
    public class StatisticController : Controller
    {
        public StatisticController(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
        }
        
        private readonly IStatisticService statisticService;

        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        [Route("getStat")]
        public async Task<IActionResult> GetStatistic(DateTime date)
        {
            var statistic = await statisticService.GetByDate(date);
            if (statistic.Count == 0)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return StatusCode(StatusCodes.Status200OK, statistic);
        }

        [HttpPost]
        [Route("addStartStat")]
        public async Task<IActionResult> AddStartStatistic([FromBody] CreateStatisticViewModel createStatisticViewModel)
        {
            var createdStatistic =  await statisticService.AddStartStatistic(createStatisticViewModel);
            return StatusCode(StatusCodes.Status201Created, createdStatistic);
        }

        [HttpPost]
        [Route("addFinalStat")]
        public async Task<IActionResult> AddFinalStatistic([FromBody] FinalStatisticViewModel finalStatisticViewModel)
        {
            var updatedStatistic = await statisticService.AddFinalStatistic(finalStatisticViewModel);
            return StatusCode(StatusCodes.Status200OK, updatedStatistic);
        }
    }
}
