<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentEdit.aspx.cs" Inherits="Bella.AppointmentEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Appointment</title>
    <style>
        form {
            width: 50%;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            background-color: #f9f9f9;
        }

        label {
            display: block;
            margin-top: 10px;
            font-weight: bold;
        }

        input, select {
            width: 100%;
            padding: 8px;
            margin-top: 5px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        button {
            background-color: #4CAF50;
            color: white;
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        button:hover {
            background-color: #45a049;
        }

        .cancel {
            background-color: #f44336;
        }

        .cancel:hover {
            background-color: #e53935;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Edit Appointment</h2>

        <asp:Label ID="lblAppointmentID" runat="server" Text="Appointment ID:" AssociatedControlID="txtAppointmentID"></asp:Label>
        <asp:TextBox ID="txtAppointmentID" runat="server" ReadOnly="True"></asp:TextBox>

        <asp:Label ID="lblFullName" runat="server" Text="Full Name:" AssociatedControlID="txtFullName"></asp:Label>
        <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>

        <asp:Label ID="lblNRIC" runat="server" Text="NRIC:" AssociatedControlID="txtNRIC"></asp:Label>
        <asp:TextBox ID="txtNRIC" runat="server"></asp:TextBox>

        <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:" AssociatedControlID="txtPhoneNumber"></asp:Label>
        <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>

        <asp:Label ID="lblAppointmentDate" runat="server" Text="Appointment Date:" AssociatedControlID="txtAppointmentDate"></asp:Label>
        <asp:TextBox ID="txtAppointmentDate" runat="server"></asp:TextBox>

        <asp:Label ID="lblAppointmentTime" runat="server" Text="Appointment Time:" AssociatedControlID="txtAppointmentTime"></asp:Label>
        <asp:TextBox ID="txtAppointmentTime" runat="server"></asp:TextBox>

        <asp:Label ID="lblGender" runat="server" Text="Gender:" AssociatedControlID="ddlGender"></asp:Label>
        <asp:DropDownList ID="ddlGender" runat="server">
            <asp:ListItem Value="Male">Male</asp:ListItem>
            <asp:ListItem Value="Female">Female</asp:ListItem>
            <asp:ListItem Value="Other">Other</asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="cancel" PostBackUrl="~/ViewAppointments.aspx" />

        <!-- Add lblMessage here for success or error messages -->
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
