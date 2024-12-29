using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Bella.Data
{
    public class ProductDB
    {
        private readonly string _connectionString;

        public ProductDB()
        {
            // Use the connection string from your configuration file (web.config or app.config)
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BellaDBConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        public bool AddNewProduct(Product product)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"INSERT INTO Products 
                                    (Name, Description, Price, StockQuantity, Brand, Material, Color, Size, ImageUrl, CategoryId, CreatedAt, UpdatedAt)
                                     VALUES 
                                    (@Name, @Description, @Price, @StockQuantity, @Brand, @Material, @Color, @Size, @ImageUrl, @CategoryId, @CreatedAt, @UpdatedAt)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@Description", product.Description);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                        command.Parameters.AddWithValue("@Brand", product.Brand);
                        command.Parameters.AddWithValue("@Material", product.Material);
                        command.Parameters.AddWithValue("@Color", product.Color);
                        command.Parameters.AddWithValue("@Size", product.Size);
                        command.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);
                        command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                        command.Parameters.AddWithValue("@CreatedAt", product.CreatedAt);
                        command.Parameters.AddWithValue("@UpdatedAt", product.UpdatedAt);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error while adding product: " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT ProductId, Name, Description, Price, StockQuantity, Brand, Material, Color, Size, ImageUrl, CategoryId, CreatedAt, UpdatedAt FROM Products";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product
                                {
                                    ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Description = reader.GetString(reader.GetOrdinal("Description")),
                                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                    StockQuantity = reader.GetInt32(reader.GetOrdinal("StockQuantity")),
                                    Brand = reader.GetString(reader.GetOrdinal("Brand")),
                                    Material = reader.GetString(reader.GetOrdinal("Material")),
                                    Color = reader.GetString(reader.GetOrdinal("Color")),
                                    Size = reader.GetString(reader.GetOrdinal("Size")),
                                    ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl")),
                                    CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                                    UpdatedAt = reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
                                };

                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error while retrieving products: " + ex.Message);
            }

            return products;
        }
    }
}