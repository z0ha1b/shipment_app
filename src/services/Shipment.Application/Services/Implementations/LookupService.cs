using AutoMapper;
using Shipment.Application.Features.Orders.DTOs;
using Shipment.Application.Services.Interfaces;
using Shipment.Core.Repositories;

namespace Shipment.Application.Services.Implementations;

public class LookupService : ILookupService
{
    private readonly ICountryRepository _countryRepository;
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;

    public LookupService(ICountryRepository countryRepository, IStateRepository stateRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _stateRepository = stateRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<CountryDto>> ReadCountries()
    {
        try
        {
            var countries = await _countryRepository.GetAllAsync();

            IReadOnlyList<CountryDto> countriesList = _mapper.Map<List<CountryDto>>(countries);
            return countriesList;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error while getting countries" + e);
            throw;
        }
    }

    public async Task<IReadOnlyList<StateDto>> ReadStates(long countryId)
    {
        try
        {
            var states = await _stateRepository.GetStates(countryId);
            
            IReadOnlyList<StateDto> statesList = _mapper.Map<List<StateDto>>(states);
            return statesList;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error in State services " + e);
            throw;
        }
    }
}