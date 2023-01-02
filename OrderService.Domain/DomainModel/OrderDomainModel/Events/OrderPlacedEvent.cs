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
            string cardNumber,
            string cardName,
            string cardExpiration,
            decimal orderTotal, 
            DateTime orderPlaced)
        {
            UserId = userId;
            CardName = cardName;
            CardExpiration = cardExpiration;
            CardNumber = cardNumber;
            OrderTotal = orderTotal;
            OrderPlaced = orderPlaced;
        }

        public string UserId { get; }
        public string CardNumber { get; }
        public string CardName { get; }
        public string CardExpiration { get; }
        public decimal OrderTotal { get; }
        public DateTime OrderPlaced { get; }
    }
}
