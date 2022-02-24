using BLL.Interfaces;
using DAL.Entities;
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
    [Route("getProdHistory")]
    public async Task<List<ProductionHistory>> GetProductionHistory(long beerMarkId)
    {
        return await _productionHistoryService.GetProductionHistoryAsync(beerMarkId);
    }

    [HttpGet]
    [Route("getBeermarks")]
    public async Task<List<BeerMarkViewModel>> GetBeerMarks()
    {
        return await _beerMarkService.GetBeerMarks();
    }
}