using Dukkantek.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dukkantek.Infrastructure.Configurations
{
    public class OrderProductsConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProducts");
            builder.HasKey(c => new { c.OrderId, c.ProductId });
            builder.Property(c => c.Quantity).IsRequired();
            builder.Property(c => c.TotalPrice).IsRequired();
        }
    }
}
