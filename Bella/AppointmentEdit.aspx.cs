using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Bella
{
    public partial class AppointmentEdit : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BellaDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the AppointmentID from the query string
                string appointmentID = Request.QueryString["AppointmentID"];

                // If AppointmentID is valid, load the appointment details
                if (!string.IsNullOrEmpty(appointmentID))
                {
                    LoadAppointmentDetails(appointmentID);
                }
                else
                {
                    lblMessage.Text = "Invalid Appointment ID.";
                }
            }
        }

        private void LoadAppointmentDetails(string appointmentID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FullName, NRIC, PhoneNumber, AppointmentDate, AppointmentTime, Gender FROM Appointments WHERE AppointmentID=@AppointmentID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AppointmentID", appointmentID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    txtFullName.Text = reader["FullName"].ToString();
                    txtNRIC.Text = reader["NRIC"].ToString();
                    txtPhoneNumber.Text = reader["PhoneNumber"].ToString();
                    txtAppointmentDate.Text = Convert.ToDateTime(reader["AppointmentDate"]).ToString("yyyy-MM-dd");
                    txtAppointmentTime.Text = reader["AppointmentTime"].ToString();
                    txtGender.Text = reader["Gender"].ToString();
                }
                reader.Close();
            }
        }

        protected void UpdateAppointment(object sender, EventArgs e)
        {
            string appointmentID = Request.QueryString["AppointmentID"];
            string fullName = txtFullName.Text;
            string nric = txtNRIC.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string appointmentDate = txtAppointmentDate.Text;
            string appointmentTime = txtAppointmentTime.Text;
            string gender = txtGender.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Appointments SET FullName=@FullName, NRIC=@NRIC, PhoneNumber=@PhoneNumber, AppointmentDate=@AppointmentDate, AppointmentTime=@AppointmentTime, Gender=@Gender WHERE AppointmentID=@AppointmentID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@NRIC", nric);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                command.Parameters.AddWithValue("@AppointmentTime", appointmentTime);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@AppointmentID", appointmentID);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    Response.Redirect("ViewAppointments.aspx");
                }
                else
                {
                    lblMessage.Text = "Error updating appointment.";
                }
            }
        }
    }
}
