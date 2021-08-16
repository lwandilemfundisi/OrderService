using Microservice.Framework.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace OrderService.Persistence
{
    public class OrderContextProvider : IDbContextProvider<OrderContext>, IDisposable
    {
        private readonly DbContextOptions<OrderContext> _options;

        public OrderContextProvider(IConfiguration configuration)
        {
            _options = new DbContextOptionsBuilder<OrderContext>()
                .UseSqlServer(configuration["DataConnection:Database"])
                .Options;
        }

        public OrderContext CreateContext()
        {
            return new OrderContext(_options);
        }

        public void Dispose()
        {
        }
    }
}
