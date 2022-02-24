﻿using AutoMapper;
using BLL.Interfaces;
using BLL.ViewModels;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BeerlandWeb.Controllers;

[Route("ProductionUnit")]
public class ProductionUnitController : Controller
{
    private readonly IProductionUnitService _productionUnitService;
    private readonly IProductionHistoryService _historyService;
    private readonly IMapper _mapper;

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
    [Route("getUnapprovedUnits")]
    public async Task<List<ProductionUnitViewModel>> GetUnapprovedUnits(DateTime date)
    {
        var unapprovedUnits = await _productionUnitService.GetUnapprovedUnits(date);
        if (unapprovedUnits.Count != 0) return unapprovedUnits;
        throw new Exception("Unapproved units for this date wasn't found");
    }

    [HttpGet]
    [Route("approveUnit")]
    public async Task<ProductionUnitViewModel> ApproveUnit(long unitId)
    {
        var approvedUnit = await _productionUnitService.ApproveProductionUnit(unitId);
        await _historyService.WriteHistory(approvedUnit.BeerMarkId, DateTime.Now, approvedUnit.Produced);
        return _mapper.Map<ProductionUnit, ProductionUnitViewModel>(approvedUnit);
    }
}