using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Bella.Models;

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
        public bool Add(Product product)
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
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT ProductId, Name, Description, Price, StockQuantity, 
                                    Brand, Material, Color, Size, ImageUrl, 
                                    CategoryId, CreatedAt, UpdatedAt FROM Products";

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
                                    Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? "" : reader.GetString(reader.GetOrdinal("Name")),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString(reader.GetOrdinal("Description")),
                                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                    StockQuantity = reader.GetInt32(reader.GetOrdinal("StockQuantity")),
                                    Brand = reader.IsDBNull(reader.GetOrdinal("Brand")) ? "" : reader.GetString(reader.GetOrdinal("Brand")),
                                    Material = reader.IsDBNull(reader.GetOrdinal("Material")) ? "" : reader.GetString(reader.GetOrdinal("Material")),
                                    Color = reader.IsDBNull(reader.GetOrdinal("Color")) ? "" : reader.GetString(reader.GetOrdinal("Color")),
                                    Size = reader.IsDBNull(reader.GetOrdinal("Size")) ? "" : reader.GetString(reader.GetOrdinal("Size")),
                                    ImageUrl = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? "" : reader.GetString(reader.GetOrdinal("ImageUrl")),
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

        public bool Update(Product product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Products
                         SET Name = @Name,
                             Description = @Description,
                             Price = @Price,
                             StockQuantity = @StockQuantity,
                             Brand = @Brand,
                             Material = @Material,
                             Color = @Color,
                             Size = @Size,
                             ImageUrl = @ImageUrl,
                             CategoryId = @CategoryId,
                             UpdatedAt = @UpdatedAt
                         WHERE ProductId = @ProductId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                    cmd.Parameters.AddWithValue("@Brand", product.Brand);
                    cmd.Parameters.AddWithValue("@Material", product.Material);
                    cmd.Parameters.AddWithValue("@Color", product.Color);
                    cmd.Parameters.AddWithValue("@Size", product.Size);
                    // Handle ImageUrl: Pass null if the property is null
                    if (string.IsNullOrEmpty(product.ImageUrl))
                    {
                        cmd.Parameters.AddWithValue("@ImageUrl", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);
                    }
                    cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ProductId", product.ProductId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool Delete(int productId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"DELETE FROM Products WHERE ProductId = @ProductId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public Product GetById(int productId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"SELECT ProductId, Name, Description, Price, StockQuantity, Brand, Material, Color, Size, 
                                ImageUrl, CategoryId, CreatedAt, UpdatedAt
                         FROM Products
                         WHERE ProductId = @ProductId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
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
                                ImageUrl = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : reader.GetString(reader.GetOrdinal("ImageUrl")),
                                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                                UpdatedAt = reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
                            };
                        }
                    }
                }
            }
            return null; // Return null if no product is found
        }

        public List<Product> GetByCategoryId(int categoryId)
        {
            List<Product> products = new List<Product>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"SELECT ProductId, Name, Description, Price, StockQuantity, Brand, Material, Color, Size, 
                                ImageUrl, CategoryId, CreatedAt, UpdatedAt
                         FROM Products
                         WHERE CategoryId = @categoryId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                                Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? "" : reader.GetString(reader.GetOrdinal("Name")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString(reader.GetOrdinal("Description")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                StockQuantity = reader.GetInt32(reader.GetOrdinal("StockQuantity")),
                                Brand = reader.IsDBNull(reader.GetOrdinal("Brand")) ? "" : reader.GetString(reader.GetOrdinal("Brand")),
                                Material = reader.IsDBNull(reader.GetOrdinal("Material")) ? "" : reader.GetString(reader.GetOrdinal("Material")),
                                Color = reader.IsDBNull(reader.GetOrdinal("Color")) ? "" : reader.GetString(reader.GetOrdinal("Color")),
                                Size = reader.IsDBNull(reader.GetOrdinal("Size")) ? "" : reader.GetString(reader.GetOrdinal("Size")),
                                ImageUrl = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? "" : reader.GetString(reader.GetOrdinal("ImageUrl")),
                                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                                UpdatedAt = reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
                            };

                            products.Add(product);
                        }
                    }
                }
            }
            return products;
        }

        public bool SkinBodyProd(int productId, string skinTone, string bodyShape)
        {
            string query = @"
        UPDATE Products
        SET CategoryId = (
            SELECT CategoryId
            FROM Category
            WHERE SkinTone = @SkinTone AND BodyShape = @BodyShape
        )
        WHERE ProductId = @ProductId";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.Parameters.AddWithValue("@SkinTone", skinTone);
                cmd.Parameters.AddWithValue("@BodyShape", bodyShape);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0; // Return true if at least one row was updated
            }
        }



    }
}