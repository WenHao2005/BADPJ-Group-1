<%@ Page Title="Customer Profile" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="Bella.CustomerProfile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Profile</title>
    <style>
        .profile-label { font-weight: bold; }
        .profile-data { margin-left: 10px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Customer Profile</h2>
        
        <!-- Displaying User Information -->
        <p><span class="profile-label">First Name:</span> <asp:Label ID="lblFirstName" runat="server" class="profile-data"></asp:Label></p>
        <p><span class="profile-label">Last Name:</span> <asp:Label ID="lblLastName" runat="server" class="profile-data"></asp:Label></p>
        <p><span class="profile-label">Email:</span> <asp:Label ID="lblEmail" runat="server" class="profile-data"></asp:Label></p>
        <p><span class="profile-label">Phone:</span> <asp:Label ID="lblPhone" runat="server" class="profile-data"></asp:Label></p>
        <p><span class="profile-label">Street:</span> <asp:Label ID="lblStreet" runat="server" class="profile-data"></asp:Label></p>
        <p><span class="profile-label">Postal Code:</span> <asp:Label ID="lblPostalCode" runat="server" class="profile-data"></asp:Label></p>
        <p><span class="profile-label">Gender:</span> <asp:Label ID="lblGender" runat="server" class="profile-data"></asp:Label></p>
        
        <br />
        
        <!-- Buttons to Edit and Delete Profile -->
        <asp:Button ID="btnEdit" runat="server" Text="Edit Profile" OnClick="btnEdit_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete Account" OnClick="btnDelete_Click" />
    </form>
</body>
</html>
