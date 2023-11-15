using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models.Order;
using Models.User;
using Models.Product;
using System.Data;

namespace DataAcess
{
    public class OrderDAO : IOrder
    {
        private readonly string ConnectionString;

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
                        command.Parameters.AddWithValue("@Discount", GetCustomerNutriPoints(order.Customer.Id));
                        command.Parameters.AddWithValue("@Note", order.Note);

                        int orderId = Convert.ToInt32(command.ExecuteScalar());

                        string insertShoppingCartQuery = "INSERT INTO ShoppingCart (OrderId, ProductId, Quantity) " +
                                                         "VALUES (@OrderId, @ProductId, @Quantity);";

                        foreach (var pair in order.Cart)
                        {
                            Product product = pair.Key;
                            int quantity = pair.Value;

                            using (SqlCommand cartCommand = new SqlCommand(insertShoppingCartQuery, connection))
                            {
                                cartCommand.Parameters.AddWithValue("@OrderId", orderId);
                                cartCommand.Parameters.AddWithValue("@ProductId", product.Id);
                                cartCommand.Parameters.AddWithValue("@Quantity", quantity);

                                cartCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public Dictionary<Product, int> GetShoppingCart(int id)
        {
            Dictionary<Product, int> cart = new();

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

                                int quantity = reader.GetInt16(reader.GetOrdinal("Quantity"));
                                cart.Add(product, quantity);

                                // shoppingCart.AddProduct(product);
                            }
                        }

                        return cart;
                    }
                }
            }
            catch
            {
                return cart;
            }
        }

        public Order GetOrderById(int id)
        {
            Order order = new();
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
                                order = new Order
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                    Customer = new(id: reader.GetInt32(reader.GetOrdinal("CustomerId"))),
                                    Cart = GetShoppingCart(id),
                                    TotalPrice = (double)reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                                    NutriPointsReward = reader.GetInt32(reader.GetOrdinal("Discount")),
                                    Note = reader.GetString(reader.GetOrdinal("Note"))
                                };
                            }

                            return order;
                        }
                    }
                }
            }
            catch
            {
                return order;
            }
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = new();

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
                                    Cart = GetShoppingCart(reader.GetInt32(reader.GetOrdinal("Id"))),
                                    TotalPrice = (double)reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                                    NutriPointsReward = reader.GetInt32(reader.GetOrdinal("Discount")),
                                    Note = reader.GetString(reader.GetOrdinal("Note"))
                                };

                                orders.Add(order);
                            }

                            return orders;
                        }
                    }
                }
            }
            catch
            {
                return orders;
            }
        }

        public int GetCustomerNutriPoints(int customerId)
        {
            int nutriPoints = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = $"SELECT * FROM Customer WHERE Id=@Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", customerId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nutriPoints = reader.GetInt32(reader.GetOrdinal("LoyaltyScore"));
                            }

                            return nutriPoints;
                        }
                    }
                }
            }
            catch
            {
                return nutriPoints;
            }

        }

    }
}
