using System.ComponentModel.DataAnnotations;

namespace Shipment.WebApp.Models.LocationModels;

public class CountryModel
{
    [Key] public string Id { get; set; } = string.Empty;
    public string CountryName { get; set; } = string.Empty;

    public static List<CountryModel> GetCountries()
    {
        return new List<CountryModel>
        {
            new CountryModel { Id = "PK", CountryName = "Pakistan" },
            new CountryModel { Id = "IN", CountryName = "India" },
            new CountryModel { Id = "US", CountryName = "United State America" },
            new CountryModel { Id = "UK", CountryName = "England" }
        };
    }
}