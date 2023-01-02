using Microservice.Framework.Domain.Aggregates;
using OrderService.Domain.DomainModel.OrderDomainModel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.DomainModel.OrderDomainModel
{
    public class Order : AggregateRoot<Order, OrderId>
    {
        #region Constructors

        public Order()
            : base(null)
        {

        }

        public Order(OrderId id)
            : base(id)
        {

        }

        #endregion

        #region Properties
        public string UserId { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool OrderPaid { get; set; }

        #endregion

        #region Methods

        public void PlaceOrder(
            string userId,
            string cardNumber,
            string cardName,
            string cardExpiration,
            decimal orderTotal, 
            DateTime orderPlaced)
        {
            UserId = userId;
            OrderTotal = orderTotal;
            OrderPlaced = orderPlaced;

            Emit(new OrderPlacedEvent(
                userId,
                cardNumber,
                cardName,
                cardExpiration,
                orderTotal, 
                orderPlaced));
        }

        public void UpdateOrderPaymentStatus(bool orderPaid)
        {
            OrderPaid = orderPaid;

            Emit(new UpdatedOrderPaymentStatusEvent(orderPaid));
        }

        #endregion
    }
}
