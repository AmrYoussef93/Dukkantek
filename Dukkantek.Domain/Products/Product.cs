using Dukkantek.Domain.Base;
using Dukkantek.Domain.Categories;
using Dukkantek.Domain.Orders;
using Dukkantek.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Domain.Products
{
    public class Product : BaseEntity
    {
        public decimal Price { get; private set; }
        public string Name { get; private set; }
        public string BarCode { get; private set; }
        public string Description { get; private set; }
        public decimal Weight { get; private set; }
        public ProductStatus Status { get; private set; }
        public int CategoryId { get; private set; }
        public Product()
        {

        }
        public Product(string name, string barcode, string description,
            decimal weight, ProductStatus status, decimal price, int categoryId)
        {
            Name = name;
            BarCode = barcode;
            Description = description;
            Weight = weight;
            Status = status;
            Price = price;
            CategoryId = categoryId;
            OrderProducts = new HashSet<OrderProduct>();
        }

        #region Navigation Properties
        public Category Category { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; private set; }

        #endregion

        #region Behavior Methods
        public static Product Create(string name, string barcode, string description,
            decimal weight, ProductStatus status, decimal price, int categoryId)
        {
            return new Product(name, barcode, description, weight, status, price, categoryId);
        }

        public void ChangeStatus(ProductStatus status)
        {
            Status = status;
        }
        #endregion
    }
}
