using Models.Product;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DataAcess
{
    public class ProductDAO : IProduct
    {
        private readonly string ConnectionString;

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
            try
            {
                using (SqlConnection connection = new(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand productCommand = new SqlCommand("INSERT INTO Product (Title, Description, Price, Category, ImageUrl) VALUES (@Title, @Description, @Price, @Category, @ImageUrl); SELECT SCOPE_IDENTITY();", connection))
                    {
                        productCommand.Parameters.AddWithValue("@Title", product.Title);
                        productCommand.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                        productCommand.Parameters.AddWithValue("@Price", product.Price);
                        productCommand.Parameters.AddWithValue("@Category", product.Category.ToString());
                        productCommand.Parameters.AddWithValue("@ImageUrl", product.ImageUrl ?? (object)DBNull.Value);

                        int productId = Convert.ToInt32(productCommand.ExecuteScalar());
                    }
                }

                // throw new DuplicateNameException("Product already exists.");
            }
            catch (SqlException)
            {
                throw new ApplicationException("An error occurred in the database operation.");
            }

            return true;
        }

        public bool UpdateProduct(Product updatedProduct)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand updateProductCommand = new SqlCommand("UPDATE Product SET Title = @Title, Description = @Description, Price = @Price, Category = @Category, ImageUrl = @ImageUrl WHERE Id = @ProductId", connection))
                    {
                        updateProductCommand.Parameters.AddWithValue("@ProductId", updatedProduct.Id);
                        updateProductCommand.Parameters.AddWithValue("@Title", updatedProduct.Title);
                        updateProductCommand.Parameters.AddWithValue("@Description", updatedProduct.Description ?? (object)DBNull.Value);
                        updateProductCommand.Parameters.AddWithValue("@Price", updatedProduct.Price);
                        updateProductCommand.Parameters.AddWithValue("@Category", updatedProduct.Category.ToString());
                        updateProductCommand.Parameters.AddWithValue("@ImageUrl", updatedProduct.ImageUrl ?? (object)DBNull.Value);

                        updateProductCommand.ExecuteNonQuery();
                    }
                }

                // throw new NullReferenceException("Product wasn't found.");
            }
            catch (SqlException)
            {
                throw new ApplicationException("An error occurred in the database operation.");
            }

            return true;
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand deleteProductCommand = new SqlCommand("DELETE FROM Product WHERE Id = @ProductId", connection))
                    {
                        deleteProductCommand.Parameters.AddWithValue("@ProductId", productId);
                        deleteProductCommand.ExecuteNonQuery();
                    }
                }

                // throw new NullReferenceException("Product wasn't exist.");
            }
            catch (SqlException)
            {
                throw new ApplicationException("An error occurred in the database operation.");
            }

            return true;
        }

        public Product GetProductById(int productId)
        {
            Product product;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand getProductCommand = new("SELECT * FROM Product WHERE Id = @ProductId", connection))
                    {
                        getProductCommand.Parameters.AddWithValue("@ProductId", productId);

                        using (SqlDataReader reader = getProductCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                product = new Product
                                (
                                    id: reader.GetInt32("Id"),
                                    title: reader.GetString("Title"),
                                    description: reader.GetString("Description"),
                                    price: (double)reader.GetDecimal(reader.GetOrdinal("Price")),
                                    category: Enum.TryParse(reader.GetString("Category"), out Category category) ? category : default(Category),
                                    imageUrl: reader.GetString("ImageUrl")
                                );
                            }
                            else
                            {
                                throw new NullReferenceException("Product wasn't found.");
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new ApplicationException("An error occurred in the database operation.");
            }

            return product;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand getAllProductsCommand = new SqlCommand("SELECT * FROM Product", connection))
                    {
                        using (SqlDataReader reader = getAllProductsCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int productId = reader.GetInt32("Id");

                                Product product = new
                                (
                                    id: productId,
                                    title: reader.GetString("Title"),
                                    description: reader.GetString("Description"),
                                    price: (double)reader.GetDecimal(reader.GetOrdinal("Price")),
                                    category: Enum.TryParse(reader.GetString("Category"), out Category category) ? category : default(Category),
                                    imageUrl: reader.GetString("ImageUrl")
                                );

                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new ApplicationException("An error occurred in the database operation.");
            }

            return products;
        }

        public Dictionary<string, int> GetTrendyProducts()
        {
            Dictionary<string, int> products = new();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand getAllProductsCommand = new SqlCommand("SELECT p.Id, p.Title, p.Description, p.Price, p.Category, p.ImageUrl, COUNT(sc.ProductId) AS TimesOrdered FROM Product p JOIN ShoppingCart sc ON p.Id = sc.ProductId GROUP BY p.Id, p.Title, p.Description, p.Price, p.Category, p.ImageUrl ORDER BY TimesOrdered DESC;", connection))
                    {
                        using (SqlDataReader reader = getAllProductsCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int productId = reader.GetInt32("Id");

                                string name = reader.GetString("Title");
                                int count = reader.GetInt32("TimesOrdered");

                                products.Add(name, count);
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new ApplicationException("An error occurred in the database operation.");
            }

            return products;
        }

    }

}
