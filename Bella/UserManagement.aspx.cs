using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Bella
{
    public partial class UserManagement : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["BellaDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }

            if (Session["Username"] != null)
            {
                lblLoggedInUser.Text = "Welcome, " + Session["Username"].ToString();
            }
            else
            {
                // Redirect to login page if no user is logged in
                Response.Redirect("Login.aspx");
            }

        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Users", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridViewUsers.DataSource = dt;
                GridViewUsers.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO Users (Username, Email, Password, Role) VALUES (@Username, @Email, @Password, @Role)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Role", 0); // Default role is customer
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData();
            }
        }

        protected void GridViewUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userId = Convert.ToInt32(GridViewUsers.DataKeys[e.RowIndex].Value);
            GridViewRow row = GridViewUsers.Rows[e.RowIndex];

            string username = (row.Cells[1].Controls[0] as TextBox).Text;
            string email = (row.Cells[2].Controls[0] as TextBox).Text;
            string password = (row.Cells[3].Controls[0] as TextBox).Text;
            DropDownList ddlRole = (DropDownList)row.FindControl("ddlRole");
            int role = Convert.ToInt32(ddlRole.SelectedValue);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "UPDATE Users SET Username=@Username, Email=@Email, Password=@Password, Role=@Role WHERE UserID=@UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            GridViewUsers.EditIndex = -1;
            LoadData();
        }

        protected void GridViewUsers_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(GridViewUsers.DataKeys[e.RowIndex].Value);
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "DELETE FROM Users WHERE UserID=@UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();
        }

        protected void GridViewUsers_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            GridViewUsers.EditIndex = -1;
            LoadData();
        }

        protected void GridViewUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewUsers.EditIndex = e.NewEditIndex; // Set the row to edit mode
            LoadData(); // Reload the data to refresh the GridView
        }


    }
}