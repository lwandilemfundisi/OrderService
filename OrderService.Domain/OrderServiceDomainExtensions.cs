using Microservice.Framework.Domain;
using Microservice.Framework.Domain.Extensions;
using Microsoft.Extensions.DependencyInjection;
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
            this IServiceCollection services)
        {
            return DomainContainer.New(services)
                .AddDefaults(Assembly);
        }
    }
}
