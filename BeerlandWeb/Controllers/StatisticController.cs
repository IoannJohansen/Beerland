using BLL.Interfaces;
using BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeerlandWeb.Controllers;

[Route("statistic")]
public class StatisticController : Controller
{
    public StatisticController(IStatisticService statisticService)
    {
        _statisticService = statisticService;
    }
        
    private readonly IStatisticService _statisticService;

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
        var statistic = await _statisticService.GetByDate(date);
        if (statistic.Count == 0)
        {
            throw new Exception("Statistic for this date wasn't added");
        }
        return Ok(statistic);
    }
    
    [HttpPost]
    [Route("addStartStat")]
    public async Task<IActionResult> AddStartStatistic([FromBody] CreateStatisticViewModel createStatisticViewModel)
    {
        var startStatistic = await _statisticService.GetByNameAndDate(DateTime.Now, createStatisticViewModel.BeerMarkId);
        if (startStatistic != null) throw new Exception("Statistic for this date and mark already exists");
        var createdStatistic =  await _statisticService.AddStartStatistic(createStatisticViewModel);
        return StatusCode(StatusCodes.Status201Created, createdStatistic);
    }

    [HttpPost]
    [Route("addFinalStat")]
    public async Task<IActionResult> AddFinalStatistic([FromBody] FinalStatisticViewModel finalStatisticViewModel)
    {
        var startStatistic = await _statisticService.GetByNameAndDate(DateTime.Now, finalStatisticViewModel.BeerMarkId);
        if (startStatistic == null) throw new Exception("Cant add final statistic because start statistic for this date and mark wasn't added");
        var updatedStatistic = await _statisticService.AddFinalStatistic(finalStatisticViewModel);
        return StatusCode(StatusCodes.Status200OK, updatedStatistic);
    }
}