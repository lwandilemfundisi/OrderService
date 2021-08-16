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
    public class UpdateOrderPaymentStatusCommand 
        : Command<Order, OrderId>
    {
        #region Constructors

        public UpdateOrderPaymentStatusCommand(
            OrderId id,
            bool orderPaid)
            : base(id)
        {
            OrderPaid = orderPaid;
        }

        #endregion

        #region Properties

        public bool OrderPaid { get; }

        #endregion
    }

    public class UpdateOrderPaymentStatusCommandHandler
        : CommandHandler<Order, OrderId, UpdateOrderPaymentStatusCommand>
    {
        #region Virtual Methods

        public override Task<IExecutionResult> ExecuteAsync(
            Order aggregate, 
            UpdateOrderPaymentStatusCommand command, 
            CancellationToken cancellationToken)
        {
            aggregate.UpdateOrderPaymentStatus(command.OrderPaid);
            return Task.FromResult(ExecutionResult.Success());
        }

        #endregion
    }
}
