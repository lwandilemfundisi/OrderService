using Microservice.Framework.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Extensions
{
    public static class IDomainContainerExtentions
    {
        public static IDomainContainer AddExternalService<TContract, TImplementation>(
            this IDomainContainer domainContainer,
            Action<HttpClient> configureClient)
            where TContract : class
            where TImplementation : class, TContract
        {
            domainContainer
                .ServiceCollection
                .AddHttpClient<TContract, TImplementation>(configureClient)
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(GetCircuitBreakerPolicy())
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                });

            return domainContainer;
        }

        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(5,
                    retryAttempt => TimeSpan.FromMilliseconds(Math.Pow(1.5, retryAttempt) * 1000),
                (_, waitingTime) =>
                {
                    Console.WriteLine("Retrying due to Polly retry policy");
                });
        }

        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(3, TimeSpan.FromSeconds(15));
        }
    }
}
