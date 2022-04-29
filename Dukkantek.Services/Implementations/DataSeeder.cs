using Dukkantek.Domain.Categories;
using Dukkantek.Domain.Interfaces;
using Dukkantek.Domain.Products;
using Dukkantek.Domain.Shared;
using Dukkantek.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Services.Implementations
{
    public class DataSeeder : IDataSeeder
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly DbContext _dukkantekDbContext;
        private readonly IUnitOfWork _unitOfWork;
        public DataSeeder(IRepository<Category> categoryRepository, IRepository<Product> productRepository,
            DbContext dukkantekDbContext, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _dukkantekDbContext = dukkantekDbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task SeedAppAsync(bool isTesting = false)
        {
            if (!isTesting)
                await _dukkantekDbContext.Database.MigrateAsync();

            await AddCategories();
            await AddProductsAsync();
        }
        private async Task AddCategories()
        {
            if (!await _categoryRepository.AnyAsync())
            {
                List<Category> categories = new List<Category>();
                categories.Add(Category.Create("Grocary"));
                categories.Add(Category.Create("Mobiles"));
                await _categoryRepository.AddRangeAsync(categories);
                await _unitOfWork.SaveChangeAsync();
            }
        }
        private async Task AddProductsAsync()
        {
            if (!await _productRepository.AnyAsync())
            {
                List<Product> products = new List<Product>();
                products.Add(Product.Create("Rice", "Rc1002", "White Rice", 1, ProductStatus.InStock, 50, 1));
                products.Add(Product.Create("Suger", "SUg1002", "White Suger", 1, ProductStatus.InStock, 30, 1));
                products.Add(Product.Create("Milk", "Millk1002", "Milk", 1, ProductStatus.Sold, 10, 1));
                products.Add(Product.Create("WaterMelon", "WaterMln1002", "WaterMelon", 10, ProductStatus.Damaged, 35, 1));
                products.Add(Product.Create("Oil", "Ol1002", "Oil", 1, ProductStatus.Sold, 45, 1));
                products.Add(Product.Create("Tea", "Te1002", "Ahmed Tea", 1, ProductStatus.Damaged, 12, 1));
                await _productRepository.AddRangeAsync(products);
                await _unitOfWork.SaveChangeAsync();
            }
        }
    }
}
