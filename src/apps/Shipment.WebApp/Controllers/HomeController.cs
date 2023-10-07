﻿using System.Diagnostics;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shipment.Application.Features.Orders.Commands;
using Shipment.Application.Features.Orders.DTOs;
using Shipment.Application.Services.Interfaces;
using Shipment.WebApp.Models;
using Shipment.WebApp.Models.LocationModels;

namespace Shipment.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILookupService _lookupService;

    public HomeController(ILogger<HomeController> logger, IMediator mediator, IMapper mapper,
        ILookupService lookupService)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
        _lookupService = lookupService;
    }

    public IActionResult Index(bool success, string message)
    {
        var order = new OrderModel
        {
            Success = success,
            Message = message
        };

        return View(order);
    }

    [HttpPost]
    public async Task<IActionResult> Index(OrderModel order)
    {
        try
        {
            if (order.SameAsBillTo)
            {
                order.ShipTo = order.BillTo;
            }

            var orderDto = _mapper.Map<CreateOrderDto>(order);
            var command = new CreateOrderCommand
            {
                CreateOrderDto = orderDto
            };
            var orderId = await _mediator.Send(command);
            if (order.File != null)
            {
                var uploadFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadFiles");
                if (!Directory.Exists(uploadFolderPath))
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }
                var fileName = "TaxExemptFile_OrderNo_" + orderId.ToString() + Path.GetExtension(order.File.FileName);
                var filePath = Path.Combine(uploadFolderPath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await order.File.CopyToAsync(fileStream);
                }
            }

            order = new OrderModel
            {
                Success = true
            };
        }
        catch (Exception e)
        {
            order.Message = e.Message;
        }

        if (!order.Success)
        {
            return View(order);
        }

        return RedirectToAction("Index", new { success = order.Success, message = order.Message });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public async Task<IActionResult> GetStates(long countryId)
    {
        var statesDto = await _lookupService.ReadStates(countryId);
        IReadOnlyList<StateModel> shipToStates = _mapper.Map<List<StateModel>>(statesDto);
        return Ok(shipToStates);
    }
}