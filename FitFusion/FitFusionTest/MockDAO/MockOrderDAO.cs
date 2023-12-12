//using Models.Order;
//using ProductModel = Models.Product.Product;
//using Models.User;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Models.Product;
//using Interfaces;
//using System.Data.SqlClient;

//namespace FitFusionTest.MockDAO
//{
//    public class MockOrderDAO : IOrder
//    {
//        private List<Order> orders;

//        public MockOrderDAO()
//        {
//            var users = new List<Customer>
//            {
//                new Customer { Id = 1, FirstName = "Alice", LastName = "Johnson", Address="Sofia", NutriPoints = 60 },
//                new Customer { Id = 2, FirstName = "Bob", LastName = "Smith", NutriPoints = 15 },
//                new Customer { Id = 3, FirstName = "John", LastName = "Doe", NutriPoints = 100 }
//            };

//            var products = new List<ProductModel>
//            {
//                new ProductModel { Id = 1, Title = "Protein", Price = 10, Category = Category.Protein },
//                new ProductModel { Id = 2, Title = "Vitamin B12", Price = 15, Category = Category.Vitamins },
//                new ProductModel { Id = 3, Title = "Gym EZ Bar", Price = 35, Category = Category.Accessories },
//                new ProductModel { Id = 4, Title = "Vegan Brownies", Price = 5, Category = Category.Vegan },
//                new ProductModel { Id = 5, Title = "Healthy Chips", Price = 5, Category = Category.Snacks },
//                new ProductModel { Id = 6, Title = "Gym Tank Top", Price = 5, Category = Category.Clothing },
//                new ProductModel { Id = 7, Title = "Shaker Bottle", Price = 10, Category = Category.Redeem },
//                new ProductModel { Id = 8, Title = "Gym Towel", Price = 15, Category = Category.Redeem },
//                new ProductModel { Id = 9, Title = "Gym Bag", Price = 50, Category = Category.Redeem },
//                new ProductModel { Id = 10, Title = "Olympic Bar", Price = 20, Category = Category.Redeem }
//            };

//            orders = new List<Order>()
//            {
//                new Order
//                {
//                    Id = 1,
//                    OrderDate = DateTime.Now.AddDays(-2),
//                    Customer = users[0],
//                    Cart = new Dictionary<ProductModel, int>
//                    {
//                        { products[0], 2 },
//                        { products[1], 1 }
//                    },
//                    TotalPrice = 35,
//                    NutriPointsReward = 20,
//                    Note = "Sample order 1"
//                },
//                new Order
//                {
//                    Id = 2,
//                    OrderDate = DateTime.Now.AddDays(-5),
//                    Customer = users[1],
//                    Cart = new Dictionary<ProductModel, int>
//                    {
//                        { products[2], 3 },
//                        { products[3], 1 }
//                    },
//                    TotalPrice = 44.25,
//                    NutriPointsReward = 15,
//                    Note = "Sample order 2"
//                },
//                new Order
//                {
//                    Id = 3,
//                    OrderDate = DateTime.Now,
//                    Customer = users[2],
//                    Cart = new Dictionary<ProductModel, int>
//                    {
//                        { products[0], 2 },
//                        { products[1], 1 }
//                    },
//                    TotalPrice = 35,
//                    NutriPointsReward = 20,
//                    Note = "Sample order"
//                },
//                new Order
//                {
//                    Id = 4,
//                    OrderDate = System.DateTime.Now,
//                    Customer = users[2],
//                    Cart = new Dictionary<ProductModel, int>
//                    {
//                        { products[6], 2 },
//                        { products[7], 1 }
//                    },
//                    TotalPrice = 0,
//                    NutriPointsReward = 20,
//                    Note = "Nutri points should be enough"
//                },
//                new Order
//                {
//                    Id = 5,
//                    OrderDate = System.DateTime.Now,
//                    Customer = users[2],
//                    Cart = new Dictionary<Product, int>
//                    {
//                        { products[8], 2 },
//                        { products[9], 1 }
//                    },
//                    TotalPrice = 37.97,
//                    NutriPointsReward = 20,
//                    Note = "Nutri points shouldn't be enough"
//                }
//                //new Order
//                //{
//                //    Id= 6,
//                //    OrderDate = System.DateTime.Now,
//                //    Customer = new Customer { Id = 1,}
//                //}

//        };

//        }

//        public bool CreateOrder(Order order)
//        {
//            order.Id = orders.Count + 1;
//            orders.Add(order);
//            return true;
//        }

//        public Dictionary<ProductModel, int> GetShoppingCart(int id)
//        {
//            Order order = orders.Find(o => o.Id == id)!;

//            if (order == null)
//            {
//                throw new InvalidOperationException("Shopping cart wasn't found!");
//            }

//            return order.Cart;
//        }

//        public Order GetOrderById(int id)
//        {
//            Order order = orders.Find(o => o.Id == id)!;

//            if (order == null)
//            {
//                throw new InvalidOperationException("Shopping cart wasn't found!");
//            }

//            return order;
//        }

//        public List<Order> GetOrders()
//        {
//            return orders;
//        }

//        public int GetCustomerNutriPoints(int customerId)
//        {
//            return 50;
//        }

//    }
//}
