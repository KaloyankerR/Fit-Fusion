using DataAcess;
using Models.Product;
using ProductModel = Models.Product.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Interfaces;

namespace Controllers
{
    public class ProductManager
    {
        private readonly IProductDAO dao;

        public ProductManager(IProductDAO productDao)
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
            if (!string.IsNullOrEmpty(param))
            {
                switch (param)
                {
                    case "titleAsc":
                        products.Sort((a, b) => string.Compare(a.Title, b.Title, StringComparison.Ordinal));
                        break;
                    case "titleDesc":
                        products.Sort((a, b) => string.Compare(b.Title, a.Title, StringComparison.Ordinal));
                        break;
                    case "priceAsc":
                        products.Sort((a, b) => a.Price.CompareTo(b.Price));
                        break;
                    case "priceDesc":
                        products.Sort((a, b) => b.Price.CompareTo(a.Price));
                        break;
                }
            }
            return products;
        }

    }
}
