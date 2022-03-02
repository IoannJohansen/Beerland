using BLL.Interfaces;
using BLL.ViewModels;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeerlandWeb.Controllers;

[Route("ProductionHistory")]
public class ProductionHistoryController : Controller
{
    private readonly IBeerMarkService _beerMarkService;
    private readonly IProductionHistoryService _productionHistoryService;

    public ProductionHistoryController(IBeerMarkService beerMarkService,
        IProductionHistoryService productionHistoryService)
    {
        _beerMarkService = beerMarkService;
        _productionHistoryService = productionHistoryService;
    }

    [HttpGet]
    [Authorize(Roles = "Supervisor, Manager")]
    [Route("getProdHistory")]
    public async Task<HistoryPageViewModel> GetProductionHistory(long beerMarkId)
    {
        var history = await _productionHistoryService.GetProductionHistoryAsync(beerMarkId);
        var actualValue = await _productionHistoryService.GetActualValue(beerMarkId);
        return new HistoryPageViewModel
        {
            History = history,
            ActualValue = actualValue
        };
    }

    [HttpGet]
    [Route("getBeermarks")]
    public async Task<List<BeerMarkViewModel>> GetBeerMarks()
    {
        return await _beerMarkService.GetBeerMarks();
    }
}