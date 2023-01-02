using Microservice.Framework.Domain.Commands;
using Microservice.Framework.Domain.ExecutionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Domain.DomainModel.OrderDomainModel.Commands
{
    public class PlaceOrderCommand 
        : Command<Order, OrderId>
    {
        #region Constructors

        public PlaceOrderCommand(
            OrderId id,
            string userId,
            string cardNumber,
            string cardName,
            string cardExpiration,
            decimal orderTotal,
            DateTime orderPlaced)
            : base(id)
        {
            UserId = userId;
            CardNumber = cardNumber;
            CardName = cardName;
            CardExpiration = cardExpiration;
            OrderTotal = orderTotal;
            OrderPlaced = orderPlaced;
        }

        #endregion

        #region Properties

        public string UserId { get; }

        public string CardNumber { get; }

        public string CardName { get; }

        public string CardExpiration { get; }

        public decimal OrderTotal { get; }

        public DateTime OrderPlaced { get; }

        #endregion
    }

    public class PlaceOrderCommandHandler 
        : CommandHandler<Order, OrderId, PlaceOrderCommand>
    {
        #region Virtual Methods

        public override Task<IExecutionResult> ExecuteAsync(
            Order aggregate, 
            PlaceOrderCommand command, 
            CancellationToken cancellationToken)
        {
            aggregate.PlaceOrder(
                command.UserId,
                command.CardNumber,
                command.CardName,
                command.CardExpiration,
                command.OrderTotal, 
                command.OrderPlaced);

            return Task.FromResult(ExecutionResult.Success());
        }

        #endregion
    }
}
