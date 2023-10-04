using MediatR;
using Shipment.Application.Features.Orders.DTOs;

namespace Shipment.Application.Features.Orders.Commands;

public class CreateOrderCommand: IRequest<long>
{
    public CreateOrderDto? CreateOrderDto { get; set; }
}