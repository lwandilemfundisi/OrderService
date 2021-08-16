using Microservice.Framework.Domain.Events;
using Microservice.Framework.Domain.Events.AggregateEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.DomainModel.OrderDomainModel.Events
{
    [EventVersion("UpdatedOrderPaymentStatusEvent", 1)]
    public class UpdatedOrderPaymentStatusEvent : AggregateEvent<Order, OrderId>
    {
        public UpdatedOrderPaymentStatusEvent(bool orderPaid)
        {
            OrderPaid = orderPaid;
        }

        public bool OrderPaid { get; }
    }
}
