using Shipment.Core.Common;

namespace Shipment.Core.Entities;

public class Order : EntityBase
{
    public BillingInfo? BillTo { get; set; }
    public Address? ShipTo { get; set; }

    public string? TaxExempt { get; set; }
    public string? PurchaseOrderRequired { get; set; }
    public string? FieldOne { get; set; }
    public string? FieldTwo { get; set; }
    public string? FieldThree { get; set; }
}