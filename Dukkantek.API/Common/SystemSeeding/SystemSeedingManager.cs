using Dukkantek.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Dukkantek.API.Common.SystemSeeding
{
    public static class SystemSeedingManager
    {
        public static async Task<IHost> SeedSystem(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var _logger = services.GetRequiredService<ILogger>();
                var appSeeder = services.GetRequiredService<IDataSeeder>();
                try
                {
                    _logger.Debug($"Starting initializing system");

                    await appSeeder.SeedAppAsync();

                    _logger.Debug($"Finish initializing system");


                }
                catch (Exception exp)
                {
                    _logger.Error(exp, "An error occurred while intializing system please contact administator");
                }

            }
            return host;
        }
    }
}
