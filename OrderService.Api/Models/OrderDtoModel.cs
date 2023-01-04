using OrderService.Domain.DomainModel.OrderDomainModel;
using System;

namespace OrderService.Api.Models
{
    public class OrderDtoModel
    {
        public OrderId Id { get; set; }
        public decimal OrderTotal { get; set; }
        public string OrderPlaced { get; set; }
        public bool OrderPaid { get; set; }
    }
}
