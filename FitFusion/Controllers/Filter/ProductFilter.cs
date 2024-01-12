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
        private Category _filterValue;

        public CategoryFilterStrategy(Category? filterValue)
        {
            _filterValue = filterValue ?? Category.All;
        }

        public List<Product> Filter(List<Product> products)
        {
            if (_filterValue != Category.All)
            {
                return products.Where(p => p.Category == _filterValue).ToList();
            }

            return products;
        }
    }

    public class PriceFilterStrategy : IFilter<Product>
    {
        private List<double> _priceRange;

        public PriceFilterStrategy(List<double>? priceRange)
        {
            _priceRange = priceRange ?? new List<double> { 0, 0 };
        }

        public List<Product> Filter(List<Product> products)
        {
            if (_priceRange.Count >= 2)
            {
                double min = _priceRange[0];
                double max = _priceRange[1];

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
        private string _searchQuery;

        public ProductKeywordFilterStrategy(string? searchQuery)
        {
            _searchQuery = searchQuery?.ToLower() ?? "";
        }

        public List<Product> Filter(List<Product> products)
        {
            if (!string.IsNullOrEmpty(_searchQuery))
            {
                products = products.FindAll(p =>
                    p.Title.ToLower().Contains(_searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    (p.Description ?? "").ToLower().Contains(_searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    p.Category.ToString().ToLower().Contains(_searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    p.Price.ToString().ToLower().Contains(_searchQuery, StringComparison.OrdinalIgnoreCase)
                );
            }

            return products;
        }
    }



}
