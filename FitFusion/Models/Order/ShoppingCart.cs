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
        public int Discount { get; set; } = new();

        public ShoppingCart() { }

        public ShoppingCart(List<ProductModel> products, int discount) 
        {
            Products = products;
            Discount = discount;
        }

        public void AddProduct(ProductModel product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(ProductModel product) 
        {
            Products.Remove(product);
        }

    }

}
