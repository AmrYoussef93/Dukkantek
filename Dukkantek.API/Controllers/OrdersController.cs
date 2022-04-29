using Dukkantek.API.Common.Filters;
using Dukkantek.Services.DTOs;
using Dukkantek.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dukkantek.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost()]
        public async Task<ApiActionResult<string>> CreateOrderAsync([FromBody] CreateOrderDTO createOrderDTO)
        {
            return new ApiActionResult<string>(await _orderService.CreateOrderAsync(createOrderDTO));
        }
    }
}
