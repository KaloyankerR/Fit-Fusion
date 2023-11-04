using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Interfaces;
using Models.Order;
using Models.User;

namespace DataAcess
{
    public class OrderDAO : IOrderDAO
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

                    string createOrderQuery = "INSERT INTO [Order] (OrderDate, CustomerId, TotalPrice, Discount, Note) " +
                                              "VALUES (@OrderDate, @CustomerId, @TotalPrice, @Discount, @Note);" +
                                              "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(createOrderQuery, connection))
                    {
                        command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                        command.Parameters.AddWithValue("@CustomerId", order.Customer.Id);
                        command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                        command.Parameters.AddWithValue("@Discount", order.Discount);
                        command.Parameters.AddWithValue("@Note", order.Note);

                        int orderId = Convert.ToInt32(command.ExecuteScalar());

                        string insertShoppingCartQuery = "INSERT INTO ShoppingCart (OrderId, ProductId) " +
                                                         "VALUES (@OrderId, @ProductId);";

                        foreach (var product in order.ShoppingCart.Products)
                        {
                            using (SqlCommand cartCommand = new SqlCommand(insertShoppingCartQuery, connection))
                            {
                                cartCommand.Parameters.AddWithValue("@OrderId", orderId);
                                cartCommand.Parameters.AddWithValue("@ProductId", product.Id);

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

        public Order GetOrder(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string getOrderQuery = $"SELECT Id, OrderDate, CustomerId, TotalPrice, Discount, Note FROM [Order] WHERE Id = @Id;";

                    using (SqlCommand command = new SqlCommand(getOrderQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Order order = new Order
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                    Customer = new (id: reader.GetInt32(reader.GetOrdinal("CustomerId"))),
                                    TotalPrice = (double)reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                                    Discount = reader.GetInt32(reader.GetOrdinal("Discount")),
                                    Note = reader.IsDBNull(reader.GetOrdinal("Note")) ? null : reader.GetString(reader.GetOrdinal("Note"))
                                };

                                return order;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                Console.WriteLine($"Error retrieving order with ID {id}: {ex.Message}");
            }

            return null;
        }



        public List<Order> GetOrders() 
        {
            List<Order> orders = new List<Order>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string getOrdersQuery = "SELECT Id, OrderDate, CustomerId, TotalPrice, Discount, Note FROM [Order];";

                    using (SqlCommand command = new SqlCommand(getOrdersQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Order order = new Order
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                    Customer = new Customer (id: reader.GetInt32(reader.GetOrdinal("CustomerId"))),
                                    TotalPrice = (double)reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                                    Discount = reader.GetInt32(reader.GetOrdinal("Discount")),
                                    Note = reader.IsDBNull(reader.GetOrdinal("Note")) ? null : reader.GetString(reader.GetOrdinal("Note"))
                                };

                                orders.Add(order);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving orders: {ex.Message}");
            }

            return orders;

        }

    }
}
