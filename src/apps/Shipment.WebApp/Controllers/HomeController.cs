using System.Diagnostics;
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

    public IActionResult Index()
    {
        var order = new OrderModel();
        return View(order);
    }

    [HttpPost]
    public async Task<IActionResult> Index(OrderModel order)
    {
        var orderDto = _mapper.Map<CreateOrderDto>(order);
        var command = new CreateOrderCommand
        {
            CreateOrderDto = orderDto
        };

        await _mediator.Send(command);

        return Ok("Form is Saved");
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