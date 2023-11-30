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
                if (AreNutriPointsEnough(order))
                {
                    return _dao.CreateOrder(order);
                }

                return false;
            }
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
            {
                throw;
            }
        }


        public bool AreNutriPointsEnough(Order order)
        {
            return _algorithmManager.AreNutriPointsEnough(order);
        }

        public double CalculateCartTotalPrice(Order order)
        {
            return _algorithmManager.CalculateCartTotalPrice(order);
        }
        
        public int CalculateCartNutriPoints(Order order)
        {
            return _algorithmManager.CalculateCartNutriPoints(order);  
        }
    }
}
