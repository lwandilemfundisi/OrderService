using Microservice.Framework.Domain.Commands;
using Microservice.Framework.Domain.Jobs;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Domain.DomainModel.OrderDomainModel.Commands;
using OrderService.Domain.ExternalServices.PaymentGateway;
using OrderService.Domain.ExternalServices.PaymentGateway.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Domain.DomainModel.OrderDomainModel.Jobs
{
    public class ConfirmPaymentJob
        : IJob
    {
        public ConfirmPaymentJob(
            OrderId orderId,
            string cardNumber, 
            string cardName, 
            string cardExpiration)
        {
            OrderId = orderId;
            CardNumber = cardNumber;
            CardName = cardName;
            CardExpiration = cardExpiration;
        }

        public OrderId OrderId { get; }
        public string CardNumber { get; }
        public string CardName { get; }
        public string CardExpiration { get; }

        public async Task ExecuteAsync(
            IServiceProvider serviceProvider, 
            CancellationToken cancellationToken)
        {
            var commandBus = serviceProvider.GetRequiredService<ICommandBus>();
            var paymentGateway = serviceProvider.GetRequiredService<IPaymentGateway>();

            var paymentResult = await paymentGateway.Pay(new CardInfoRequestModel
            {
                CardNumber = CardNumber,
                CardName = CardName,
                CardExpiration = CardExpiration
            }, cancellationToken);

            await commandBus.PublishAsync(
                new UpdateOrderPaymentStatusCommand(OrderId, paymentResult), 
                cancellationToken);
        }
    }
}
