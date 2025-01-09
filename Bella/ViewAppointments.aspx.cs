using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Bella
{
    public partial class ViewAppointments : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BellaDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAppointments();
            }
        }

        private void LoadAppointments()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT [AppointmentID], FullName, NRIC, PhoneNumber, AppointmentDate, AppointmentTime, Gender FROM Appointments";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gv_Appointments.DataSource = dt;
                gv_Appointments.DataBind();
            }
        }

        protected void gv_Appointments_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gv_Appointments.EditIndex = e.NewEditIndex;
            LoadAppointments();
        }

        protected void gv_Appointments_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gv_Appointments.DataKeys[e.RowIndex].Value);
            GridViewRow row = gv_Appointments.Rows[e.RowIndex];

            string fullName = ((System.Web.UI.WebControls.TextBox)row.Cells[1].Controls[0]).Text;
            string nric = ((System.Web.UI.WebControls.TextBox)row.Cells[2].Controls[0]).Text;
            string phoneNumber = ((System.Web.UI.WebControls.TextBox)row.Cells[3].Controls[0]).Text;
            string appointmentDate = ((System.Web.UI.WebControls.TextBox)row.Cells[4].Controls[0]).Text;
            string appointmentTime = ((System.Web.UI.WebControls.TextBox)row.Cells[5].Controls[0]).Text;
            string gender = ((System.Web.UI.WebControls.TextBox)row.Cells[6].Controls[0]).Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Appointments SET FullName=@FullName, NRIC=@NRIC, PhoneNumber=@PhoneNumber, " +
                               "AppointmentDate=@AppointmentDate, AppointmentTime=@AppointmentTime, Gender=@Gender WHERE AppointmentID=@AppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@NRIC", nric);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                    command.Parameters.AddWithValue("@AppointmentTime", appointmentTime);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            gv_Appointments.EditIndex = -1;
            LoadAppointments();
        }

        protected void gv_Appointments_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gv_Appointments.EditIndex = -1;
            LoadAppointments();
        }

        protected void gv_Appointments_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int appointmentId = Convert.ToInt32(gv_Appointments.DataKeys[e.RowIndex].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Appointments WHERE AppointmentID=@AppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentID", appointmentId);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            LoadAppointments();
        }

        protected void gv_Appointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = gv_Appointments.SelectedIndex;
            string selectedKey = gv_Appointments.DataKeys[selectedIndex].Value.ToString();
            Response.Write($"<script>alert('Selected Appointment ID: {selectedKey}');</script>");
        }
    }
    
}
