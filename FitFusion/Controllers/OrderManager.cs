using Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models.User;
using Models.Product;

namespace Services
{
    public class OrderManager : IOrder
    {
        private readonly IOrder _dao;
        // private readonly IAlgorithm _algorithmManager;

        public OrderManager(IOrder dao)
        {
            _dao = dao;
            // _algorithmManager = algorithmManager;
        }

        public Dictionary<Product, int> ConvertListCartToDictionary(List<Product> cart)
        {
            return cart.GroupBy(item => new { item.Id })
                         .ToDictionary(group => group.First(), group => group.Count());
        }

        public Order SetupOrder(Customer customer, ShoppingCart cart)
        {
            Order order = new(DateTime.Now, customer, cart, "");
            return order;
        }

        //public Order SetupOrder(Customer customer, ShoppingCart cart)
        //{
        //    //Dictionary<Product, int> newCart = ConvertListCartToDictionary(cart);
        //    //double totalPrice = CalculateCartTotalPrice(newCart);
        //    //int nutriPointsReward = CalculateCartNutriPoints(newCart);

        //    Order order = new(DateTime.Now, customer, cart, "");
        //    return order;
        //}

        public bool CreateOrder(Order order)
        {
            try
            {
                if (order.Customer.NutriPoints >= order.Cart.NutriPointsNeeded)
                {
                    return _dao.CreateOrder(order);
                }

                throw new ArithmeticException("Nutri Points not sufficient.");
            }
            catch
            {
                throw;
            }
        }

        public Order GetOrderById(int id)
        {
            try
            {
                return _dao.GetOrderById(id);
            }
            catch
            {
                throw;
            }
        }

        public List<Order> GetOrders()
        {
            try
            {
                return _dao.GetOrders();
            }
            catch
            {
                throw;
            }
        }


        //public bool AreNutriPointsEnough(Order order)
        //{
        //    return _algorithmManager.AreNutriPointsEnough(order);
        //}
    
        public Dictionary<int, Dictionary<Product, int>> GetRecommendations(int customerId)
        {
            try
            {
                return _dao.GetRecommendations(customerId);
            }
            catch
            {
                throw;
            }
        }

        public Product GetMostTrendingProduct(int customerId)
        {
            // Dictionary<int, Dictionary<Product, int>> recommendations passing parameter
            Dictionary<int, Dictionary<Product, int>> recommendations = GetRecommendations(customerId);
            
            Dictionary<Product, int> totalQuantities = new Dictionary<Product, int>();
            Dictionary<Product, int> consistentProducts = new Dictionary<Product, int>();

            foreach (var monthRecommendation in recommendations.Values)
            {
                foreach (var kvp in monthRecommendation)
                {
                    Product product = kvp.Key;
                    int quantity = kvp.Value;

                    if (totalQuantities.ContainsKey(product))
                    {
                        totalQuantities[product] += quantity;
                    }
                    else
                    {
                        totalQuantities[product] = quantity;
                    }


                    if (consistentProducts.ContainsKey(product))
                    {
                        consistentProducts[product]++;
                    }
                    else
                    {
                        consistentProducts[product] = 1;
                    }

                }
            }

            foreach (var product in consistentProducts.Keys)
            {
                if (totalQuantities.ContainsKey(product))
                {
                    totalQuantities[product] += consistentProducts[product] * 2;
                }
                else
                {
                    totalQuantities[product] = consistentProducts[product] * 2;
                }
            }

            Product mostTrendingProduct = totalQuantities.OrderByDescending(kvp => kvp.Value).FirstOrDefault().Key;

            if (mostTrendingProduct != null)
            {
                return mostTrendingProduct;
            }

            throw new NullReferenceException("There are no products.");
        }

    }
}
