using Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess
{
    public class ProductDAO
    {
        private string ConnectionString;

        public ProductDAO()
        {
            ConnectionString = Connection.DbConnection.ConnectionString;
        }

        public ProductDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public bool CreateProduct(Product product) { return false; }

        public bool UpdateProduct(Product product) { return false; }

        public bool DeleteProduct(Product product) { return false; }

        public Product GetProductById(int id) { return new Product(); }

        public List<Product> GetAllProducts() {  return new List<Product>(); }

    }
}
