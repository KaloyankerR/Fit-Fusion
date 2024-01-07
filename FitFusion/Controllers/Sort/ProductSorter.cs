using Interfaces.Strategy;
using Models.Product;
using Models.Product.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Sort
{
    public class TitleAscSortStrategy : ISort<Product>
    {
        public List<Product> Sort(List<Product> products)
        {
            return products.OrderBy(o => o.Title).ToList();
        }
    }

    public class TitleDescSortStrategy : ISort<Product>
    {
        public List<Product> Sort(List<Product> products)
        {
            return products.OrderByDescending(o => o.Title).ToList();
        }
    }

    public class PriceAscSortStrategy : ISort<Product>
    {
        public List<Product> Sort(List<Product> products)
        {
            return products.OrderBy(o => o.Price).ToList();
        }
    }

    public class PriceDescSortStrategy : ISort<Product>
    {
        public List<Product> Sort(List<Product> products)
        {
            return products.OrderByDescending(o => o.Price).ToList();
        }
    }

    public class ProductSorter
    {
        public List<Product> Sort(List<Product> products, Enum sortParam)
        {
            ISort<Product> sortStrategy;

            switch (sortParam)
            {
                case SortParameter.TitleAsc:
                    sortStrategy = new TitleAscSortStrategy();
                    break;
                case SortParameter.TitleDesc:
                    sortStrategy = new TitleDescSortStrategy();
                    break;
                case SortParameter.PriceAsc:
                    sortStrategy = new PriceAscSortStrategy();
                    break;
                case SortParameter.PriceDesc:
                    sortStrategy = new PriceDescSortStrategy();
                    break;
                default:
                    return products;
            }

            return sortStrategy.Sort(products);
        }
    }
}
