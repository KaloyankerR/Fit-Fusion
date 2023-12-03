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

                    string query = "INSERT INTO [Order] (OrderDate, CustomerId, TotalPrice, NutriPoints, Note) " +
                                              "VALUES (@OrderDate, @CustomerId, @TotalPrice, @NutriPoints, @Note);" +
                                              "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                        command.Parameters.AddWithValue("@CustomerId", order.Customer.Id);
                        command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                        AddNutriPointsToCustomer(order.Customer.Id, order.NutriPointsReward);
                        command.Parameters.AddWithValue("@NutriPoints", order.NutriPointsReward);
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
            catch (SqlException)
            {
                throw new ApplicationException("An error occurred in the database operation.");
            }
        }

        public bool AddNutriPointsToCustomer(int customerId, int pointsToAdd)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string addNutriPointsQuery = "UPDATE Customer SET NutriPoints = NutriPoints + @PointsToAdd WHERE Id = @CustomerId;";

                    using (SqlCommand updateCommand = new SqlCommand(addNutriPointsQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@PointsToAdd", pointsToAdd);
                        updateCommand.Parameters.AddWithValue("@CustomerId", customerId);

                        updateCommand.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (SqlException)
            {
                throw new ApplicationException("An error occurred in the database operation.");
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
                                int productId = reader.GetInt32(reader.GetOrdinal("Id"));
                                string title = reader.GetString(reader.GetOrdinal("Title"));
                                string description = reader.GetString(reader.GetOrdinal("Description"));
                                double price = (double)reader.GetDecimal(reader.GetOrdinal("Price"));
                                var productCategory = Enum.TryParse(reader.GetString("Category"), out Category category) ? category : default;
                                string imageUrl = reader.GetString("ImageUrl");

                                Product product = new Product(productId, title, description, price, productCategory, imageUrl);
                                int quantity = reader.GetInt16(reader.GetOrdinal("Quantity"));
                                cart.Add(product, quantity);
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new ApplicationException("An error occurred in the database operation.");
            }

            return cart;
        }

        public Order GetOrderById(int id)
        {
            Order order;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = $"SELECT Id, OrderDate, CustomerId, TotalPrice, NutriPoints, Note FROM [Order] WHERE Id = @Id;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                order = new Order
                                (
                                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                                    date: reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                    customer: new(id: reader.GetInt32(reader.GetOrdinal("CustomerId"))),
                                    cart: GetShoppingCart(id),
                                    totalPrice: (double)reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                                    nutriPointsReward: reader.GetInt32(reader.GetOrdinal("NutriPoints")),
                                    note: reader.GetString(reader.GetOrdinal("Note"))
                                );

                                return order;
                            }

                            throw new NullReferenceException("Order wasn't found.");
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new ApplicationException("An error occurred in the database operation.");
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

                    string getOrdersQuery = "SELECT Id, OrderDate, CustomerId, TotalPrice, NutriPoints, Note FROM [Order];";

                    using (SqlCommand command = new SqlCommand(getOrdersQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Order order = new Order
                                (
                                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                                    date: reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                    customer: new Customer(id: reader.GetInt32(reader.GetOrdinal("CustomerId"))),
                                    cart: GetShoppingCart(reader.GetInt32(reader.GetOrdinal("Id"))),
                                    totalPrice: (double)reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                                    nutriPointsReward: reader.GetInt32(reader.GetOrdinal("NutriPoints")),
                                    note: reader.GetString(reader.GetOrdinal("Note"))
                                );

                                orders.Add(order);
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new ApplicationException("An error occurred in the database operation.");
            }

            return orders;
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
                                nutriPoints = reader.GetInt32(reader.GetOrdinal("NutriPoints"));
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new ApplicationException("An error occurred in the database operation.");
            }

            return nutriPoints;
        }

    }
}
