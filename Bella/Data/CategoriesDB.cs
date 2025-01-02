using Bella.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bella.Data
{
    public class CategoriesDB
    {
        private readonly string _connectionString;

        public CategoriesDB()
        {
            // Use the connection string from your configuration file (web.config or app.config)
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BellaDBConnectionString"].ConnectionString;
        }

        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT CategoryId, Name, Description, SkinTone, BodyShape, CreatedAt, UpdatedAt FROM Category";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Category category = new Category
                                {
                                    CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                    Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? "" : reader.GetString(reader.GetOrdinal("Name")),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString(reader.GetOrdinal("Description")),
                                    SkinTone = reader.IsDBNull(reader.GetOrdinal("SkinTone")) ? "" : reader.GetString(reader.GetOrdinal("SkinTone")),
                                    BodyShape = reader.IsDBNull(reader.GetOrdinal("BodyShape")) ? "" : reader.GetString(reader.GetOrdinal("BodyShape")),
                                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                                    UpdatedAt = reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
                                };

                                categories.Add(category);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Error while retrieving categories: " + ex.Message);
            }

            return categories;
        }



    }
}