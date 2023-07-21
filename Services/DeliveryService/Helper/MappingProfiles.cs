using AutoMapper;
using Delivery.Dto;
using Delivery.Models;

namespace Delivery.Helper;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
    }
}