<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="Bella.Pages.Products.update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Update Product</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Update Product</h1>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <table>
                <tr>
                    <td>Name:</td>
                    <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Description:</td>
                    <td><asp:TextBox ID="txtDescription" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Price:</td>
                    <td><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Stock Quantity:</td>
                    <td><asp:TextBox ID="txtStockQuantity" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Brand:</td>
                    <td><asp:TextBox ID="txtBrand" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Material:</td>
                    <td><asp:TextBox ID="txtMaterial" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Color:</td>
                    <td><asp:TextBox ID="txtColor" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Size:</td>
                    <td><asp:TextBox ID="txtSize" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Category ID:</td>
                    <td><asp:TextBox ID="txtCategoryId" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
