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

        public bool CreateProduct(Product product)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand productCommand = new SqlCommand("INSERT INTO Product (Title, Description, Category, ImageUrl) VALUES (@Title, @Description, @Category, @ImageUrl); SELECT SCOPE_IDENTITY();", connection))
                    {
                        productCommand.Parameters.AddWithValue("@Title", product.Title);
                        productCommand.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                        productCommand.Parameters.AddWithValue("@Category", product.Category);
                        productCommand.Parameters.AddWithValue("@ImageUrl", product.ImageUrl ?? (object)DBNull.Value);

                        int productId = Convert.ToInt32(productCommand.ExecuteScalar());

                        foreach (var hashtag in product.Hahstags)
                        {
                            using (SqlCommand hashtagCommand = new SqlCommand("INSERT INTO ProductHashtag (ProductId, Tag) VALUES (@ProductId, @Tag);", connection))
                            {
                                hashtagCommand.Parameters.AddWithValue("@ProductId", productId);
                                hashtagCommand.Parameters.AddWithValue("@Tag", hashtag);
                                hashtagCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex) 
            {
                // throw new Exception(ex);
                return false;
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
                                    category: (Category)reader.GetInt32("Category"),
                                    hahstags: hashtagsToAdd,
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
                        // Assuming there's a Hashtag enum
                        if (Enum.TryParse(reader.GetString("Tag"), out Hashtag hashtag))
                        {
                            hashtags.Add(hashtag);
                        }
                    }
                }
            }

            return hashtags;
        }


        //public Product GetProductById(int productId)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(ConnectionString))
        //        {
        //            connection.Open();

        //            using (SqlCommand getProductCommand = new SqlCommand("SELECT p.*, ph.Tag FROM Product p LEFT JOIN ProductHashtag ph ON p.Id = ph.ProductId WHERE p.Id = @ProductId", connection))
        //            {
        //                getProductCommand.Parameters.AddWithValue("@ProductId", productId);

        //                using (SqlDataReader reader = getProductCommand.ExecuteReader())
        //                {
        //                    Product product = null;

        //                    while (reader.Read())
        //                    {
        //                        if (product == null)
        //                        {
        //                            // Create a Product instance for the first row
        //                            product = new Product
        //                            (
        //                                id: reader.GetInt32("Id"),
        //                                title: reader.GetString("Title"),
        //                                description: reader.IsDBNull("Description") ? null : reader.GetString(reader.GetOrdinal("Description")),
        //                                category: (Category)reader.GetInt32("Category"),
        //                                hahstags: new List<Hashtag>(),
        //                                imageUrl: reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : reader.GetString("ImageUrl")
        //                            );
        //                        }

        //                        // Add hashtags to the product
        //                        if (!reader.IsDBNull(reader.GetOrdinal("Tag")))
        //                        {
        //                            // Assuming there's a Hashtag enum
        //                            if (Enum.TryParse(reader.GetString(reader.GetOrdinal("Tag")), out Hashtag hashtag))
        //                            {
        //                                product.Hahstags.Add(hashtag);
        //                            }
        //                        }
        //                    }

        //                    return product;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred while getting the product: {ex.Message}");
        //        throw;
        //    }
        //}


    }

}
