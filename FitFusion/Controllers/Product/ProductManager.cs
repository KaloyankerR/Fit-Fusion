using DataAcess;
using Models.Product;
using ProductModel = Models.Product.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Product
{
    public class ProductManager
    {
        public ProductDAO dao;

        public ProductManager(ProductDAO productDao)
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
                return dao.GetAllProducts();
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }
    
    }
}
