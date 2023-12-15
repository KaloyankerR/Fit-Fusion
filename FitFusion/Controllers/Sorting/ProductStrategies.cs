//using Interfaces;
//using Models.Product;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Services.Sorting
//{
//    public class ProductStrategies
//    { }

//    public class SortByTitleAscending : ISortStrategy<Product>
//    {
//        public List<Product> Sort(List<Product> products)
//        {
//            return products.OrderBy(o => o.Title).ToList();
//        }
//    }

//    public class SortByTitleDescending : ISortStrategy<Product>
//    {
//        public List<Product> Sort(List<Product> products)
//        {
//            return products.OrderByDescending(o => o.Title).ToList();
//        }
//    }

//    public class SortByPriceDescending : ISortStrategy<Product>
//    {
//        public List<Product> Sort(List<Product> products)
//        {
//            return products.OrderByDescending(o => o.Price).ToList();
//        }
//    }

//    public class SortByPriceAscending : ISortStrategy<Product>
//    {
//        public List<Product> Sort(List<Product> products)
//        {
//            return products.OrderBy(o => o.Price).ToList();
//        }
//    }

//}
