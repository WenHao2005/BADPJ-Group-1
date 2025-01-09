<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentDelete.aspx.cs" Inherits="Bella.AppointmentDelete" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Appointment</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Delete Appointment</h1>
        <asp:Label ID="lblConfirmation" runat="server" Text="Are you sure you want to delete this appointment?" Font-Bold="True" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblAppointmentDetails" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </form>
</body>
</html>
