using Interfaces;
using Interfaces.Strategy;
using Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Sort
{
    //internal class ProductSortStrategies
    //{
    //}

    public class ProductSorter // : ISort<Product>
    {
        public List<Product> Sort(List<Product> products, string param)
        {
            switch (param)
            {
                case "titleAsc":
                    return products.OrderBy(o => o.Title).ToList();
                case "titleDesc":
                    return products.OrderByDescending(o => o.Title).ToList();
                case "priceAsc":
                    return products.OrderBy(o => o.Price).ToList();
                case "priceDesc":
                    return products.OrderByDescending(o => o.Price).ToList();
                default:
                    return products;
            }
        }
    }

    public class SortProductByTitleAscending: ISort<Product>
    {
        public List<Product> Sort(List<Product> products)
        {
            return products.OrderBy(o => o.Title).ToList();
        }
    }

    public class SortProductByTitleDescending : ISort<Product> 
    {
        public List<Product> Sort(List<Product> products)
        {
            return products.OrderByDescending(o => o.Title).ToList();
        }
    }

    public class SortProductByPriceDescending : ISort<Product>
    {
        public List<Product> Sort(List<Product> products)
        {
            return products.OrderByDescending(o => o.Price).ToList();
        }
    }

    public class SortProductByPriceAscending : ISort<Product>
    {
        public List<Product> Sort(List<Product> products)
        {
            return products.OrderBy(o => o.Price).ToList();
        }
    }

}
