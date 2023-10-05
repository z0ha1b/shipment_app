using System.ComponentModel.DataAnnotations;
using Shipment.Core.Entities;
using Shipment.Core.Repositories;

namespace Shipment.WebApp.Models.LocationModels;

public class CountryModel
{
    public string Abbr { get; set; } = string.Empty;
    public string CountryName { get; set; } = string.Empty;
    public long Id { get; set; }
}