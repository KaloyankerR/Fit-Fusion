﻿using Models.Product;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models.Product.Enums;

namespace DataAcess
{
    public class ProductDAO : IProductDAO, IStorageAccess
    {
        private string _connectionString;

        public ProductDAO()
        {
            _connectionString = Connection.DbConnection.ConnectionString;
        }

        public ProductDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void TestConnectionString()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                }
            }
            catch (SqlException ex)
            {
                throw new DataAccessException("An error occurred in the database operation.", ex);
            }
        }

        public void ChangeConnectionString(string newConnectionString)
        {
            _connectionString = newConnectionString;
            TestConnectionString();
        }

        public bool CreateProduct(Product product)
        {
            try
            {
                using (SqlConnection connection = new(_connectionString))
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

                // TODO throw new DuplicateNameException("Product already exists.");
            }
            catch (SqlException ex)
            {
                throw new DataAccessException("An error occurred in the database operation.", ex);
            }

            return true;
        }

        public bool UpdateProduct(Product product)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand updateProductCommand = new SqlCommand("UPDATE Product SET Title = @Title, Description = @Description, Price = @Price, Category = @Category, ImageUrl = @ImageUrl WHERE Id = @ProductId", connection))
                    {
                        updateProductCommand.Parameters.AddWithValue("@ProductId", product.Id);
                        updateProductCommand.Parameters.AddWithValue("@Title", product.Title);
                        updateProductCommand.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                        updateProductCommand.Parameters.AddWithValue("@Price", product.Price);
                        updateProductCommand.Parameters.AddWithValue("@Category", product.Category);
                        updateProductCommand.Parameters.AddWithValue("@ImageUrl", product.ImageUrl ?? (object)DBNull.Value);

                        updateProductCommand.ExecuteNonQuery();
                    }
                }

                // throw new NullReferenceException("Product wasn't found.");
            }
            catch (SqlException)
            {
                throw new DataAccessException("An error occurred in the database operation.");
            }

            return true;
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //using (SqlCommand deleteCommand = new SqlCommand(
                    //    "DELETE ShoppingCart, Recommendation, Product " +
                    //    "FROM ShoppingCart " +
                    //    "JOIN Recommendation ON ShoppingCart.ProductId = Recommendation.ProductId " +
                    //    "WHERE ShoppingCart.ProductId = @ProductId", connection))
                    //{
                    //    deleteCommand.Parameters.AddWithValue("@ProductId", id);
                    //    deleteCommand.ExecuteNonQuery();
                    //}
                    using (SqlCommand deleteShoppingCartCommand = new SqlCommand("DELETE FROM ShoppingCart WHERE ProductId = @ProductId", connection))
                    {
                        deleteShoppingCartCommand.Parameters.AddWithValue("@ProductId", id);
                        deleteShoppingCartCommand.ExecuteNonQuery();
                    }

                    using (SqlCommand deleteRecommendationCommand = new SqlCommand("DELETE FROM Recommendation WHERE ProductId = @ProductId", connection))
                    {
                        deleteRecommendationCommand.Parameters.AddWithValue("@ProductId", id);
                        deleteRecommendationCommand.ExecuteNonQuery();
                    }

                    using (SqlCommand deleteProductCommand = new SqlCommand("DELETE FROM Product WHERE Id = @ProductId", connection))
                    {
                        deleteProductCommand.Parameters.AddWithValue("@ProductId", id);
                        deleteProductCommand.ExecuteNonQuery();
                    }
                }

                // throw new NullReferenceException("Product wasn't exist.");
            }
            catch (SqlException)
            {
                throw new DataAccessException("An error occurred in the database operation.");
            }

            return true;
        }

        public Product GetProductById(int id)
        {
            Product product;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand getProductCommand = new("SELECT * FROM Product WHERE Id = @ProductId", connection))
                    {
                        getProductCommand.Parameters.AddWithValue("@ProductId", id);

                        using (SqlDataReader reader = getProductCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                product = new Product
                                (
                                    id: reader.GetInt32("Id"),
                                    title: reader.GetString("Title"),
                                    description: reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                                    price: (double)reader.GetDecimal(reader.GetOrdinal("Price")),
                                    category: Enum.TryParse(reader.GetString("Category"), out Category category) ? category : default(Category),
                                    imageUrl: reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : reader.GetString("ImageUrl")
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
                throw new DataAccessException("An error occurred in the database operation.");
            }

            return product;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
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
                                    description: reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                                    price: (double)reader.GetDecimal(reader.GetOrdinal("Price")),
                                    category: Enum.TryParse(reader.GetString("Category"), out Category category) ? category : default(Category),
                                    imageUrl: reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : reader.GetString("ImageUrl")
                                );

                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new DataAccessException("An error occurred in the database operation.");
            }

            return products;
        }

        public Dictionary<string, int> GetTrendyProducts()
        {
            Dictionary<string, int> products = new();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
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
                throw new DataAccessException("An error occurred in the database operation.");
            }

            return products;
        }
    }

}
