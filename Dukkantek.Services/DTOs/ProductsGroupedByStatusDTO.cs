using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Services.DTOs
{
    public class ProductsGroupedByStatusDTO
    {
        public int InStockProducts { get; set; }
        public int DamagedProducts { get; set; }
        public int SoldProducts { get; set; }
    }
}
