using BLL.Interfaces;
using BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeerlandWeb.Controllers;

[Route("ProductionUnit")]
public class ProductionUnitController : Controller
{
    private readonly IProductionUnitService _productionUnitService;

    public ProductionUnitController(IProductionUnitService productionUnitService)
    {
        _productionUnitService = productionUnitService;
    }

    [HttpGet]
    [Route("UnitApprovement")]
    public IActionResult UnitApprovement()
    {
        return View();
    }

    [HttpGet]
    [Route("UnitStorage")]
    public IActionResult UnitStorage()
    {
        return View();
    }

    [HttpGet]
    [Route("getUnapprovedUnits")]
    public async Task<List<ProductionUnitViewModel>> GetUnapprovedUnits(DateTime date)
    {
        var unapprovedUnits = await _productionUnitService.GetUnapprovedUnits(date);
        if (unapprovedUnits.Count != 0) return unapprovedUnits;
        throw new Exception("Unapproved units for this date wasn't found");
    }

    [HttpGet]
    [Route("approveUnit")]
    public async Task<ProductionUnitViewModel> ApproveUnit(long id)
    {
        return await _productionUnitService.ApproveProductionUnit(id);
    }
}