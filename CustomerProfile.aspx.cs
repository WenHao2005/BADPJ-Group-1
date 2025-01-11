using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Bella
{
    public partial class CustomerProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if user is logged in by verifying if the session is set
                if (Session["Username"] != null)
                {
                    string userEmail = Session["Username"].ToString();
                    LoadCustomerProfile(userEmail);
                }
                else
                {
                    // Redirect to homepage if the user is not logged in
                    Response.Redirect("Homepage.aspx");
                }
            }
        }

        // Load customer profile from database
        private void LoadCustomerProfile(string email)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BellaDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT FirstName, LastName, Email, Phone, Street, PostalCode, Gender FROM Customers WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    lblFirstName.Text = reader["FirstName"].ToString();
                    lblLastName.Text = reader["LastName"].ToString();
                    lblEmail.Text = reader["Email"].ToString();
                    lblPhone.Text = reader["Phone"].ToString();
                    lblStreet.Text = reader["Street"].ToString();
                    lblPostalCode.Text = reader["PostalCode"].ToString();
                    lblGender.Text = reader["Gender"].ToString();
                }
                else
                {
                    lblMessage.Text = "Profile not found.";
                }
                conn.Close();
            }
        }

        // Edit button click: Redirect to EditProfile page
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProfile.aspx");
        }

        // Delete button click: Delete customer profile from the database
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BellaDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Customers WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@Email", Session["Username"].ToString());

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Clear session data and redirect to homepage
                    Session.Clear();
                    Response.Redirect("Homepage.aspx");
                }
                else
                {
                    lblMessage.Text = "Error deleting account.";
                }

                conn.Close();
            }
        }
    }
}
