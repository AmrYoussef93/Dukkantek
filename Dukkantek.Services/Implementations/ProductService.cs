using AutoMapper;
using Dukkantek.Domain.Interfaces;
using Dukkantek.Domain.Products;
using Dukkantek.Domain.Shared;
using Dukkantek.Services.DTOs;
using Dukkantek.Services.Handlers;
using Dukkantek.Services.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductService(IUnitOfWork unitOfWork, ILogger logger, IMapper mapper, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Result<ProductsGroupedByStatusDTO>> GetProductsCountGroupedByStatusAsync()
        {
            try
            {
                Dictionary<ProductStatus, int> products = await _productRepository.GetProductsGroupedByStatusAsync();
                ProductsGroupedByStatusDTO productsGroupedByStatusDTO = new ProductsGroupedByStatusDTO()
                {
                    DamagedProducts = products[ProductStatus.Damaged],
                    InStockProducts = products[ProductStatus.InStock],
                    SoldProducts = products[ProductStatus.Sold],
                };
                return Result<ProductsGroupedByStatusDTO>.Ok(productsGroupedByStatusDTO);
            }
            catch (Exception exp)
            {
                _logger.Error(exp, "Get Products Count Grouped By Status");
                return Result<ProductsGroupedByStatusDTO>.InternalServerError(new[] { ErrorMessages.GeneralError });
            }
        }

        public async Task<Result<bool>> ChangeProductStatusAsync(int productId, ProductStatus status)
        {
            try
            {
                Product product = await _productRepository.FindByExpressionAsync(p => p.Id == productId);
                if (product == null) return Result<bool>.NotFound();

                product.ChangeStatus(status);
                await _productRepository.UpdateAsync(product);
                await _unitOfWork.SaveChangeAsync();
                return Result<bool>.NoContent();
            }
            catch (Exception exp)
            {
                _logger.Error(exp, "Change Product Status");
                return Result<bool>.InternalServerError(new[] { ErrorMessages.GeneralError });
            }
        }
    }
}
