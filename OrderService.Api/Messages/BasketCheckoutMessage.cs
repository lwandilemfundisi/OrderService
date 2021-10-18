using OrderService.Intergration.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Messages
{
    public class BasketCheckoutMessage : IntegrationBaseMessage
    {
        public string UserId { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardExpiration { get; set; }
        public decimal BasketTotal { get; set; }
    }
}
