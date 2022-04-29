using Dukkantek.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(150).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(150).IsRequired();

            builder.HasMany(p => p.OrderProducts).WithOne(o => o.Product).HasForeignKey(o => o.ProductId);

        }
    }
}
