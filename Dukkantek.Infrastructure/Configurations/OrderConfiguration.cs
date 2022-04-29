using Dukkantek.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Status).IsRequired();
            builder.Property(c => c.TotalCost).IsRequired();

            builder.HasMany(o => o.OrderProducts).WithOne(o => o.Order).HasForeignKey(o => o.OrderId);
        }
    }
}
