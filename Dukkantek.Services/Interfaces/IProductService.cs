using Dukkantek.Domain.Shared;
using Dukkantek.Services.DTOs;
using Dukkantek.Services.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Services.Interfaces
{
    public interface IProductService
    {
        Task<Result<ProductsGroupedByStatusDTO>> GetProductsCountGroupedByStatusAsync();
        Task<Result<bool>> ChangeProductStatusAsync(int productId, ProductStatus status);
    }
}
