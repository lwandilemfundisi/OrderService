using OrderService.Persistence.ValueObjectConverters;
using Microsoft.EntityFrameworkCore;
using OrderService.Domain.DomainModel.OrderDomainModel;

namespace OrderService.Persistence.Mappings
{
    public static class OrderModelMapping
    {
        public static ModelBuilder OrderModelMap(this ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Order>()
            .Property(o => o.Id)
            .HasConversion(new SingleValueObjectIdentityValueConverter<OrderId>());

            return modelBuilder;
        }
    }
}
