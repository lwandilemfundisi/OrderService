using Microservice.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.DomainModel.OrderDomainModel
{
    public class OrderId : Identity<OrderId>
    {
        public OrderId(string value)
            : base(value)
        {

        }
    }
}
