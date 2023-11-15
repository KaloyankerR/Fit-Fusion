using ProductModel = Models.Product.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Order
{
    public class ShoppingCart
    {
        public List<ProductModel> Products { get; set; } = new();

        public ShoppingCart() { }

        public ShoppingCart(List<ProductModel> products) 
        {
            Products = products;
        }

        public void AddProduct(ProductModel product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(ProductModel product) 
        {
            Products.Remove(product);
        }

        public override string ToString()
        {
            return $"{Products.Count} products in cart";
        }
    }

}
