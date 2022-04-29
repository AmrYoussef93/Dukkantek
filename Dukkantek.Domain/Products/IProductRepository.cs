using Dukkantek.Domain.Interfaces;
using Dukkantek.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Domain.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Dictionary<ProductStatus, int>> GetProductsGroupedByStatusAsync();
    }
}
