using Interfaces.Strategy;
using Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Filter
{
    public class CategoryFilterStrategy : IFilter<Product>
    {
        public List<Product> Filter(List<Product> products, Dictionary<string, object> filters)
        {
            string filterKey = filters.Keys.FirstOrDefault()!;

            if (filterKey == "category" && filters.TryGetValue(filterKey, out var filterValue))
            {
                string categoryFilter = filterValue.ToString()!;

                if (!string.IsNullOrEmpty(categoryFilter) && categoryFilter != "All")
                {
                    return products.Where(p => p.Category.ToString().Equals(categoryFilter, StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }

            return products;
        }
    }

    public class PriceFilterStrategy : IFilter<Product>
    {
        public List<Product> Filter(List<Product> products, Dictionary<string, object> filters)
        {
            string filterKey = filters.Keys.FirstOrDefault()!;

            if (filterKey == "price" && filters.TryGetValue(filterKey, out var priceRangeObj) && priceRangeObj is List<double> priceRange)
            {
                double min = priceRange[0];
                double max = priceRange[1];

                if (min >= 0 && max >= 0 && min <= max)
                {
                    return products.Where(p => p.Price >= min && p.Price <= max).ToList();
                }
            }

            return products;
        }
    }

    public class ProductFilter
    {
        public List<Product> Filter(List<Product> products, Dictionary<string, object> filters)
        {
            IFilter<Product> filter;

            if (filters == null || filters.Count == 0)
            {
                return products;
            }

            string filterKey = filters.Keys.FirstOrDefault()!;

            switch (filterKey)
            {
                case "category":
                    filter = new CategoryFilterStrategy();
                    break;
                case "price":
                    filter = new PriceFilterStrategy();
                    break;
                default:
                    return products;
            }

            return filter.Filter(products, filters);
        }
    }

}
