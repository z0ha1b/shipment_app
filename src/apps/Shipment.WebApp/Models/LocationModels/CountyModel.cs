using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipment.WebApp.Models.LocationModels;

public class CountyModel
{
    public string Id { get; set; } = string.Empty;
    public string CountyName { get; set; } = string.Empty;
}