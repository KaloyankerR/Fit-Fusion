﻿using Interfaces;
using Interfaces.Strategy;
using Models.Product;
using Models.Product.Enums;
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
                case Models.Product.Enums.SortParameter.TitleAsc:
                    return SortByTitleAscending(products);
                case Models.Product.Enums.SortParameter.TitleDesc:
                    return SortByTitleDescending(products);
                case Models.Product.Enums.SortParameter.PriceAsc:
                    return SortByPriceAscending(products);
                case Models.Product.Enums.SortParameter.PriceDesc:
                    return SortByPriceDescending(products);
                default:
                    return products;
            }
        }

        private List<Product> SortByTitleAscending(List<Product> products)
        {
            return products.OrderBy(o => o.Title).ToList();
        }

        private List<Product> SortByTitleDescending(List<Product> products)
        {
            return products.OrderByDescending(o => o.Title).ToList();
        }

        private List<Product> SortByPriceAscending(List<Product> products)
        {
            return products.OrderBy(o => o.Price).ToList();
        }

        private List<Product> SortByPriceDescending(List<Product> products)
        {
            return products.OrderByDescending(o => o.Price).ToList();
        }
    }

}
