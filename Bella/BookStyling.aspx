<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookStyling.aspx.cs" Inherits="Bella.BookStyling" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book an Appointment</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 192px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Book A New Appointment</h1>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Full Name</td>
                <td>
                    <asp:TextBox ID="tb_FullName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">NRIC</td>
                <td>
                    <asp:TextBox ID="tb_NRIC" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Phone Number</td>
                <td>
                    <asp:TextBox ID="tb_Hp" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Appointment Date</td>
                <td>
                    <!-- Calendar control for selecting a date -->
                    <asp:Calendar ID="cal_Date" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Appointment Time</td>
                <td>
                    <!-- Dropdown for selecting time -->
                    <asp:DropDownList ID="ddl_Time" runat="server">
                        <asp:ListItem Text="09:00 AM" Value="09:00 AM"></asp:ListItem>
                        <asp:ListItem Text="10:00 AM" Value="10:00 AM"></asp:ListItem>
                        <asp:ListItem Text="11:00 AM" Value="11:00 AM"></asp:ListItem>
                        <asp:ListItem Text="12:00 PM" Value="12:00 PM"></asp:ListItem>
                        <asp:ListItem Text="01:00 PM" Value="01:00 PM"></asp:ListItem>
                        <asp:ListItem Text="02:00 PM" Value="02:00 PM"></asp:ListItem>
                        <asp:ListItem Text="03:00 PM" Value="03:00 PM"></asp:ListItem>
                        <asp:ListItem Text="04:00 PM" Value="04:00 PM"></asp:ListItem>
                        <asp:ListItem Text="05:00 PM" Value="05:00 PM"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:Panel ID="Panel1" runat="server" GroupingText="GENDER">
            <asp:RadioButtonList ID="rbl_Gender" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </asp:Panel>
        <asp:Button ID="btn_Back" runat="server" Text="Back" />
        <asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click" />
    </form>
</body>
</html>
