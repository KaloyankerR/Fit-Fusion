using Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IProduct
    {
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int productId);
        Product GetProductById(int productId);
        List<Product> GetProducts();
        Dictionary<string, int> GetTrendyProducts();
    }
}
