using Models.Product;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess
{
    public class ProductDAO
    {
        private string ConnectionString;

        public ProductDAO()
        {
            ConnectionString = Connection.DbConnection.ConnectionString;
        }

        public ProductDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public bool CreateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertProductQuery = "INSERT INTO Product (Title, Description, Category, ImageUrl) " +
                                                    "VALUES(@Title, @Description, @Category, @ImageUrl);";

                        using (SqlCommand command = new SqlCommand(insertProductQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Title", product.Title);
                            command.Parameters.AddWithValue("@Description", product.Description);
                            command.Parameters.AddWithValue("@Category", product.ProductCategory.ToString());
                            command.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool UpdateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updateProductQuery = "UPDATE Product SET Title = @Title, " +
                                                    "Description = @Description, " +
                                                    "Category = @Category, " +
                                                    "ImageUrl = @ImageUrl " +
                                                    "WHERE Id = @Id;";

                        using (SqlCommand command = new SqlCommand(updateProductQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Title", product.Title);
                            command.Parameters.AddWithValue("@Description", product.Description);
                            command.Parameters.AddWithValue("@Category", product.ProductCategory.ToString());
                            command.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);
                            command.Parameters.AddWithValue("@Id", product.Id);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool DeleteProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deleteProductQuery = "DELETE FROM Product WHERE Id = @Id;";

                        using (SqlCommand command = new SqlCommand(deleteProductQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", product.Id);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public Product GetProductById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string getProductQuery = "SELECT Id, Title, Description, Category, ImageUrl FROM Product WHERE Id = @Id;";

                using (SqlCommand command = new SqlCommand(getProductQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Map the data from the database to the Product object
                            return new Product
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                ProductCategory = new Category(1, reader.GetString(reader.GetOrdinal("Category"))), // Adjust based on your Category class
                                ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"))
                            };
                        }
                    }
                }

                // If the product with the specified ID is not found, return null or throw an exception based on your requirements.
                return null;
            }
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string getAllProductsQuery = "SELECT Id, Title, Description, Category, ImageUrl FROM Product;";

                using (SqlCommand command = new SqlCommand(getAllProductsQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Map each row from the database to a Product object
                            Product product = new Product
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                ProductCategory = new Category(1, reader.GetString(reader.GetOrdinal("Category"))), // Adjust based on your Category class
                                ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"))
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
    }

}
