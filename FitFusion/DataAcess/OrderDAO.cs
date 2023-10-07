using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public bool CreateOrder(Order order)
        {
            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    connection.Open();

            //    string createOrderQuery = "INSERT INTO Orders (Address, Note, ProductId, UserId) " +
            //                              "VALUES (@Address, @Note, @ProductId, @UserId);";

            //    using (SqlCommand command = new SqlCommand(createOrderQuery, connection))
            //    {
            //        command.Parameters.AddWithValue("@Address", order.Address);
            //        command.Parameters.AddWithValue("@Note", order.Note);
            //        command.Parameters.AddWithValue("@ProductId", order.ProductId);
            //        command.Parameters.AddWithValue("@UserId", order.UserId);

            //        command.ExecuteNonQuery();
            //    }

            //    return true;
            //}
        }


        public bool UpdateOrder(Order order) { return false; }

        public bool DeleteOrder(Order order) { return false; }

        public Order GetOrder(int id) {  return new Order(); }

        public List<Order> GetOrders() {  return new List<Order>(); }

    }
}
