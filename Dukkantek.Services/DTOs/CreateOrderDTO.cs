using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Services.DTOs
{
    public class CreateOrderDTO
    {
        public List<OrderProductDTO> Products { get; set; }
    }
}
