using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Interfaces;
using Models.Order;
using Models.User;
using Models.Product;
using System.Data;

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

                    string query = "INSERT INTO [Order] (OrderDate, CustomerId, TotalPrice, Discount, Note) " +
                                              "VALUES (@OrderDate, @CustomerId, @TotalPrice, @Discount, @Note);" +
                                              "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
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
                throw new Exception("Failed to create the new order.", ex);
                // return false;
            }
        }

        public ShoppingCart GetShoppingCart(int id)
        {
            ShoppingCart shoppingCart = new ShoppingCart();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = $"SELECT * FROM ShoppingCart s JOIN Product p ON s.ProductId = p.Id WHERE s.OrderId = @Id;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Title = reader.GetString(reader.GetOrdinal("Title")),
                                    Description = reader.GetString(reader.GetOrdinal("Description")),
                                    Price = (double)reader.GetDecimal(reader.GetOrdinal("Price")),
                                    Category = Enum.TryParse(reader.GetString("Category"), out Category category) ? category : default(Category),
                                    ImageUrl = reader.GetString("ImageUrl")
                                };

                                shoppingCart.AddProduct(product);
                            }
                        }

                        return shoppingCart;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve the shopping cart.", ex);
            }
        }

        public Order GetOrder(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = $"SELECT Id, OrderDate, CustomerId, TotalPrice, Discount, Note FROM [Order] WHERE Id = @Id;";

                    using (SqlCommand command = new SqlCommand(query, connection))
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
                                    ShoppingCart = GetShoppingCart(id),
                                    TotalPrice = (double)reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                                    Discount = reader.GetInt32(reader.GetOrdinal("Discount")),
                                    Note = reader.GetString(reader.GetOrdinal("Note"))
                                };

                                return order;
                            } 
                            else
                            {
                                throw new InvalidOperationException("No objects found.");
                            }

                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve the current order.", ex);
            }
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
                                    Customer = new Customer(id: reader.GetInt32(reader.GetOrdinal("CustomerId"))),
                                    ShoppingCart = GetShoppingCart(reader.GetInt32(reader.GetOrdinal("Id"))),
                                    TotalPrice = (double)reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                                    Discount = reader.GetInt32(reader.GetOrdinal("Discount")),
                                    Note = reader.GetString(reader.GetOrdinal("Note"))
                                };

                                orders.Add(order);
                            }

                            return orders;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve all orders.", ex);
            }
        }
    
    }
}
