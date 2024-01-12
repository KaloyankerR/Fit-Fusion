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
    public class ProductManager
    {
        private readonly IProductDAO _dao;

        public ProductManager(IProductDAO dao)
        {
            _dao = dao;
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

        public List<Product> Sort(List<Product> products, ISort<Product> sortStrategy)
        {
            try
            {
                return sortStrategy.Sort(products);
            }
            catch
            {
                throw;
            }
        }


        public List<Product> Filter(List<Product> products, List<IFilter<Product>> filterStrategies)
        {
            try
            {
                foreach (IFilter<Product> filterStrategy in filterStrategies)
                {
                    products = filterStrategy.Filter(products);
                }

                return products;
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
