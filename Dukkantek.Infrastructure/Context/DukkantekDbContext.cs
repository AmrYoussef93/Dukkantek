using Dukkantek.Domain.Categories;
using Dukkantek.Domain.Orders;
using Dukkantek.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Infrastructure.Context
{
    public class DukkantekDbContext : DbContext
    {
        public DukkantekDbContext(DbContextOptions<DukkantekDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("dbo");
            builder.ApplyConfigurationsFromAssembly(typeof(DukkantekDbContext).Assembly);
        }
    }
}
