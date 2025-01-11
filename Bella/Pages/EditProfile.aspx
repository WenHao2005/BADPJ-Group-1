<%@ Page Title="Edit Profile" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="Bella.EditProfile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Profile</title>
    <style>
        .form-label { font-weight: bold; }
        .form-field { margin-left: 10px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Edit Profile</h2>

        <!-- Display User Information with editable fields -->
        <div>
            <label class="form-label">First Name:</label>
            <asp:TextBox ID="txtFirstName" runat="server" class="form-field" />
        </div>
        <div>
            <label class="form-label">Last Name:</label>
            <asp:TextBox ID="txtLastName" runat="server" class="form-field" />
        </div>
        <div>
            <label class="form-label">Phone:</label>
            <asp:TextBox ID="txtPhone" runat="server" class="form-field" />
        </div>
        <div>
            <label class="form-label">Street:</label>
            <asp:TextBox ID="txtStreet" runat="server" class="form-field" />
        </div>
        <div>
            <label class="form-label">Postal Code:</label>
            <asp:TextBox ID="txtPostalCode" runat="server" class="form-field" />
        </div>
        <div>
            <label class="form-label">Gender:</label>
            <asp:DropDownList ID="ddlGender" runat="server" class="form-field">
                <asp:ListItem Text="Select Gender" Value=""></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Prefer not to say" Value="Prefer not to say"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <asp:Button ID="btnUpdate" runat="server" Text="Update Profile" OnClick="btnUpdate_Click" />
    </form>
</body>
</html>
