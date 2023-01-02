using Microservice.Framework.Domain;
using Microservice.Framework.Domain.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Domain.Extensions;
using OrderService.Domain.ExternalServices.PaymentGateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain
{
    public static class OrderServiceDomainExtensions
    {
        public static Assembly Assembly { get; } = typeof(OrderServiceDomainExtensions).Assembly;

        public static IDomainContainer ConfigureOrderServiceDomain(
            this IServiceCollection services,
            IConfiguration configuration = null)
        {
            return DomainContainer.New(services)
                .AddDefaults(Assembly)
                .AddExternalService<IPaymentGateway, DummyPaymentGateway>(httpclient =>
                {
                    httpclient.BaseAddress = new Uri(
                        configuration["ExternalServices:DiscountServiceApi"]);
                });
        }
    }
}
