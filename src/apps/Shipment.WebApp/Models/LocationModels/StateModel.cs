using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HostingEnvironmentExtensions = Microsoft.Extensions.Hosting.HostingEnvironmentExtensions;

namespace Shipment.WebApp.Models.LocationModels;

public class StateModel
{
    public string Abbr { get; set; } = string.Empty;
    public string StateName { get; set; } = string.Empty;
    public string CountryId { get; set; } = string.Empty;

    /*public static List<StateModel> GetStates(string countryId)
    {
        // Hardcoded states for demonstration purposes
        var states = new List<StateModel>();

        states.Add(new StateModel { CountryId = "PK", Id = "PK-SINDH", StateName = "Sindh" });
        states.Add(new StateModel { CountryId = "PK", Id = "PK-PUNJAB", StateName = "Punjab" });
        states.Add(new StateModel { CountryId = "PK", Id = "PK-KP", StateName = "Khyber Pakhtunkhwa" });
        states.Add(new StateModel { CountryId = "IN", Id = "IN-MH", StateName = "Maharashtra" });
        states.Add(new StateModel { CountryId = "IN", Id = "IN-DL", StateName = "Delhi" });
        states.Add(new StateModel { CountryId = "IN", Id = "IN-TN", StateName = "Tamil Nadu" });

        if (!string.IsNullOrEmpty(countryId))
        {
            return states.Where(x => x.CountryId.Equals(countryId)).ToList();
        }

        return states;
    }*/
}