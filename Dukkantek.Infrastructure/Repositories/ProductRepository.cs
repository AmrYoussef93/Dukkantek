using Dukkantek.Domain.Products;
using Dukkantek.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {

        }
        public async Task<Dictionary<ProductStatus, int>> GetProductsGroupedByStatusAsync()
        {
            var countPerStatus = await _dbSet.GroupBy(t => t.Status)
                    .Select(statusGrp => new { Status = statusGrp.Key, Count = statusGrp.Count() }).ToDictionaryAsync(x => x.Status, x => x.Count);
            return countPerStatus;
        }
    }
}
