using Microservice.Framework.Domain.Commands;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OrderService.Api.Messages;
using OrderService.Domain.DomainModel.OrderDomainModel;
using OrderService.Domain.DomainModel.OrderDomainModel.Commands;
using OrderService.Intergration.MessagingBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Api.Messaging
{
    public class AzServiceBusConsumer : IAzServiceBusConsumer
    {
        private readonly IReceiverClient checkoutMessageReceiverClient;
        private readonly IConfiguration _configuration;
        private readonly ICommandBus _commandBus;

        public AzServiceBusConsumer(
            IConfiguration configuration, 
            IMessageBus messageBus,
            ICommandBus commandBus)
        {
            _configuration = configuration;
            _commandBus = commandBus;

            checkoutMessageReceiverClient = new SubscriptionClient(
                _configuration["Azure:ServiceBusConnection"], 
                _configuration["Azure:CheckoutMessageTopic"],
                _configuration["Azure:SubscriptionName"]);
        }

        public void Start()
        {
            var messageHandlerOptions = new MessageHandlerOptions(OnServiceBusException) { MaxConcurrentCalls = 4 };

            checkoutMessageReceiverClient.RegisterMessageHandler(OnCheckoutMessageReceived, messageHandlerOptions);
        }

        private async Task OnCheckoutMessageReceived(Message message, CancellationToken arg2)
        {
            var body = Encoding.UTF8.GetString(message.Body);

            BasketCheckoutMessage basketCheckoutMessage 
                = JsonConvert.DeserializeObject<BasketCheckoutMessage>(body);

            await _commandBus.PublishAsync(new PlaceOrderCommand(
                OrderId.New,
                basketCheckoutMessage.UserId,
                basketCheckoutMessage.CardNumber,
                basketCheckoutMessage.CardName,
                basketCheckoutMessage.CardExpiration,
                basketCheckoutMessage.BasketTotal,
                DateTime.Now), arg2);
        }

        private Task OnServiceBusException(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine(exceptionReceivedEventArgs);

            return Task.CompletedTask;
        }

        public void Stop()
        {
        }
    }
}
