using Models.Product;
using Interfaces;
using Models.Order;
using System.Data.SqlClient;
using Interfaces.Strategy;
using Models.Product.Enums;
using Services.Sort;
using Services.Filter;

namespace Services
{
    public class ProductManager : IProduct
    {
        private readonly IProduct _dao;
        private readonly ProductSorter _sorter;
        private readonly ProductFilter _filter;

        public ProductManager(IProduct dao, ProductFilter filter, ProductSorter sorter)
        {
            _dao = dao;
            _filter = filter;
            _sorter = sorter;
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

        //public List<Product> Search(List<Product> products, string searchQuery)
        //{
        //    if (!string.IsNullOrEmpty(searchQuery))
        //    {
        //        searchQuery = searchQuery.ToLower();
        //        products = products.FindAll(p =>
        //            p.Title.ToLower().Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
        //            (p.Description ?? "").ToLower().Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
        //            p.Category.ToString().ToLower().Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
        //            p.Price.ToString().ToLower().Contains(searchQuery, StringComparison.OrdinalIgnoreCase) //might be used in cases like EUR/Eur 
        //        );
        //    }

        //    return products;
        //}

        public List<Product> Sort(List<Product> products, Enum param)
        {
            try
            {
                return _sorter.Sort(products, param);
            }
            catch
            {
                throw;
            }
        }

        public List<Product> Filter(List<Product> products, Dictionary<Enum, object> filters)
        {
            try
            {
                return _filter.Filter(products, filters);
            }
            catch 
            { 
                throw; 
            }
        }

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
