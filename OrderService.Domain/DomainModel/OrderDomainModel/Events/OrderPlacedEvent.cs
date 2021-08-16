using Microservice.Framework.Domain.Events;
using Microservice.Framework.Domain.Events.AggregateEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.DomainModel.OrderDomainModel.Events
{
    [EventVersion("OrderPlacedEvent", 1)]
    public class OrderPlacedEvent : AggregateEvent<Order, OrderId>
    {
        public OrderPlacedEvent(
            string userId, 
            int orderTotal, 
            DateTime orderPlaced)
        {
            UserId = userId;
            OrderTotal = orderTotal;
            OrderPlaced = orderPlaced;
        }

        public string UserId { get; }
        public int OrderTotal { get; }
        public DateTime OrderPlaced { get; }
    }
}
