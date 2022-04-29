using Dukkantek.Domain.Base;
using Dukkantek.Domain.Shared;
using System.Collections.Generic;
using System.Linq;

namespace Dukkantek.Domain.Orders
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public OrderStatus Status { get; private set; }
        public decimal TotalCost { get; private set; }

        public Order(OrderStatus status)
        {
            Status = status;
            OrderProducts = new HashSet<OrderProduct>();
        }
        #region Behavior Methods
        public static Order Create()
        {
            return new Order(OrderStatus.InProgress);
        }
        public void SetTotalCost()
        {
            TotalCost = OrderProducts.Sum(p => p.TotalPrice);
        }
        public void AddProduct(int productId,decimal price, int quantity)
        {
            OrderProduct product = OrderProduct.Create(productId, price, quantity);
            OrderProducts.Add(product);
        }
        #endregion

        #region Navigation Properties
        public ICollection<OrderProduct> OrderProducts { get; set; }
        #endregion
    }
}
