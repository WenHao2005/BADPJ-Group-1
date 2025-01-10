using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Bella
{
    public partial class AppointmentEdit : System.Web.UI.Page
    {
        // Connection string from Web.config
        private string connectionString = ConfigurationManager.ConnectionStrings["BellaDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the AppointmentID from the query string
                string appointmentId = Request.QueryString["AppointmentID"];
                if (!string.IsNullOrEmpty(appointmentId))
                {
                    LoadAppointmentDetails(appointmentId);
                }
                else
                {
                    lblMessage.Text = "Invalid Appointment ID.";
                }
            }
        }

        private void LoadAppointmentDetails(string appointmentId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Appointments WHERE AppointmentID = @AppointmentID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblAppointmentID.Text = reader["AppointmentID"].ToString();
                        txtFullName.Text = reader["FullName"].ToString();
                        txtNRIC.Text = reader["NRIC"].ToString();
                        txtPhoneNumber.Text = reader["PhoneNumber"].ToString();
                        txtAppointmentDate.Text = Convert.ToDateTime(reader["AppointmentDate"]).ToString("yyyy-MM-dd");
                        txtAppointmentTime.Text = reader["AppointmentTime"].ToString();
                        ddlGender.SelectedValue = reader["Gender"].ToString();
                    }
                    else
                    {
                        lblMessage.Text = "Appointment not found.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error loading appointment details: " + ex.Message;
                }
            }
        }

        // Event handler for Save button
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text;
            string nric = txtNRIC.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string appointmentDate = txtAppointmentDate.Text;
            string appointmentTime = txtAppointmentTime.Text;
            string gender = ddlGender.SelectedValue;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Appointments 
                                 (FullName, NRIC, PhoneNumber, AppointmentDate, AppointmentTime, Gender)
                                 VALUES 
                                 (@FullName, @NRIC, @PhoneNumber, @AppointmentDate, @AppointmentTime, @Gender)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@NRIC", nric);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                cmd.Parameters.AddWithValue("@AppointmentTime", appointmentTime);
                cmd.Parameters.AddWithValue("@Gender", gender);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Appointment saved successfully!";
                        Response.Redirect("ViewAppointments.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Save failed. Please try again.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error saving appointment: " + ex.Message;
                }
            }
        }

        // Event handler for Update button
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string appointmentId = lblAppointmentID.Text;
            string fullName = txtFullName.Text;
            string nric = txtNRIC.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string appointmentDate = txtAppointmentDate.Text;
            string appointmentTime = txtAppointmentTime.Text;
            string gender = ddlGender.SelectedValue;

            // Only update the details of the appointment, do not change AppointmentID
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Appointments 
                                 SET FullName = @FullName, 
                                     NRIC = @NRIC, 
                                     PhoneNumber = @PhoneNumber, 
                                     AppointmentDate = @AppointmentDate, 
                                     AppointmentTime = @AppointmentTime, 
                                     Gender = @Gender 
                                 WHERE AppointmentID = @AppointmentID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@NRIC", nric);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                cmd.Parameters.AddWithValue("@AppointmentTime", appointmentTime);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentId); // Use the existing AppointmentID

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Appointment updated successfully!";
                        Response.Redirect("ViewAppointments.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Update failed. Please try again.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error updating appointment: " + ex.Message;
                }
            }
        }

        // Event handler for Cancel button
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect to the ViewAppointments page
            Response.Redirect("ViewAppointments.aspx");
        }
    }
}
