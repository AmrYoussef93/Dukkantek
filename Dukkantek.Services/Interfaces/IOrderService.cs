using Dukkantek.Services.DTOs;
using Dukkantek.Services.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Result<string>> CreateOrderAsync(CreateOrderDTO createOrderDTO);
    }
}
