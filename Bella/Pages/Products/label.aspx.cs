using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bella.Pages.Products
{
    public partial class label : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int productId;
                if (int.TryParse(Request.QueryString["ProductId"], out productId))
                {
                    // TODO
                    // Load the product details if necessary (optional)
                    // LoadProductDetails(productId);

                    // TODO
                    // Load Skin Tones and Body Shapes
                    // LoadSkinTones();
                    // LoadBodyShapes();

                    // Save the product ID for later use (e.g., in ViewState)
                    ViewState["ProductId"] = productId;
                }
                else
                {
                    lblMessage.Text = "Invalid Product ID.";
                    
                }
            }
        }

    }
}