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


        public bool CreateOrder(Order order)
        {
            try
            {
                return _dao.CreateOrder(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Order GetOrderById(int id)
        {
            try
            {
                return _dao.GetOrderById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Order();
            }
        }

        public List<Order> GetOrders()
        {
            try
            {
                return _dao.GetOrders();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Order>();
            }
        }


        public bool AreNutriPointsEnough(Order order, Customer customer)
        {
            return _algorithmManager.AreNutriPointsEnough(order, customer);
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
