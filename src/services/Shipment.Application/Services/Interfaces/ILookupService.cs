using Shipment.Application.Features.Orders.DTOs;

namespace Shipment.Application.Services.Interfaces;

public interface ILookupService
{
    public Task<IReadOnlyList<CountryDto>> ReadCountries();
    public Task<IReadOnlyList<StateDto>> ReadStates(long countryId);
}