using AutoMapper;
using BLL.Interfaces;
using BLL.ViewModels;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeerlandWeb.Controllers;

[Route("ProductionUnit")]
public class ProductionUnitController : Controller
{
    private readonly IProductionHistoryService _historyService;
    private readonly IMapper _mapper;
    private readonly IProductionUnitService _productionUnitService;

    public ProductionUnitController(IProductionUnitService productionUnitService,
        IProductionHistoryService historyService, IMapper mapper)
    {
        _productionUnitService = productionUnitService;
        _historyService = historyService;
        _mapper = mapper;
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
    [Authorize(Roles = "Manager, Supervisor")]
    [Route("getUnapprovedDays")]
    public async Task<List<int>> GetUnapprovedDays(DateTime date)
    {
        return await _productionUnitService.GetUnapprovedDays(date);
    }

    [HttpGet]
    [Authorize(Roles = "Manager, Supervisor")]
    [Route("getUnapprovedUnits")]
    public async Task<List<ProductionUnitViewModel>> GetUnapprovedUnits(DateTime date)
    {
        var unapprovedUnits = await _productionUnitService.GetUnapprovedUnits(date);
        if (unapprovedUnits.Count != 0) return unapprovedUnits;
        throw new Exception("Unapproved units for this date wasn't found");
    }

    [HttpGet]
    [Authorize(Roles = "Manager")]
    [Route("approveUnit")]
    public async Task<ProductionUnitViewModel> ApproveUnit(long unitId)
    {
        var approvedUnit = await _productionUnitService.ApproveProductionUnit(unitId);
        await _historyService.WriteHistory(approvedUnit.BeerMarkId, DateTime.Now, approvedUnit.Produced);
        return _mapper.Map<ProductionUnit, ProductionUnitViewModel>(approvedUnit);
    }
}