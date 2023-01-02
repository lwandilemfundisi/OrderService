using OrderService.Domain.ExternalServices.PaymentGateway.Models;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Domain.ExternalServices.PaymentGateway
{
    public interface IPaymentGateway
    {
        Task<bool> Pay(
            CardInfoRequestModel request, 
            CancellationToken cancellationToken);
    }
}
