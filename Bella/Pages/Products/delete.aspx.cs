using Bella.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bella.Pages.Products
{
    public partial class delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int productId;
            if (int.TryParse(Request.QueryString["ProductId"], out productId))
            {
                DeleteProduct(productId);
                Response.Redirect("~/Pages/Products/View.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid Product ID.";
            }
        }

        private void DeleteProduct(int productId)
        {
            ProductDB productDB = new ProductDB();
            if (productDB.Delete(productId))
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Product deleted successfully.";
            }
            else
            {
                lblMessage.Text = "Failed to delete product.";
            }
        }
    }
}