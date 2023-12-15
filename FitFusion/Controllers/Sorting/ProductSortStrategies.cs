using Interfaces;
using Interfaces.Strategy;
using Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Sorting
{
    //internal class ProductSortStrategies
    //{
    //}

    public class SortProductByTitleAscending: IProductSort
    {
        public List<Product> Sort(List<Product> products)
        {
            return products.OrderBy(o => o.Title).ToList();
        }
    }

    public class SortProductByTitleDescending : IProductSort 
    {
        public List<Product> Sort(List<Product> products)
        {
            return products.OrderByDescending(o => o.Title).ToList();
        }
    }

    public class SortProductByPriceDescending : IProductSort
    {
        public List<Product> Sort(List<Product> products)
        {
            return products.OrderByDescending(o => o.Price).ToList();
        }
    }

    public class SortProductByPriceAscending : IProductSort
    {
        public List<Product> Sort(List<Product> products)
        {
            return products.OrderBy(o => o.Price).ToList();
        }
    }


    //    public List<ProductModel> Sort(List<ProductModel> products, string param)
    //{
    //    if (string.IsNullOrEmpty(param))
    //    {
    //        return products;
    //    }

    //    var sortStrategies = new Dictionary<string, ISortStrategy<ProductModel>>
    //        {
    //            { "titleAsc", new Services.Sorting.SortByTitleAscending() },
    //            { "titleDesc", new Services.Sorting.SortByTitleDescending() },
    //            { "priceAsc", new Services.Sorting.SortByPriceAscending() },
    //            { "priceDesc", new Services.Sorting.SortByPriceDescending() }
    //        };

    //    if (sortStrategies.TryGetValue(param, out var sortStrategy))
    //    {
    //        return sortStrategy.Sort(products);
    //    }

    //    return products;
    //}
}
