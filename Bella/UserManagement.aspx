<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="Bella.UserManagement" %>

<!DOCTYPE html>
<html>
<head>
    <title>User Management</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link href="CSS/Site1.css" rel="stylesheet" />
    <link href="CSS/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <!-- Header -->
	<div id="header-wrapper">
		<header id="header" class="container">

			<!-- Logo -->
				<div id="logo">
					<h1><a href="homepage.aspx">Bella</a></h1>
				</div>

			<!-- Nav -->
				<nav id="nav">
					<ul>
						<li><a href="homepage.aspx">Welcome</a></li>
						<li  class="current"><a href="Login.aspx">Login/Signup</a></li>
						<li><a href="Products.aspx">Products</a></li>
						<li><a href="Donations.aspx">Donations</a></li>
						<li><a href="Cart.aspx">Cart</a></li>
                        <!-- Display Logged-in User -->
                        <li style="float: right;">
                            <asp:Label ID="lblLoggedInUser" runat="server" Text=""></asp:Label> </li>
					</ul>
				</nav>

		</header>
	</div>
       
        <h3>User Management</h3>

        <!-- GridView to Display Data -->
        <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" 
              OnRowEditing="GridViewUsers_RowEditing" 
              OnRowUpdating="GridViewUsers_RowUpdating" 
              OnRowDeleting="GridViewUsers_RowDeleting"
              OnRowCancelingEdit="GridViewUsers_RowCancelingEdit" DataKeyNames="UserID">
    <Columns>
        <asp:BoundField DataField="UserID" HeaderText="User ID" ReadOnly="True" />
        <asp:BoundField DataField="Username" HeaderText="Username" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="Password" HeaderText="Password" />
        <asp:TemplateField HeaderText="Role">
            <EditItemTemplate>
                <asp:DropDownList ID="ddlRole" runat="server">
                    <asp:ListItem Text="Customer" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Staff" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </EditItemTemplate>
            <ItemTemplate>
                <%# Eval("Role").ToString() == "1" ? "Staff" : "Customer" %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>

        <br />

        <!-- Input Fields for Adding New Users -->
        <div>
            <asp:Label Text="Username:" runat="server" />
            <asp:TextBox ID="txtUsername" runat="server" />
            <asp:Label Text="Email:" runat="server" />
            <asp:TextBox ID="txtEmail" runat="server" />
            <asp:Label Text="Password:" runat="server" />
            <asp:TextBox ID="txtPassword" runat="server" />
            <asp:Button ID="btnAdd" runat="server" Text="Add User" OnClick="btnAdd_Click" />
        </div>
    </form>
</body>
</html>