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
    public class OrderManager : IOrder, IAlgorithm
    {
        private readonly IOrder _dao;
        private readonly IAlgorithm _algorithmManager;

        public OrderManager(IOrder dao, IAlgorithm algorithmManager)
        {
            _dao = dao;
            _algorithmManager = algorithmManager;
        }

        public Dictionary<Product, int> ConvertListCartToDictionary(List<Product> cart)
        {
            return cart.GroupBy(item => new { item.Id })
                         .ToDictionary(group => group.First(), group => group.Count());
        }

        public Order SetupOrder(Customer customer, Dictionary<Product, int> cart)
        {
            double totalPrice = CalculateCartTotalPrice(cart);
            int nutriPointsReward = CalculateCartNutriPoints(cart);

            Order order = new(DateTime.Now, customer, cart, totalPrice, nutriPointsReward, "");
            return order;
        }

        public Order SetupOrder(Customer customer, List<Product> cart)
        {
            Dictionary<Product, int> newCart = ConvertListCartToDictionary(cart);
            double totalPrice = CalculateCartTotalPrice(newCart);
            int nutriPointsReward = CalculateCartNutriPoints(newCart);

            Order order = new(DateTime.Now, customer, newCart, totalPrice, nutriPointsReward, "");
            return order;
        }

        public bool CreateOrder(Order order)
        {
            try
            {
                if (AreNutriPointsEnough(order))
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


        public bool AreNutriPointsEnough(Order order)
        {
            return _algorithmManager.AreNutriPointsEnough(order);
        }

        public double CalculateCartTotalPrice(Dictionary<Product, int> cart)
        {
            return _algorithmManager.CalculateCartTotalPrice(cart);
        }
        
        public int CalculateCartNutriPoints(Dictionary<Product, int> cart)
        {
            return _algorithmManager.CalculateCartNutriPoints(cart);  
        }
    }
}
