<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAppointments.aspx.cs" Inherits="Bella.ViewAppointments" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Appointments</title>
    <style>
        table {
            width: 100%;
            border-collapse: collapse;
        }

        th, td {
            border: 1px solid black;
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Appointments</h1>
        <asp:GridView ID="gv_Appointments" runat="server" AutoGenerateColumns="False" DataKeyNames="AppointmentID" 
            OnRowEditing="gv_Appointments_RowEditing" 
            OnRowUpdating="gv_Appointments_RowUpdating" 
            OnRowCancelingEdit="gv_Appointments_RowCancelingEdit" 
            OnRowDeleting="gv_Appointments_RowDeleting" OnSelectedIndexChanged="gv_Appointments_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="AppointmentID" HeaderText="AppointmentID" ReadOnly="True" />
                <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                <asp:BoundField DataField="NRIC" HeaderText="NRIC" />
                <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                <asp:BoundField DataField="AppointmentDate" HeaderText="Appointment Date" />
                <asp:BoundField DataField="AppointmentTime" HeaderText="Appointment Time" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Update" PostBackUrl='<%# "~/AppointmentEdit.aspx?AppointmentID=" + Eval("AppointmentID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" 
                            PostBackUrl='<%# "~/AppointmentDelete.aspx?AppointmentID=" + Eval("AppointmentID") %>' 
                            OnClientClick="return confirm('Are you sure you want to delete this appointment?');" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
