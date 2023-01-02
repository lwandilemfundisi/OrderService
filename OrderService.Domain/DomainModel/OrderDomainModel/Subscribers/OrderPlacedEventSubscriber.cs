using Microservice.Framework.Domain.Events;
using Microservice.Framework.Domain.Jobs;
using Microservice.Framework.Domain.Subscribers;
using OrderService.Domain.DomainModel.OrderDomainModel.Events;
using OrderService.Domain.DomainModel.OrderDomainModel.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Domain.DomainModel.OrderDomainModel.Subscribers
{
    public class OrderPlacedEventSubscriber
        : ISubscribeSynchronousTo<Order, OrderId, OrderPlacedEvent>
    {
        private readonly IJobScheduler _jobScheduler;

        public OrderPlacedEventSubscriber(
            IJobScheduler jobScheduler)
        {
            _jobScheduler = jobScheduler;
        }

        public Task HandleAsync(
            IDomainEvent<Order, OrderId, OrderPlacedEvent> domainEvent, 
            CancellationToken cancellationToken)
        {
            var job = new ConfirmPaymentJob(
                domainEvent.AggregateIdentity,
                domainEvent.AggregateEvent.CardNumber,
                domainEvent.AggregateEvent.CardName,
                domainEvent.AggregateEvent.CardExpiration);

            return _jobScheduler.ScheduleNowAsync(job, cancellationToken);
        }
    }
}
