using AutoMapper;
using Shipment.Application.Features.Orders.DTOs;
using Shipment.Core.Entities;

namespace Shipment.Application.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        //Mapping AddressDto to Address
        CreateMap<AddressDto, Address>();
        // Mapping OrderDto to order
        CreateMap<CreateOrderDto, Order>()
            .ForMember(dto => dto.BillTo, 
                opt => opt.MapFrom(model => model.BillTo))
            .ForMember(dto => dto.ShipTo, 
                opt => opt.MapFrom(model => model.ShipTo));
        // Mapping BillingInfoDto to BillingInfo
        CreateMap<BillingInfoDto, BillingInfo>();
        CreateMap<CountryDto, Country>();
        CreateMap<Country, CountryDto>();
        CreateMap<State, StateDto>();
    }
}