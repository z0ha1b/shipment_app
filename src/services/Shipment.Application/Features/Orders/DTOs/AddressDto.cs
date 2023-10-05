using Shipment.Core.Common;

namespace Shipment.Application.Features.Orders.DTOs;

public class AddressDto
{
    public string? CompanyName { get; set; }
    public string? Addr { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? Country { get; set; }
    public string? County { get; set; }
    public string? Phone { get; set; }
    public string? Contact { get; set; }
    public string? ContactEmail { get; set; }
}