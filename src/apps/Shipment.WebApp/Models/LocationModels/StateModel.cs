using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HostingEnvironmentExtensions = Microsoft.Extensions.Hosting.HostingEnvironmentExtensions;

namespace Shipment.WebApp.Models.LocationModels;

public class StateModel
{
    public string Abbr { get; set; } = string.Empty;
    public string StateName { get; set; } = string.Empty;
    public long CountryId { get; set; }
    public long Id { get; set; }
}