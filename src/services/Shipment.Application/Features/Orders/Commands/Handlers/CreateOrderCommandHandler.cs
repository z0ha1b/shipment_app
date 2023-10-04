using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Shipment.Core.Repositories;

namespace Shipment.Application.Features.Orders.Commands.Handlers;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, long>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateOrderCommandHandler> _logger;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<CreateOrderCommandHandler> logger)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.CreateOrderDto is null)
        {
            _logger.LogError("Order cannot be null.");
            //TODO: add custom exception
            throw new ValidationException("Null");
        }

        var order = _mapper.Map<Core.Entities.Order>(request.CreateOrderDto);
        var createdOrder = await _orderRepository.AddAsync(order);
        return createdOrder.Id;
    }
}