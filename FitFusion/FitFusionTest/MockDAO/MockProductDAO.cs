using Interfaces;
using Models.Order;
using Models.Product;
using Models.Product.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFusionTest.MockDAO
{
    public class MockProductDAO : IProductDAO
    {
        private List<Product> products;

        public MockProductDAO()
        {
            products = new List<Product>
            {
                new Product(id: 1, title: "Protein", description: null, price: 10, category: Category.Protein, imageUrl: null),
                new Product(id: 2, title: "Vitamin B12", description: null, price: 15, category: Category.Vitamins, imageUrl: null),
                new Product(id: 3, title: "Gym EZ Bar", description: null, price: 35, category: Category.Accessories, imageUrl: null),
                new Product(id: 4, title: "Vegan Brownies", description: null, price: 5, category: Category.Vegan, imageUrl: null),
                new Product(id: 5, title: "Healthy Chips", description: null, price: 5, category: Category.Snacks, imageUrl: null),
                new Product(id: 6, title: "Gym Tank Top", description: null, price: 5, category: Category.Clothing, imageUrl: null),
                new Product(id: 7, title: "Shaker Bottle", description: null, price: 10, category: Category.Redeem, imageUrl: null),
                new Product(id: 8, title: "Gym Towel", description: null, price: 15, category: Category.Redeem, imageUrl: null),
                new Product(id: 9, title: "Gym Bag", description: null, price: 50, category: Category.Redeem, imageUrl: null),
                new Product(id: 10, title: "Olympic Bar", description: null, price: 20, category: Category.Redeem, imageUrl: null)
            };

        }

        public bool CreateProduct(Product product)
        {
            // product.Id = products.Count + 1;
            products.Add(product);
            return true;
        }

        public bool UpdateProduct(Product product)
        {
            var productToUpdate = products.FirstOrDefault(p => p.Id == product.Id);

            if (productToUpdate != null)
            {
                products.Remove(productToUpdate);
                products.Add(productToUpdate);
                return true;
            }
            else
            {
                throw new NullReferenceException("Product wasn't found.");
            }
        }

        public bool DeleteProduct(int id)
        {
            var productToRemove = products.FirstOrDefault(p => p.Id == id);

            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                return true;
            }
            else
            {
                throw new NullReferenceException("Product wasn't found.");
            }
        }

        public Product GetProductById(int id)
        {
            Product product = products.Find(o => o.Id == id)!;

            if (product == null)
            {
                throw new NullReferenceException("Product wasn't found.");
            }

            return product;
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public Dictionary<string, int> GetTrendyProducts()
        {
            throw new NotImplementedException();
        }

        
    }
}
