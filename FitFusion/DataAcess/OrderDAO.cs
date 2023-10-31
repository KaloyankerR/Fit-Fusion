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
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string createOrderQuery = "INSERT INTO [Order] (OrderDate, CustomerId, Note) " +
                                              "VALUES (@OrderDate, @CustomerId, @Note);" +
                                              "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(createOrderQuery, connection))
                    {
                        command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                        command.Parameters.AddWithValue("@CustomerId", order.Customer.Id);
                        command.Parameters.AddWithValue("@Note", order.Note);

                        int orderId = Convert.ToInt32(command.ExecuteScalar());

                        string insertShoppingCartQuery = "INSERT INTO ShoppingCart (OrderId, ProductId, Discount) " +
                                                         "VALUES (@OrderId, @ProductId, @Discount);";

                        foreach (var product in order.ShoppingCart.Products)
                        {
                            using (SqlCommand cartCommand = new SqlCommand(insertShoppingCartQuery, connection))
                            {
                                cartCommand.Parameters.AddWithValue("@OrderId", orderId);
                                cartCommand.Parameters.AddWithValue("@ProductId", product.Id);
                                cartCommand.Parameters.AddWithValue("@Discount", order.ShoppingCart.Discount);

                                cartCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating order: {ex.Message}");
                return false;
            }
        }


        public bool UpdateOrder(Order order) { return false; }

        public bool DeleteOrder(Order order) { return false; }

        public Order GetOrder(int id) {  return new Order(); }

        public List<Order> GetOrders() {  return new List<Order>(); }

    }
}
