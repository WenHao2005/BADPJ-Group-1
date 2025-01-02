<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllProd.aspx.cs" Inherits="Bella.Pages.Shopping_Page.AllProd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/Shop.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div>
                Filter: <asp:DropDownList AutoPostBack="true" ID="ddl_Filter" runat="server"></asp:DropDownList>
            </div>

            <div class="product-grid">
            <asp:Repeater ID="Rpt_products" runat="server">
                <ItemTemplate>
                    <div class="product-card">
                        <div class="product-image">
                            <%--<img src='<%# "~/Images/" + Eval("ImageUrl") %>' alt='<%# Eval("Name") %>' />--%>
                            <asp:Image ID="Image1" height="150px" runat="server" ImageUrl='<%# "~/Images/" + Eval("ImageUrl") %>' AlternateText="Image not available" />
                        </div>
                        <div class="product-details">
                            <h2 class="product-name"><%# Eval("Name") %></h2>
                            <p class="product-price">Price: $<%# Eval("Price", "{0:F2}") %></p>
                            <p class="product-brand">Brand: <%# Eval("Brand") %></p>
                            <p class="product-brand">Material: <%# Eval("Material") %></p>
                            <a href='<%# "ProductDetails.aspx?ProductId=" + Eval("ProductId") %>' class="view-details">View Details</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>


        </div>
    </form>
</body>
</html>
