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

                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create product.", ex);
                // return false;
            }
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

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update product.", ex);
                // return fale;
            }
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

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete product.", ex);
                // return false;
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

                        using (SqlDataReader reader = getProductCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Product product = new Product
                                (
                                    id: reader.GetInt32("Id"),
                                    title: reader.GetString("Title"),
                                    description: reader.GetString("Description"),
                                    price: (double)reader.GetDecimal(reader.GetOrdinal("Price")),
                                    category: Enum.TryParse(reader.GetString("Category"), out Category category) ? category : default(Category),
                                    imageUrl: reader.GetString("ImageUrl")
                                );

                                return product;
                            }
                            else
                            {
                                throw new InvalidOperationException("No product was found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve product.", ex);
            }
        }

        public List<Product> GetProducts()
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

                                Product product = new Product
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

                            return products;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve products.", ex);
            }
        }

        public Dictionary<string, int> GetTrendyProducts()
        {
            try
            {
                Dictionary<string, int> products = new ();

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

                                //Product product = new Product
                                //(
                                //    id: productId,
                                //    title: reader.GetString("Title"),
                                //    description: reader.GetString("Description"),
                                //    price: (double)reader.GetDecimal(reader.GetOrdinal("Price")),
                                //    category: Enum.TryParse(reader.GetString("Category"), out Category category) ? category : default(Category),
                                //    hashtags: hashtagsToAdd,
                                //    imageUrl: reader.GetString("ImageUrl")
                                //);

                                string name = reader.GetString("Title");
                                int count = reader.GetInt32("TimesOrdered");

                                products.Add(name, count);
                            }

                            return products;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve trendy products.", ex);
            }
        }

    }

}
