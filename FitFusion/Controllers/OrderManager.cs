﻿using Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Controllers
{
    public class OrderManager : IOrder
    {
        private readonly IOrder _dao;

        public OrderManager(IOrder dao)
        {
            _dao = dao;
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

        public Order GetOrder(int id)
        {
            try
            {
                return _dao.GetOrder(id);
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

    }
}
