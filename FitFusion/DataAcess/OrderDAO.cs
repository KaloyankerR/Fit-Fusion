using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Order;

namespace DataAcess
{
    public class OrderDAO
    {
        private string ConnectionString;

        public OrderDAO()
        {
            ConnectionString = Connection.DbConnection.ConnectionString;
        }

        public OrderDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public bool CreateOrder(Order order) { return false; }

        public bool UpdateOrder(Order order) { return false; }

        public bool DeleteOrder(Order order) { return false; }

        public Order GetOrder(int id) {  return new Order(); }

        public List<Order> GetOrders() {  return new List<Order>(); }

    }
}
