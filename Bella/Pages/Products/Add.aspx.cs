using Bella.Data;
using Bella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bella.Pages.Products
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    StockQuantity = int.Parse(txtStockQuantity.Text),
                    Brand = txtBrand.Text,
                    Material = txtMaterial.Text,
                    Color = txtColor.Text,
                    Size = txtSize.Text,
                    ImageUrl = txtImageUrl.Text,
                    CategoryId = int.Parse(txtCategoryId.Text),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                ProductDB productDB = new ProductDB();
                bool isAdded = productDB.Add(product);

                if (isAdded)
                {
                    // Display success message
                    Response.Write("<script>alert('Product added successfully!');</script>");
                    Response.Redirect("~/Pages/Products/view.aspx");
                }
                else
                {
                    // Display failure message
                    Response.Write("<script>alert('Failed to add product.');</script>");
                }
            }
            catch (Exception ex)
            {
                // Display error message
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }
    }
}