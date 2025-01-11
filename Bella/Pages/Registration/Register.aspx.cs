using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Bella
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty; // Reset message label
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Collect form data
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string street = txtStreet.Text.Trim();
            string postalCode = txtPostalCode.Text.Trim();
            string gender = ddlGender.SelectedValue;

            // Validate form data
            if (password != confirmPassword)
            {
                lblMessage.Text = "Passwords do not match. Please check your details again.";
                return;
            }

            if (phone.Length != 8 || !System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{8}$"))
            {
                lblMessage.Text = "Phone number must be exactly 8 digits. Please check your details again.";
                return;
            }

            if (postalCode.Length != 6 || !System.Text.RegularExpressions.Regex.IsMatch(postalCode, @"^\d{6}$"))
            {
                lblMessage.Text = "Postal code must be exactly 6 digits. Please check your details again.";
                return;
            }

            if (string.IsNullOrEmpty(gender))
            {
                lblMessage.Text = "Please select your gender.";
                return;
            }

            // Database connection
            string connectionString = ConfigurationManager.ConnectionStrings["BellaDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check if email already exists
                string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                SqlCommand cmdCheckEmail = new SqlCommand(checkEmailQuery, conn);
                cmdCheckEmail.Parameters.AddWithValue("@Email", email);
                int emailCount = Convert.ToInt32(cmdCheckEmail.ExecuteScalar());

                if (emailCount > 0)
                {
                    lblMessage.Text = "Email is already registered.";
                    return;
                }

                // Insert into Users table
                string insertUserQuery = "INSERT INTO Users (Username, Email, Password, Role) VALUES (@Username, @Email, @Password, 0); SELECT SCOPE_IDENTITY();";
                SqlCommand cmdInsertUser = new SqlCommand(insertUserQuery, conn);
                cmdInsertUser.Parameters.AddWithValue("@Username", username);
                cmdInsertUser.Parameters.AddWithValue("@Email", email);
                cmdInsertUser.Parameters.AddWithValue("@Password", password);
                int userID = Convert.ToInt32(cmdInsertUser.ExecuteScalar());

                // Insert into Customers table
                string insertCustomerQuery = "INSERT INTO Customers (UserID, FirstName, LastName, Phone, Street, PostalCode, Gender) " +
                                             "VALUES (@UserID, @FirstName, @LastName, @Phone, @Street, @PostalCode, @Gender)";
                SqlCommand cmdInsertCustomer = new SqlCommand(insertCustomerQuery, conn);
                cmdInsertCustomer.Parameters.AddWithValue("@UserID", userID);  // UserID is inserted into Customers
                cmdInsertCustomer.Parameters.AddWithValue("@FirstName", firstName);
                cmdInsertCustomer.Parameters.AddWithValue("@LastName", lastName);
                cmdInsertCustomer.Parameters.AddWithValue("@Phone", phone);
                cmdInsertCustomer.Parameters.AddWithValue("@Street", street);
                cmdInsertCustomer.Parameters.AddWithValue("@PostalCode", postalCode);
                cmdInsertCustomer.Parameters.AddWithValue("@Gender", gender);
                cmdInsertCustomer.ExecuteNonQuery();

                // Success message will be shown via the JavaScript pop-up
                Response.Redirect("Login.aspx");
            }
        }
    }
}
