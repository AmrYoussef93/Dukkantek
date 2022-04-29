using Dukkantek.Services.Implementations;
using Dukkantek.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            var _logger = new LoggerConfiguration()
                              .Enrich.WithExceptionDetails()
                              .ReadFrom.Configuration(configuration)
                              .CreateLogger();
            services.AddSingleton<ILogger>(_logger);

            // register  services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IDataSeeder, DataSeeder>();
            return services;
        }
    }
}
