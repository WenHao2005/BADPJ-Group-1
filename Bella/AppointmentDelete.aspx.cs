using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Bella
{
    public partial class AppointmentDelete : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BellaDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve the AppointmentID from the query string
            string appointmentID = Request.QueryString["AppointmentID"];
            if (!string.IsNullOrEmpty(appointmentID))
            {
                // Load the appointment details based on the AppointmentID
                LoadAppointmentDetails(appointmentID);
            }
            else
            {
                lblConfirmation.Text = "Invalid Appointment ID.";
                lblAppointmentDetails.Visible = false;
            }
        }

        private void LoadAppointmentDetails(string appointmentID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FullName, NRIC, PhoneNumber, AppointmentDate, AppointmentTime, Gender FROM Appointments WHERE AppointmentID=@AppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentID", appointmentID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Display the appointment details
                            lblAppointmentDetails.Text = $"Appointment Details:<br/>" +
                                                         $"Full Name: {reader["FullName"]}<br/>" +
                                                         $"NRIC: {reader["NRIC"]}<br/>" +
                                                         $"Phone Number: {reader["PhoneNumber"]}<br/>" +
                                                         $"Appointment Date: {reader["AppointmentDate"]}<br/>" +
                                                         $"Appointment Time: {reader["AppointmentTime"]}<br/>" +
                                                         $"Gender: {reader["Gender"]}";
                        }
                        else
                        {
                            lblConfirmation.Text = "Appointment not found.";
                            lblAppointmentDetails.Visible = false;
                        }
                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Retrieve the AppointmentID from the query string
            string appointmentID = Request.QueryString["AppointmentID"];
            if (!string.IsNullOrEmpty(appointmentID))
            {
                // Delete the appointment from the database
                DeleteAppointmentRecord(appointmentID);
                Response.Redirect("ViewAppointments.aspx"); // Redirect back to ViewAppointments.aspx after deletion
            }
        }

        private void DeleteAppointmentRecord(string appointmentID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Appointments WHERE AppointmentID=@AppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentID", appointmentID);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect back to ViewAppointments.aspx without deleting
            Response.Redirect("ViewAppointments.aspx");
        }
    }
}
