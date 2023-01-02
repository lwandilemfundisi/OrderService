using Microservice.Framework.Common;
using Newtonsoft.Json;

namespace OrderService.Domain.DomainModel.OrderDomainModel
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class OrderId : Identity<OrderId>
    {
        public OrderId(string value)
            : base(value)
        {

        }
    }
}
