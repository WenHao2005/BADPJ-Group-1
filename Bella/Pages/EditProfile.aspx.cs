using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Bella
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    string userEmail = Session["Username"].ToString();
                    LoadUserDetails(userEmail);
                }
                else
                {
                    Response.Redirect("Homepage.aspx");
                }
            }
        }

        private void LoadUserDetails(string email)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BellaDBConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT FirstName, LastName, Phone, Street, PostalCode, Gender FROM Customers WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    txtFirstName.Text = reader["FirstName"].ToString();
                    txtLastName.Text = reader["LastName"].ToString();
                    txtPhone.Text = reader["Phone"].ToString();
                    txtStreet.Text = reader["Street"].ToString();
                    txtPostalCode.Text = reader["PostalCode"].ToString();
                    ddlGender.SelectedValue = reader["Gender"].ToString();
                }

                conn.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string email = Session["Username"].ToString();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string street = txtStreet.Text.Trim();
            string postalCode = txtPostalCode.Text.Trim();
            string gender = ddlGender.SelectedValue;

            // Database connection
            string connectionString = ConfigurationManager.ConnectionStrings["BellaDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string updateQuery = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Phone = @Phone, Street = @Street, PostalCode = @PostalCode, Gender = @Gender WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Street", street);
                cmd.Parameters.AddWithValue("@PostalCode", postalCode);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Email", email);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Response.Redirect("CustomerProfile.aspx");
                }

                conn.Close();
            }
        }
    }
}
