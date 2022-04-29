using Dukkantek.Domain.Interfaces;
using Dukkantek.Domain.Products;
using Dukkantek.Infrastructure.Context;
using Dukkantek.Infrastructure.Repositories;
using Dukkantek.Infrastructure.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DukkantekDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DukkantekDbContext")));

            services.AddScoped<DbContext, DukkantekDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
