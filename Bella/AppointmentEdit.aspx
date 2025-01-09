<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentEdit.aspx.cs" Inherits="Bella.AppointmentEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Appointment</title>
    <style>
        label {
            display: block;
            margin-top: 10px;
        }
        input[type="text"], input[type="date"], input[type="time"] {
            width: 100%;
            padding: 8px;
            margin-top: 5px;
        }
        input[type="submit"] {
            margin-top: 20px;
            padding: 10px 15px;
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Edit Appointment</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <div>
            <label for="txtFullName">Full Name:</label>
            <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="txtNRIC">NRIC:</label>
            <asp:TextBox ID="txtNRIC" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="txtPhoneNumber">Phone Number:</label>
            <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="txtAppointmentDate">Appointment Date:</label>
            <asp:TextBox ID="txtAppointmentDate" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <div>
            <label for="txtAppointmentTime">Appointment Time:</label>
            <asp:TextBox ID="txtAppointmentTime" runat="server" TextMode="Time"></asp:TextBox>
        </div>
        <div>
            <label for="txtGender">Gender:</label>
            <asp:TextBox ID="txtGender" runat="server"></asp:TextBox>
        </div>
        <div>
            <input type="submit" value="Update" onclick="return updateAppointment();" />
        </div>
    </form>
</body>
</html>
