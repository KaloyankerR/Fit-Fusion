using Models.Order;
using ProductModel = Models.Product.Product;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Data.SqlClient;
using Models.Product.Enums;

namespace FitFusionTest.MockDAO
{
    public class MockOrderDAO : IOrderDAO
    {
        private List<Order> ordersMock;
        private List<Customer> usersMock;

        public MockOrderDAO()
        {
            usersMock = new()
            {
                new Customer ( id: 1, firstName: "Alice", lastName: "Johnson", email: "alicejohnson@email.com",  passwordHash: "hash", passwordSalt: "salt", address: "Sofia", nutriPoints: 60),
                new Customer ( id: 2, firstName: "Bob", lastName: "Smith", email: "bobsmith@email.com", passwordHash: "hash", passwordSalt: "salt", address: "USA", nutriPoints: 15),
                new Customer ( id: 3, firstName: "John", lastName: "Doe", email: "johndoe@email.com", passwordHash: "hash", passwordSalt: "salt", address: "England", nutriPoints: 100)
            };

            var products = new List<ProductModel>
            {
                new ProductModel(id: 1, title: "Protein", description: null, price: 10, category: Category.Protein, imageUrl: null),
                new ProductModel(id: 2, title: "Vitamin B12", description: null, price: 15, category: Category.Vitamins, imageUrl: null),
                new ProductModel(id: 3, title: "Gym EZ Bar", description: null, price: 35, category: Category.Accessories, imageUrl: null),
                new ProductModel(id: 4, title: "Vegan Brownies", description: null, price: 5, category: Category.Vegan, imageUrl: null),
                new ProductModel(id: 5, title: "Healthy Chips", description: null, price: 5, category: Category.Snacks, imageUrl: null),
                new ProductModel(id: 6, title: "Gym Tank Top", description: null, price: 5, category: Category.Clothing, imageUrl: null),
                new ProductModel(id: 7, title: "Shaker Bottle", description: null, price: 10, category: Category.Redeem, imageUrl: null),
                new ProductModel(id: 8, title: "Gym Towel", description: null, price: 15, category: Category.Redeem, imageUrl: null),
                new ProductModel(id: 9, title: "Gym Bag", description: null, price: 50, category: Category.Redeem, imageUrl: null),
                new ProductModel(id: 10, title: "Olympic Bar", description: null, price: 20, category: Category.Redeem, imageUrl: null)
            };

            ShoppingCart firstCart = new();
            firstCart.AddToCart(products[0]);
            firstCart.AddToCart(products[3]);
            firstCart.AddToCart(products[8]);

            ShoppingCart secondCart = new();
            secondCart.AddToCart(products[1]);
            secondCart.AddToCart(products[2]);
            secondCart.AddToCart(products[9]);

            ordersMock = new List<Order>()
            {
                new Order
                (
                    id: 0,
                    date: DateTime.Now.AddDays(-2),
                    customer: usersMock[0],
                    cart: firstCart,
                    note: "Sample order 1"
                ),
                new Order
                (
                    id: 1,
                    date: DateTime.Now.AddDays(-1),
                    customer: usersMock[2],
                    cart: secondCart,
                    note: "Sample order 2"
                ),
            };
        }


        public bool CreateOrder(Order order)
        {
            ordersMock.Add(order);

            int index = usersMock.FindIndex(u => u.Id == order.Customer.Id);
            int newNutriPoints = order.Customer.NutriPoints + order.Cart.NutriPointsReward - order.Cart.NutriPointsNeeded;

            Customer newCustomer = new
                (
                    id: order.Customer.Id,
                    firstName: order.Customer.FirstName,
                    lastName: order.Customer.LastName,
                    email: order.Customer.Email,
                    passwordHash: order.Customer.PasswordHash,
                    passwordSalt: order.Customer.PasswordSalt,
                    address: order.Customer.Address,
                    nutriPoints: newNutriPoints
                );

            usersMock[index] = newCustomer;

            return true;
        }

        //private ShoppingCart GetShoppingCart(int id)
        //{
        //    Order order = orders.Find(o => o.Id == id)!;

        //    if (order == null)
        //    {
        //        throw new NullReferenceException("Shopping cart wasn't found!");
        //    }

        //    return order.Cart;
        //}

        public Order GetOrderById(int id)
        {
            //Order order = ordersMock.Find(o => o.Id == id)!;
            //if (order == null)
            //{
            //    throw new NullReferenceException("Order wasn't found.");
            //}
            //return order;

            return ordersMock.Find(o => o.Id == id) ?? throw new NullReferenceException("Order wasn't found.");
        }

        public List<Order> GetOrders()
        {
            return ordersMock;
        }

        //public int GetCustomerNutriPoints(int customerId)
        //{
        //    Order order = ordersMock.Find(o => o.Customer.Id == customerId)!;
        //    return order.Customer.NutriPoints;
        //}

        public Dictionary<int, Dictionary<ProductModel, int>> GetRecommendations(int customerId)
        {
            throw new NotImplementedException();
        }

        public ProductModel GetMerchantRecommendation(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool CreateMerchantRecommendation(int customerId, ProductModel newProduct)
        {
            throw new NotImplementedException();
        }
    }
}
