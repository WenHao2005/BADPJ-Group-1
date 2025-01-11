<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="Bella.CustomerProfile" %>

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
        <div>
            <h2>Customer Profile</h2>
            
            <!-- Displaying User Information -->
            <p><span class="profile-label">First Name:</span> <span class="profile-data"><asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label></span></p>
            <p><span class="profile-label">Last Name:</span> <span class="profile-data"><asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label></span></p>
            <p><span class="profile-label">Email:</span> <span class="profile-data"><asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label></span></p>
            <p><span class="profile-label">Phone:</span> <span class="profile-data"><asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label></span></p>
            <p><span class="profile-label">Street:</span> <span class="profile-data"><asp:Label ID="lblStreet" runat="server" Text="Street"></asp:Label></span></p>
            <p><span class="profile-label">Postal Code:</span> <span class="profile-data"><asp:Label ID="lblPostalCode" runat="server" Text="Postal Code"></asp:Label></span></p>
            <p><span class="profile-label">Gender:</span> <span class="profile-data"><asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label></span></p>

            <br />
            <!-- Buttons to Edit and Delete Profile -->
            <asp:Button ID="btnEdit" runat="server" Text="Edit Profile" OnClick="btnEdit_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete Account" OnClick="btnDelete_Click" ForeColor="Red" />
        </div>
    </form>
</body>
</html>