using Interfaces.Strategy;
using Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Filter
{
    public class FilterByCategory : IProductFilter
    {
        public List<Product> Filter(List<Product> products, string param)
        {
            if (string.IsNullOrEmpty(param) || param == "All")
            {
                return products;
            }

            return products.Where(p => p.Category.ToString().Equals(param, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
