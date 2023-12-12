//using Interfaces;
//using Models.Order;
//using Models.Product;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FitFusionTest.MockDAO
//{
//    public class MockProductDAO : IProduct
//    {
//        private List<Product> products;

//        public MockProductDAO()
//        {
//            products = new List<Product>
//            {
//                new Product { Id = 1, Title = "Protein", Price = 10, Category = Category.Protein },
//                new Product { Id = 2, Title = "Vitamin B12", Price = 15, Category = Category.Vitamins },
//                new Product { Id = 3, Title = "Gym EZ Bar", Price = 35, Category = Category.Accessories },
//                new Product { Id = 4, Title = "Vegan Brownies", Price = 5, Category = Category.Vegan },
//                new Product { Id = 5, Title = "Healthy Chips", Price = 5, Category = Category.Snacks },
//                new Product { Id = 6, Title = "Gym Tank Top", Price = 5, Category = Category.Clothing },
//                new Product { Id = 7, Title = "Shaker Bottle", Price = 10, Category = Category.Redeem },
//                new Product { Id = 8, Title = "Gym Towel", Price = 15, Category = Category.Redeem },
//                new Product { Id = 9, Title = "Gym Bag", Price = 50, Category = Category.Redeem },
//                new Product { Id = 10, Title = "Olympic Bar", Price = 20, Category = Category.Redeem }
//            };
//        }

//        public bool CreateProduct(Product product)
//        {
//            product.Id = products.Count + 1;
//            products.Add(product);
//            return true;
//        }

//        public bool DeleteProduct(int id)
//        {
//            var productToRemove = products.FirstOrDefault(p => p.Id == id);

//            if (productToRemove != null)
//            {
//                products.Remove(productToRemove);
//                return true;
//            }

//            return false;
//        }

//        public Product GetProductById(int id)
//        {
//            Product product = products.Find(o => o.Id == id)!;

//            if (product == null)
//            {
//                throw new InvalidOperationException("Product wasn't found!");
//            }

//            return product;
//        }

//        public List<Product> GetProducts()
//        {
//            return products;
//        }

//        public Dictionary<string, int> GetTrendyProducts()
//        {
//            throw new NotImplementedException();
//        }

//        public bool UpdateProduct(Product updatedProduct)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
