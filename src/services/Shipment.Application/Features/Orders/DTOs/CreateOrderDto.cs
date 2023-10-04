using Shipment.Core.Common;
using Shipment.Core.Entities;

namespace Shipment.Application.Features.Orders.DTOs;

public class CreateOrderDto
{
    public BillingInfoDto? BillTo { get; set; }
    public AddressDto? ShipTo { get; set; }

    public string? TaxExempt { get; set; }
    public string? PurchaseOrderRequired { get; set; }
    public string? FieldOne { get; set; }
    public string? FieldTwo { get; set; }
    public string? FieldThree { get; set; }
}