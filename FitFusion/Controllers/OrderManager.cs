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

        public double CalculateCartTotalPrice(Dictionary<Product, int> cart)
        {
            double totalPrice = 0;

            foreach (var pair in cart)
            {
                Product product = pair.Key;
                int quantity = pair.Value;

                if (product.Category != Category.Redeem)
                {
                    totalPrice += (product.Price * quantity);
                }
            }

            return totalPrice;
        }

        public int CalculateNutriPointsInCart(Dictionary<Product, int> cart)
        {
            int nutriPointsGained = 0;

            foreach (var pair in cart)
            {
                Product product = pair.Key;
                int quantity = pair.Value;

                switch (product.Category)
                {
                    case Category.Protein:
                        nutriPointsGained+= 30;
                        break;
                    case Category.Supplements:
                        nutriPointsGained += 30;
                        break;
                    default:
                        nutriPointsGained+= 10;
                        break;
                }

                if (quantity > 1) 
                {
                    nutriPointsGained += 20 * quantity;
                }

            }

            return nutriPointsGained;
        }

        public bool AreNutriPointsEnough(Order order, Customer customer)
        {
            int nutriPointsNeeded = 0;

            foreach (var pair in order.Cart)
            {
                Product product = pair.Key;
                int quantity = pair.Value;

                if (product.Category == Category.Redeem)
                {
                    nutriPointsNeeded += Convert.ToInt32(product.Price) * quantity;
                }
            }

            return nutriPointsNeeded <= customer.NutriPoints;
        }

    }
}
