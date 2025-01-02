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
    public partial class update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int productId;
                if (int.TryParse(Request.QueryString["ProductId"], out productId))
                {
                    LoadProductDetails(productId);
                }
                else
                {
                    lblMessage.Text = "Invalid Product ID.";
                }
            }
        }

        private void LoadProductDetails(int productId)
        {
            ProductDB productDB = new ProductDB();
            Product product = productDB.GetById(productId);

            if (product != null)
            {
                txtName.Text = product.Name;
                txtDescription.Text = product.Description;
                txtPrice.Text = product.Price.ToString();
                txtStockQuantity.Text = product.StockQuantity.ToString();
                txtBrand.Text = product.Brand;
                txtMaterial.Text = product.Material;
                txtColor.Text = product.Color;
                txtSize.Text = product.Size;
                txtCategoryId.Text = product.CategoryId.ToString();
            }
            else
            {
                lblMessage.Text = "Product not found.";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int productId;
            if (int.TryParse(Request.QueryString["ProductId"], out productId))
            {
                Product product = new Product
                {
                    ProductId = productId,
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    StockQuantity = int.Parse(txtStockQuantity.Text),
                    Brand = txtBrand.Text,
                    Material = txtMaterial.Text,
                    Color = txtColor.Text,
                    Size = txtSize.Text,
                    CategoryId = int.Parse(txtCategoryId.Text)
                };

                ProductDB productDB = new ProductDB();
                if (productDB.Update(product))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Product updated successfully.";
                    Response.Redirect("~/Pages/Products/View.aspx");
                }
                else
                {
                    lblMessage.Text = "Failed to update product.";
                }
            }
        }
    }
}