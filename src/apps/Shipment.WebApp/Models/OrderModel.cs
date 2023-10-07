namespace Shipment.WebApp.Models;

public class OrderModel
{
    public bool SameAsBillTo { get; set; }
    public IFormFile? File { get; set; }
    public bool Success { get; set; }
    public string? Message { get; set; }
    public BillingInfoModel? BillTo { get; set; } = new();
    public AddressModel? ShipTo { get; set; } = new();

    public string? TaxExempt { get; set; }
    public string? PurchaseOrderRequired { get; set; }
    public string? FieldOne { get; set; }
    public string? FieldTwo { get; set; }
    public string? FieldThree { get; set; }
    
    public class BillingInfoModel : AddressModel
    {
        public string? DbNumber { get; set; }
        public string? NatureOfBusiness { get; set; }
        public string? YearsInBusiness { get; set; }
    }
    
    public class AddressModel
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
}