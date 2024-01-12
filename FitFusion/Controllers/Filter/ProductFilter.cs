using Interfaces.Strategy;
using Models.Product;
using Models.Product.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Filter
{
    public class CategoryFilterStrategy : IFilter<Product>
    {
        public List<Product> Filter(List<Product> products, object param)
        {
            if (param is Category filterValue)
            {
                if (filterValue != Category.All)
                {
                    return products.Where(p => p.Category == filterValue).ToList();
                }
            }


            return products;
        }
    }

    public class PriceFilterStrategy : IFilter<Product>
    {
        public List<Product> Filter(List<Product> products, object param)
        {
            if (param is List<double> priceRange && priceRange.Count >= 2)
            {
                double min = priceRange[0];
                double max = priceRange[1];

                if (min >= 0 && max > 0 && min <= max)
                {
                    return products.Where(p => p.Price >= min && p.Price <= max).ToList();
                }
            }

            return products;
        }
    }

    public class ProductKeywordFilterStrategy : IFilter<Product>
    {
        public List<Product> Filter(List<Product> products, object param)
        {
            if (param is string searchQuery && !string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = searchQuery.ToLower();

                products = products.FindAll(p =>
                    p.Title.ToLower().Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    (p.Description ?? "").ToLower().Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    p.Category.ToString().ToLower().Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    p.Price.ToString().ToLower().Contains(searchQuery, StringComparison.OrdinalIgnoreCase)
                );
            }

            return products;
        }
    }

    //public class ProductFilter
    //{
    //    public List<Product> Filter(List<Product> products, Dictionary<Enum, object> filters)
    //    {
    //        if (filters == null || filters.Count == 0)
    //        {
    //            return products;
    //        }

    //        List<(IFilter<Product> FilterStrategy, object FilterValue)> filterStrategies = new List<(IFilter<Product>, object)>();

    //        foreach (var filterEntry in filters)
    //        {
    //            if (filterEntry.Key is FilterParameter filterKey)
    //            {
    //                switch (filterKey)
    //                {
    //                    case FilterParameter.Keyword:
    //                        filterStrategies.Add((new ProductKeywordFilterStrategy(), filterEntry.Value));
    //                        break;
    //                    case FilterParameter.Category:
    //                        filterStrategies.Add((new CategoryFilterStrategy(), filterEntry.Value));
    //                        break;
    //                    case FilterParameter.Price:
    //                        filterStrategies.Add((new PriceFilterStrategy(), filterEntry.Value));
    //                        break;
    //                }
    //            }
    //        }

    //        if (filterStrategies.Count == 0)
    //        {
    //            return products;
    //        }

    //        foreach (var (filterStrategy, filterValue) in filterStrategies)
    //        {
    //            try
    //            {
    //                products = filterStrategy.Filter(products, filterValue);
    //            }
    //            catch
    //            {
    //                throw new ArgumentException("Invalid filtering parameter.");
    //            }
    //        }

    //        return products;
    //    }
    // }
}
