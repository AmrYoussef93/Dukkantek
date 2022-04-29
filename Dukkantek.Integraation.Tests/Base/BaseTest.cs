using Dukkantek.API;
using Dukkantek.Infrastructure.Context;
using Dukkantek.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Integraation.Tests.Base
{
    public class BaseTest<T> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(Microsoft.AspNetCore.Hosting.IWebHostBuilder builder)
        {
            builder.ConfigureServices(async services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<DukkantekDbContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.Remove(descriptor);

                services.AddDbContext<DukkantekDbContext>(options =>
                {
                    options.UseInMemoryDatabase("Dukkantek");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<DukkantekDbContext>();
                    var appSeeder = scopedServices.GetRequiredService<IDataSeeder>();

                    db.Database.EnsureCreated();
                    await appSeeder.SeedAppAsync(true);
                }
            });
        }
    }
}
