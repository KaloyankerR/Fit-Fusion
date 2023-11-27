using Models.Order;
using ProductModel = Models.Product.Product;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Product;
using Interfaces;

namespace FitFusionTest.MockDAO
{
    public class MockOrderDAO : IOrder
    {
        private readonly List<Order> orders;

        public MockOrderDAO()
        {
            orders = new List<Order>()
            {
                new Order
                {
                    Id = 1,
                    OrderDate = DateTime.Now.AddDays(-2),
                    Customer = new Customer { Id = 101, FirstName = "Alice", LastName = "Johnson" },
                    Cart = new Dictionary<ProductModel, int>
                    {
                        { new ProductModel { Id = 201, Title = "Product1", Price = 10.99 }, 2 },
                        { new ProductModel { Id = 202, Title = "Product2", Price = 15.99 }, 1 }
                    },
                    TotalPrice = 37.97,
                    NutriPointsReward = 20,
                    Note = "Sample order 1"
                },
                new Order
                {
                    Id = 2,
                    OrderDate = DateTime.Now.AddDays(-5),
                    Customer = new Customer { Id = 102, FirstName = "Bob", LastName = "Smith" },
                    Cart = new Dictionary<ProductModel, int>
                    {
                        { new ProductModel { Id = 203, Title = "Product3", Price = 8.50 }, 3 },
                        { new ProductModel { Id = 204, Title = "Product4", Price = 12.75 }, 1 }
                    },
                    TotalPrice = 44.25,
                    NutriPointsReward = 15,
                    Note = "Sample order 2"
                }
            };

        }

        public bool CreateOrder(Order order)
        {
            order.Id = orders.Count + 1;
            orders.Add(order);
            return true;
        }

        public Dictionary<ProductModel, int> GetShoppingCart(int id)
        {
            Order order = orders.Find(o => o.Id == id);
            return order?.Cart ?? new Dictionary<ProductModel, int>();
        }

        public Order GetOrderById(int id)
        {
            return orders.Find(o => o.Id == id) ?? new Order();
        }

        public List<Order> GetOrders()
        {
            return orders;
        }

        public int GetCustomerNutriPoints(int customerId)
        {
            return 50;
        }

    }
}
