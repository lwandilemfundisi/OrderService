using AutoMapper;
using OrderService.Api.Models;
using OrderService.Domain.DomainModel.OrderDomainModel;
using System;

namespace OrderService.Api.Profiles
{
    public class OrderProfiles
         : Profile
    {
        public OrderProfiles()
        {
            CreateMap<Order, OrderDtoModel>().ReverseMap();
            CreateMap<DateTime, string>().ConvertUsing(dt => dt.ToUniversalTime().ToString("yyyy-MM-dd"));
        }
    }
}
