namespace Shipment.Core.Entities;

public class BillingInfo : Address
{
    public string? DbNumber { get; set; }
    public string? NatureOfBusiness { get; set; }
    public string? YearsInBusiness { get; set; }
}