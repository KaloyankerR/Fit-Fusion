using Models.Product;
using ProductModel = Models.Product.Product;
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
        private IProductFilter _filter;
        private IProductSort _sort;

        public ProductManager(IProduct dao)
        {
            _dao = dao;
            _filter = new FilterByCategory();
            _sort = new SortProductByTitleAscending();
        }

        public bool CreateProduct(ProductModel product)
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

        public bool UpdateProduct(ProductModel product)
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

        public bool DeleteProduct(ProductModel product)
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

        public ProductModel GetProductById(int id)
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

        public List<ProductModel> GetProducts()
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


        public List<ProductModel> Search(List<ProductModel> products, string searchQuery)
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

        public List<Product> Sort(List<Product> products)
        {
            return _sort.Sort(products);
        }

        public List<ProductModel> FilterByCategory(List<ProductModel> products, string param)
        {
            _filter = new FilterByCategory(); // TODO: set the filtering strategy
            return _filter.Filter(products, param);
        }

        public void SetSortStrategy(IProductSort sortStrategy)
        {
            _sort = sortStrategy;
        }

        public void SetFilterStrategy(IProductFilter filterStrategy)
        {
            _filter = filterStrategy;
        }


        public Dictionary<Category, int> GetCategoryStats()
        {
            List<ProductModel> products = GetProducts();
            Dictionary<Category, int> categoryCounts = new Dictionary<Category, int>();

            foreach (ProductModel product in products)
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
