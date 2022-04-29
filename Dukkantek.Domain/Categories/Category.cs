using Dukkantek.Domain.Base;
using Dukkantek.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Domain.Categories
{
    public class Category : BaseEntity
    {
        public Category(string name)
        {
            Name = name;
            Products = new HashSet<Product>();
        }
        public string Name { get; private set; }

        #region Behavior Methods
        public static Category Create(string name)
        {
            return new Category(name);
        }
        #endregion

        #region Navigation Properties
        public ICollection<Product> Products { get; private set; }
        #endregion
    }
}
