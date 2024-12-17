using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bella
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(usernameOrEmail) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Username/Email and Password are required.";
                return;
            }

            // Database connection
            string connectionString = ConfigurationManager.ConnectionStrings["BellaDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Retrieve both the Password and Role of the user
                string query = "SELECT Password, Role FROM Users WHERE Username = @UsernameOrEmail OR Email = @UsernameOrEmail";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@UsernameOrEmail", usernameOrEmail);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        string storedPassword = reader["Password"].ToString();
                        int role = Convert.ToInt32(reader["Role"]); // Retrieve the user's role

                        // Check if the password matches
                        if (storedPassword == password)
                        {
                            // Set session variable for user login
                            Session["Username"] = usernameOrEmail;
                            Session["Role"] = role; // Store the user's role in session

                            // Redirect based on role
                            if (role == 1) // Staff
                            {
                                Response.Redirect("UserManagement.aspx");
                            }
                            else if (role == 0) // Customer
                            {
                                Response.Redirect("Products.aspx");
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Incorrect password.";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "User not found.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An error occurred: " + ex.Message;
                }
            }
        }
    }
}
