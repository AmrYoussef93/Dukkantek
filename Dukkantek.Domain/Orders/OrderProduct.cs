using Dukkantek.Domain.Base;
using Dukkantek.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Domain.Orders
{
    public class OrderProduct : BaseEntity
    {
        public int Quantity { get; private set; }
        public decimal TotalPrice { get; private set; }
        public int OrderId { get; private set; }
        public int ProductId { get; private set; }

        public OrderProduct(int productId,int quantity, decimal totalPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            TotalPrice = totalPrice;
        }

        public static OrderProduct Create(int productId,decimal productPrice, int quantity)
        {
            return new OrderProduct(productId,quantity, (productPrice * quantity));
        }
        public Order Order { get; private set; }
        public Product Product { get; private set; }
    }
}
