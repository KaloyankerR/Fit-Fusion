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
        public List<Product> Filter(List<Product> products, Dictionary<Enum, object> filters)
        {
            FilterParameter filterKey = filters.Keys.OfType<FilterParameter>().FirstOrDefault();

            if (filterKey == FilterParameter.Category && filters.TryGetValue(filterKey, out var filterValueObj))
            {
                if (filterValueObj is Category filterValue)
                {
                    if (filterValue != Category.All)
                    {
                        return products.Where(p => p.Category == filterValue).ToList();
                    }
                }
            }

            return products;
        }
    }

    public class PriceFilterStrategy : IFilter<Product>
    {
        public List<Product> Filter(List<Product> products, Dictionary<Enum, object> filters)
        {
            FilterParameter filterKey = filters.Keys.OfType<FilterParameter>().FirstOrDefault();

            if (filterKey == FilterParameter.Price && filters.TryGetValue(filterKey, out var priceRangeObj) && priceRangeObj is List<double> priceRange)
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
        public List<Product> Filter(List<Product> products, Dictionary<Enum, object> filters)
        {
            IFilter<Product> filter;

            if (filters == null || filters.Count == 0)
            {
                return products;
            }

            FilterParameter filterKey = filters.Keys.OfType<FilterParameter>().FirstOrDefault();

            switch (filterKey)
            {
                case FilterParameter.Category:
                    filter = new CategoryFilterStrategy();
                    break;
                case FilterParameter.Price:
                    filter = new PriceFilterStrategy();
                    break;
                default:
                    return products;
            }

            return filter.Filter(products, filters);
        }
    }
}
