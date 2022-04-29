using AutoMapper;
using Dukkantek.Domain.Interfaces;
using Dukkantek.Domain.Orders;
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
    public class OrderService : IOrderService
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Order> _orderRepository;
        private readonly IProductRepository _productRepository;
        public OrderService(IUnitOfWork unitOfWork, ILogger logger, IMapper mapper, IRepository<Order> orderRepository,
            IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
        public async Task<Result<string>> CreateOrderAsync(CreateOrderDTO createOrderDTO)
        {
            try
            {
                var order = Order.Create();
                foreach (var prdct in createOrderDTO.Products)
                {
                    Product product = await _productRepository.FindByExpressionAsync(p => p.Id == prdct.ProductId);
                    if (product == null || product.Status == ProductStatus.Damaged || product.Status == ProductStatus.Sold)
                        return Result<string>.BadRequest(new[] { ErrorMessages.ProductNotFound });

                    order.AddProduct(product.Id, product.Price, prdct.Quantity);
                }
                order.SetTotalCost();
                await _orderRepository.AddAsync(order);
                await _unitOfWork.SaveChangeAsync();
                return Result<string>.Created($"Order Created with id :: {order.Id}");

            }
            catch (Exception exp)
            {
                _logger.Error(exp, "Create Order");
                return Result<string>.InternalServerError(new[] { ErrorMessages.GeneralError });
            }
        }
    }
}
