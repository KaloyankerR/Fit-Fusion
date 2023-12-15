using Models.Product;
// using ProductModel = Models.Product.Product;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models.Order;
using System.Data.SqlClient;
using Interfaces.Strategy;
using Services.Filter;
using Services.Sorting;

namespace Services
{
    public class ProductManager : IProduct
    {
        private readonly IProduct _dao;
        private IFilter<Product> _filter;
        private ISort<Product> _sort;

        public ProductManager(IProduct dao)
        {
            _dao = dao;
            _filter = new FilterByCategory();
            _sort = new SortProductByTitleAscending();
        }

        public bool CreateProduct(Product product)
        {
            try
            {
                return _dao.CreateProduct(product);
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                return _dao.UpdateProduct(product);
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                return _dao.DeleteProduct(productId);
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteProduct(Product product)
        {
            try
            {
                return _dao.DeleteProduct(product.Id);
            }
            catch
            {
                throw;
            }
        }

        public Product GetProductById(int id)
        {
            try
            {
                return _dao.GetProductById(id);
            }
            catch
            {
                throw;
            }
        }

        public List<Product> GetProducts()
        {
            try
            {
                return _dao.GetProducts();
            }
            catch
            {
                throw;
            }
        }


        public List<Product> Search(List<Product> products, string searchQuery)
        {
            if (!string.IsNullOrEmpty(searchQuery))
            {
                products = products.FindAll(p =>
                    p.Title.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    (p.Description ?? "").Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    p.Category.ToString().Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    p.Price.ToString().Contains(searchQuery, StringComparison.OrdinalIgnoreCase)
                );
            }

            return products;
        }

        //public List<ProductModel> Sort(List<ProductModel> products, string param)
        //{
        //    if (string.IsNullOrEmpty(param))
        //    {
        //        return products;
        //    }

        //    var sortStrategies = new Dictionary<string, IProductSort>
        //    {
        //        { "titleAsc", new SortProductByTitleAscending() },
        //        { "titleDesc", new SortProductByTitleDescending() },
        //        { "priceAsc", new SortProductByPriceAscending() },
        //        { "priceDesc", new SortProductByPriceDescending() }
        //    };

        //    if (sortStrategies.TryGetValue(param, out var sortStrategy))
        //    {
        //        return sortStrategy.Sort(products);
        //    }

        //    return products;
        //}

        public List<Product> Sort(List<Product> products, string param)
        {
            switch (param)
            {
                case "titleAsc":
                    _sort = new SortProductByTitleAscending();
                    break;
                case "titleDesc":
                    _sort = new SortProductByTitleDescending();
                    break;
                case "priceAsc":
                    _sort = new SortProductByPriceAscending();
                    break;
                case "priceDesc":
                    _sort = new SortProductByPriceDescending();
                    break;
                default:
                    _sort = new SortProductByPriceAscending();
                    break;
            }

            return _sort.Sort(products);
        }

        public List<Product> Filter(List<Product> products, string param)
        {
            return _filter.Filter(products, param);
        }

        //public void SetSortStrategy(ISort<Product> sortStrategy)
        //{
        //    _sort = sortStrategy;
        //}

        //public void SetFilterStrategy(IFilter<Product> filterStrategy)
        //{
        //    _filter = filterStrategy;
        //}


        public Dictionary<Category, int> GetCategoryStats()
        {
            List<Product> products = GetProducts();
            Dictionary<Category, int> categoryCounts = new Dictionary<Category, int>();

            foreach (Product product in products)
            {
                Category category = product.Category;

                if (!categoryCounts.ContainsKey(category))
                {
                    categoryCounts[category] = 1;
                }
                else
                {
                    categoryCounts[category]++;
                }
            }

            return categoryCounts;
        }

        public Dictionary<string, int> GetTrendyProducts()
        {
            try
            {
                return _dao.GetTrendyProducts();
            }
            catch { throw; }
        }

    }
}
