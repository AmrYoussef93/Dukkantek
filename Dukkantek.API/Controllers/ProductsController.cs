using Dukkantek.API.Common.Filters;
using Dukkantek.Services.DTOs;
using Dukkantek.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dukkantek.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("status/grouping")]
        public async Task<ApiActionResult<ProductsGroupedByStatusDTO>> GetProductsCountGroupedByStatusAsync()
        {
            return new ApiActionResult<ProductsGroupedByStatusDTO>(await _productService.GetProductsCountGroupedByStatusAsync());
        }

        [HttpPut("{productId}/status")]
        public async Task<ApiActionResult<bool>> ChangeProductStatusAsync(int productId, [FromBody] ChangeProductStatusDTO changeProductStatus)
        {
            return new ApiActionResult<bool>(await _productService.ChangeProductStatusAsync(productId, changeProductStatus.Status));
        }
    }
}
