using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Services.Interfaces
{
    public interface IDataSeeder
    {
        Task SeedAppAsync(bool isTesting = false);
    }
}
