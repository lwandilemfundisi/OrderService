using OrderService.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace OrderService.Persistence
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.OrderModelMap();
        }
    }
}
