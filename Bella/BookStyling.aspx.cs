using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Bella
{
    public partial class BookStyling : System.Web.UI.Page
    {
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            // Step 1: Capture form inputs
            string fullName = tb_FullName.Text.Trim();
            string nric = tb_NRIC.Text.Trim();
            string phoneNumber = tb_Hp.Text.Trim();
            DateTime appointmentDate = cal_Date.SelectedDate;
            string appointmentTime = ddl_Time.SelectedValue;
            string gender = rbl_Gender.SelectedValue;

            // Step 2: Validate inputs (optional but recommended)
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(nric) ||
                string.IsNullOrWhiteSpace(phoneNumber) || appointmentDate == DateTime.MinValue)
            {
                Response.Write("<script>alert('Please fill in all required fields.');</script>");
                return;
            }

            // Step 3: Connect to the database
            string connectionString = ConfigurationManager.ConnectionStrings["BellaDBConnectionString"].ConnectionString;


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Step 4: SQL query to insert data
                    string query = "INSERT INTO Appointments (FullName, NRIC, PhoneNumber, AppointmentDate, AppointmentTime, Gender) " +
                                   "VALUES (@FullName, @NRIC, @PhoneNumber, @AppointmentDate, @AppointmentTime, @Gender); " +
                                   "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Step 5: Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@NRIC", nric);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                        command.Parameters.AddWithValue("@AppointmentTime", appointmentTime);
                        command.Parameters.AddWithValue("@Gender", gender);

                        // Step 6: Open the connection and execute the query
                        connection.Open();
                        int appointmentId = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();

                        // Step 7: Notify the user
                        Response.Write($"<script>alert('Appointment booked successfully! Your Appointment ID is {appointmentId}');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Response.Write($"<script>alert('An error occurred: {ex.Message}');</script>");
            }
            Response.Redirect("ViewAppointments.aspx");

        }
    }
}
