using Bella.Data;
using Bella.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bella.Pages.Products
{
    public partial class view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductGrid();
            }
        }

        private void BindProductGrid()
        {
            try
            {
                ProductDB productDB = new ProductDB();
                List<Product> allprod = productDB.GetAll();

                if (allprod != null && allprod.Count> 0)
                {
                    gvProducts.DataSource = allprod;
                    gvProducts.DataBind();
                }
                else
                {
                    gvProducts.DataSource = null;
                    gvProducts.DataBind();
                }
            }

            catch (Exception ex)
            {
                // Log the exception or handle it as necessary
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }


    }
}