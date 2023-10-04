namespace Shipment.Core.Common;

public class EntityBase
{
    public long Id { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}