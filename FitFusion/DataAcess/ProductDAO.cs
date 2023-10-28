using Models.Product;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void CreateProduct(Product product)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
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

                        foreach (var hashtag in product.Hashtags)
                        {
                            using (SqlCommand hashtagCommand = new SqlCommand("INSERT INTO ProductHashtag (ProductId, Tag) VALUES (@ProductId, @Tag);", connection))
                            {
                                hashtagCommand.Parameters.AddWithValue("@ProductId", productId);
                                hashtagCommand.Parameters.AddWithValue("@Tag", hashtag.ToString());
                                hashtagCommand.ExecuteNonQuery();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateProduct(Product updatedProduct)
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

                    using (SqlCommand deleteHashtagsCommand = new SqlCommand("DELETE FROM ProductHashtag WHERE ProductId = @ProductId", connection))
                    {
                        deleteHashtagsCommand.Parameters.AddWithValue("@ProductId", updatedProduct.Id);
                        deleteHashtagsCommand.ExecuteNonQuery();
                    }

                    foreach (var hashtag in updatedProduct.Hashtags)
                    {
                        using (SqlCommand hashtagCommand = new SqlCommand("INSERT INTO ProductHashtag (ProductId, Tag) VALUES (@ProductId, @Tag);", connection))
                        {
                            hashtagCommand.Parameters.AddWithValue("@ProductId", updatedProduct.Id);
                            hashtagCommand.Parameters.AddWithValue("@Tag", hashtag.ToString());
                            hashtagCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteProduct(int productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand deleteHashtagsCommand = new SqlCommand("DELETE FROM ProductHashtag WHERE ProductId = @ProductId", connection))
                    {
                        deleteHashtagsCommand.Parameters.AddWithValue("@ProductId", productId);
                        deleteHashtagsCommand.ExecuteNonQuery();
                    }

                    using (SqlCommand deleteProductCommand = new SqlCommand("DELETE FROM Product WHERE Id = @ProductId", connection))
                    {
                        deleteProductCommand.Parameters.AddWithValue("@ProductId", productId);
                        deleteProductCommand.ExecuteNonQuery();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Product GetProductById(int productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand getProductCommand = new SqlCommand("SELECT * FROM Product WHERE Id = @ProductId", connection))
                    {
                        getProductCommand.Parameters.AddWithValue("@ProductId", productId);

                        List<Hashtag> hashtagsToAdd = GetHashtagsForProduct(connection, productId);

                        using (SqlDataReader reader = getProductCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Product product = new Product
                                (
                                    id: reader.GetInt32("Id"),
                                    title: reader.GetString("Title"),
                                    description: reader.IsDBNull("Description") ? null : reader.GetString("Description"),
                                    price: (double)reader.GetDecimal(reader.GetOrdinal("Price")),
                                    category: Enum.TryParse(reader.GetString("Category"), out Category category) ? category : default(Category),
                                    hashtags: hashtagsToAdd,
                                    imageUrl: reader.IsDBNull("ImageUrl") ? null : reader.GetString("ImageUrl")
                                );

                                return product;
                            }
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting the product: {ex.Message}");

                throw;
            }
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                List<Product> products = new List<Product>();

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

                                List<Hashtag> hashtagsToAdd = GetHashtagsForProduct(connection, productId);

                                Product product = new Product
                                (
                                    id: productId,
                                    title: reader.GetString("Title"),
                                    description: reader.IsDBNull("Description") ? null : reader.GetString("Description"),
                                    price: (double)reader.GetDecimal(reader.GetOrdinal("Price")),
                                    category: Enum.TryParse(reader.GetString("Category"), out Category category) ? category : default(Category),
                                    hashtags: hashtagsToAdd,
                                    imageUrl: reader.IsDBNull("ImageUrl") ? null : reader.GetString("ImageUrl")
                                );

                                products.Add(product);
                            }
                        }
                    }
                }

                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting all products: {ex.Message}");

                throw;
            }
        }

        private List<Hashtag> GetHashtagsForProduct(SqlConnection connection, int productId)
        {
            List<Hashtag> hashtags = new List<Hashtag>();

            using (SqlCommand getHashtagsCommand = new SqlCommand("SELECT Tag FROM ProductHashtag WHERE ProductId = @ProductId", connection))
            {
                getHashtagsCommand.Parameters.AddWithValue("@ProductId", productId);

                using (SqlDataReader reader = getHashtagsCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Enum.TryParse(reader.GetString("Tag"), out Hashtag hashtag))
                        {
                            hashtags.Add(hashtag);
                        }
                    }
                }
            }

            return hashtags;
        }

    }

}
