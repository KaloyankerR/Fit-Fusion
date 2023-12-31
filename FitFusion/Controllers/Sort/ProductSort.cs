using Interfaces;
using Interfaces.Strategy;
using Models.Product;
using System.Collections.Generic;
using System.Linq;

namespace Services.Sort
{
    //public class TitleAscSortStrategy : ISort<Product>
    //{
    //    public List<Product> Sort(List<Product> products)
    //    {
    //        return products.OrderBy(o => o.Title).ToList();
    //    }
    //}

    //public class TitleDescSortStrategy : ISort<Product>
    //{
    //    public List<Product> Sort(List<Product> products)
    //    {
    //        return products.OrderByDescending(o => o.Title).ToList();
    //    }
    //}

    //public class PriceAscSortStrategy : ISort<Product>
    //{
    //    public List<Product> Sort(List<Product> products)
    //    {
    //        return products.OrderBy(o => o.Price).ToList();
    //    }
    //}

    //public class PriceDescSortStrategy : ISort<Product>
    //{
    //    public List<Product> Sort(List<Product> products)
    //    {
    //        return products.OrderByDescending(o => o.Price).ToList();
    //    }
    //}

    public class ProductSorter : ISort<Product>
    {
        public List<Product> Sort(List<Product> products, Enum param)
        {
            switch (param)
            {
                case SortParameter.TitleAsc:
                    return products.OrderBy(o => o.Title).ToList();
                case SortParameter.TitleDesc:
                    return products.OrderByDescending(o => o.Title).ToList();
                case SortParameter.PriceAsc:
                    return products.OrderBy(o => o.Price).ToList();
                case SortParameter.PriceDesc:
                    return products.OrderByDescending(o => o.Price).ToList();
                default:
                    return products;
            }
        }
        
    }
}
