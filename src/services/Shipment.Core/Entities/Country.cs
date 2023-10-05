using System.ComponentModel.DataAnnotations;
using Shipment.Core.Common;

namespace Shipment.Core.Entities;

public class Country : EntityBase
{
    public string? Abbr { get; set; }
    public string? CountryName { get; set; }

}