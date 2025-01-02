<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Bella.Pages.Products.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
        <div>
            <h1>Add New Product</h1>
            <table>
                <tr>
                    <td>Name:</td>
                    <td><asp:TextBox ID="txtName" runat="server" /></td>
                </tr>
                <tr>
                    <td>Description:</td>
                    <td><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" /></td>
                </tr>
                <tr>
                    <td>Price:</td>
                    <td><asp:TextBox ID="txtPrice" runat="server" /></td>
                </tr>
                <tr>
                    <td>Stock Quantity:</td>
                    <td><asp:TextBox ID="txtStockQuantity" runat="server" /></td>
                </tr>
                <tr>
                    <td>Brand:</td>
                    <td><asp:TextBox ID="txtBrand" runat="server" /></td>
                </tr>
                <tr>
                    <td>Material:</td>
                    <td><asp:TextBox ID="txtMaterial" runat="server" /></td>
                </tr>
                <tr>
                    <td>Color:</td>
                    <td><asp:TextBox ID="txtColor" runat="server" /></td>
                </tr>
                <tr>
                    <td>Size:</td>
                    <td><asp:TextBox ID="txtSize" runat="server" /></td>
                </tr>
                <tr>
                    <td>Image URL:</td>
                    <td><asp:TextBox ID="txtImageUrl" runat="server" /></td>
                </tr>
                <tr>
                    <td>Category ID:</td>
                    <td><asp:TextBox ID="txtCategoryId" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="btnAddProduct_Click" />
                    </td>
                </tr>
            </table>
        </div>

    <asp:HyperLink ID="hlBackToList" runat="server" NavigateUrl="~/Pages/Products/view.aspx" CssClass="btn">Back to List</asp:HyperLink>
    </form>
</body>
</html>
