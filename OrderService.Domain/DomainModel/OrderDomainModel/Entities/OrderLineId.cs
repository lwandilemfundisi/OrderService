using Microservice.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.DomainModel.OrderDomainModel.Entities
{
    public class OrderLineId : Identity<OrderLineId>
    {
        public OrderLineId(string value)
            : base(value)
        {

        }
    }
}
