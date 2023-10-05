using Shipment.Core.Common;

namespace Shipment.Core.Entities;

public class State : EntityBase
{
    public string? Abbr { get; set; }
    public string? StateName { get; set; }
    public long CountryId { get; set; }

}