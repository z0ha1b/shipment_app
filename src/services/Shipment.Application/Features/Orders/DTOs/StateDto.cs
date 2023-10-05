namespace Shipment.Application.Features.Orders.DTOs;

public class StateDto
{
    public string? Abbr { get; set; }
    public string? StateName { get; set; }
    public long CountryId { get; set; }

    public long Id { get; set; }
}