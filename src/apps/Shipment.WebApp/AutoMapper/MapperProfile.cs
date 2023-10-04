using AutoMapper;
using Shipment.Application.Features.Orders.DTOs;
using Shipment.WebApp.Models;

namespace Shipment.WebApp.AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<OrderModel.AddressModel, AddressDto>();
        CreateMap<OrderModel.BillingInfoModel, BillingInfoDto>();
        CreateMap<OrderModel, CreateOrderDto>()
            .ForMember(dto => dto.BillTo, opt => opt.MapFrom(model => model.BillTo))
            .ForMember(dto => dto.ShipTo, opt => opt.MapFrom(model => model.ShipTo));

    }
}