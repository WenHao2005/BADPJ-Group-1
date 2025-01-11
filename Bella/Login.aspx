<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bella.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link href="CSS/Site1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 300px; margin: auto; padding-top: 50px;">
            <h2>Login</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />
            <asp:Label ID="lblUsername" runat="server" Text="Username or Email:"></asp:Label><br />
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label><br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br /><br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /><br /><br />
            <asp:HyperLink ID="hlRegister" runat="server" NavigateUrl="Register.aspx" Text="Register here" ForeColor="Blue" />
        </div>
    </form>
</body>
</html>

