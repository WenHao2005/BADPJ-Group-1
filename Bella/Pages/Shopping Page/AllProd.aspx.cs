using Bella.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bella.Models;

namespace Bella.Pages.Shopping_Page
{
    public partial class AllProd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductGrid();
                BindControls();
            }
            else
            {
                //this is called if a user has clicked on filter
                //get the value from the drop down list
                int categoryID = Convert.ToInt32(ddl_Filter.SelectedValue);
                if (categoryID == 0)
                    BindProductGrid();
                else
                    BindProductGridFiltered(categoryID);
            }
        }

        private void BindProductGridFiltered(int categoryID)
        {
            try
            {
                ProductDB productDB = new ProductDB();
                List<Product> allprod = productDB.GetByCategoryId(categoryID);

                if (allprod != null && allprod.Count > 0)
                {
                    Rpt_products.DataSource = allprod;
                    Rpt_products.DataBind();
                }
                else
                {
                    Rpt_products.DataSource = null;
                    Rpt_products.DataBind();

                }
            }

            catch (Exception ex)
            {
                // Log the exception or handle it as necessary
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

        private void BindControls()
        {
            CategoriesDB categoriesDB = new CategoriesDB();
            List<Category> categories = categoriesDB.GetAll();
            if (categories != null && categories.Count > 0)
            {
                ddl_Filter.DataSource = categories;
                ddl_Filter.DataValueField = "CategoryId"; // The value to bind (ID)
                ddl_Filter.DataTextField = "Name";    // The text to display
                ddl_Filter.DataBind();

            }

            ddl_Filter.Items.Insert(0, new ListItem("All", "0"));
        }

        private void BindProductGrid()
        {
            try
            {
                ProductDB productDB = new ProductDB();
                List<Product> allprod = productDB.GetAll();

                if (allprod != null && allprod.Count > 0)
                {
                    Rpt_products.DataSource = allprod;
                    Rpt_products.DataBind();
                }
                else
                {
                    Rpt_products.DataSource = null;
                    Rpt_products.DataBind();

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