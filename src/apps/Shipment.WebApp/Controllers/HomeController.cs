﻿using System.Diagnostics;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shipment.Application.Features.Orders.Commands;
using Shipment.Application.Features.Orders.DTOs;
using Shipment.WebApp.Models;
using Shipment.WebApp.Models.LocationModels;

namespace Shipment.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HomeController(ILogger<HomeController> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
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
            var orderDto = _mapper.Map<CreateOrderDto>(order);
            var command = new CreateOrderCommand
            {
                CreateOrderDto = orderDto
            };

            await _mediator.Send(command);
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
    public IActionResult GetStates(string countryId)
    {
        var states = StateModel.GetStates(countryId);
        return Ok(states);
    }
}