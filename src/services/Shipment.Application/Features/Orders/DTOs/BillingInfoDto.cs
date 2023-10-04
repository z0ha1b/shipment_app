using Shipment.Core.Entities;

namespace Shipment.Application.Features.Orders.DTOs;

public class BillingInfoDto : AddressDto
{
    public string? DbNumber { get; set; }
    public string? NatureOfBusiness { get; set; }
    public string? YearsInBusiness { get; set; }
}