using Models.Product;
using ProductModel = Models.Product.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Services
{
    public class ProductManager : IProduct
    {
        private readonly IProduct dao;

        public ProductManager(IProduct productDao)
        {
            dao = productDao;
        }

        public bool CreateProduct(ProductModel product)
        {
            try
            {
                dao.CreateProduct(product);
                return true;
            }
            catch { return false; }
            // return productDAO.CreateProduct(product);
        }

        public bool UpdateProduct(ProductModel product)
        {
            try
            {
                dao.UpdateProduct(product);
                return true;
            }
            catch { return false; }
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                dao.DeleteProduct(productId);
                return true;
            }
            catch { return false; }
        }

        public bool DeleteProduct(ProductModel product)
        {
            try
            {
                dao.DeleteProduct(product.Id);
                return true;
            }
            catch { return false; }
        }

        public ProductModel GetProductById(int productId)
        {
            try
            {
                return dao.GetProductById(productId);
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }

        public List<ProductModel> GetProducts()
        {
            try
            {
                return dao.GetProducts();
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }

        public List<ProductModel> Search(List<ProductModel> products, string searchQuery)
        {
            if (!string.IsNullOrEmpty(searchQuery))
            {
                products = products.FindAll(p =>
                    p.Title.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    p.Description.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    p.Category.ToString().Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    p.Price.ToString().Contains(searchQuery, StringComparison.OrdinalIgnoreCase)
                );
            }

            return products;
        }

        public List<ProductModel> Sort(List<ProductModel> products, string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                return products;
            }

            var sortStrategies = new Dictionary<string, ISortStrategy<ProductModel>>
            {
                { "titleAsc", new Services.Sorting.SortByTitleAscending() },
                { "titleDesc", new Services.Sorting.SortByTitleDescending() },
                { "priceAsc", new Services.Sorting.SortByPriceAscending() },
                { "priceDesc", new Services.Sorting.SortByPriceDescending() }
            };

            if (sortStrategies.TryGetValue(param, out var sortStrategy))
            {
                return sortStrategy.Sort(products);
            }

            return products;
        }

        public List<ProductModel> FilterByCategory(List<ProductModel> products, string param)
        {
            if (string.IsNullOrEmpty(param) || param == "All")
            {
                return products;
            }

            return products.Where(p => p.Category.ToString().Equals(param, StringComparison.OrdinalIgnoreCase)).ToList();
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
                return dao.GetTrendyProducts();
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }

    }
}
