using AutoMapper;
using OrderService.Api.Models;
using OrderService.Domain.DomainModel.OrderDomainModel;

namespace OrderService.Api.Profiles
{
    public class OrderProfiles
         : Profile
    {
        public OrderProfiles()
        {
            CreateMap<Order, OrderDtoModel>().ReverseMap();
        }
    }
}
