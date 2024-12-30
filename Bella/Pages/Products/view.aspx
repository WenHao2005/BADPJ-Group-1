<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="Bella.Pages.Products.view" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>View Products</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Product List</h1>
            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="false" 
                          CssClass="table" EmptyDataText="No products found.">
                <Columns>
                    <asp:BoundField DataField="ProductId" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="StockQuantity" HeaderText="Stock Quantity" />
                    <asp:BoundField DataField="Brand" HeaderText="Brand" />
                    <asp:BoundField DataField="Material" HeaderText="Material" />
                    <asp:BoundField DataField="Color" HeaderText="Color" />
                    <asp:BoundField DataField="Size" HeaderText="Size" />
                    <asp:BoundField DataField="CategoryId" HeaderText="Category ID" />
                
                    
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <a href="update.aspx?ProductId=<%# Eval("ProductId") %>">Update</a> |
                            <a href="delete.aspx?ProductId=<%# Eval("ProductId") %>" onclick="return confirm('Are you sure you want to delete this product?');">Delete</a>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>