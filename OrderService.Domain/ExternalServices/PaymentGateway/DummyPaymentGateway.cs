using OrderService.Domain.ExternalServices.PaymentGateway.Models;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Domain.ExternalServices.PaymentGateway
{
    public class DummyPaymentGateway
        : IPaymentGateway
    {
        private readonly HttpClient _httpClient;

        public DummyPaymentGateway(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> Pay(
            CardInfoRequestModel request, 
            CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}
