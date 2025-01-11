<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Bella.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Registration Form</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link href="CSS/Site1.css" rel="stylesheet" />
    <script>
        // Function to show a pop-up message
        function showFailureMessage(message) {
            alert(message);
        }

        // Function to validate the form before submission
        function validateForm() {
            var password = document.getElementById("txtPassword").value;
            var confirmPassword = document.getElementById("txtConfirmPassword").value;
            var phone = document.getElementById("txtPhone").value;
            var postalCode = document.getElementById("txtPostalCode").value;
            var gender = document.getElementById("ddlGender").value;
            var errorMessage = "";

            // Password and Confirm Password validation
            if (password !== confirmPassword) {
                errorMessage += "Passwords do not match. Please check your details again.\n";
            }

            // Phone number validation (must be 8 digits)
            if (phone.length !== 8 || !/^\d{8}$/.test(phone)) {
                errorMessage += "Phone number must be exactly 8 digits. Please check your details again.\n";
            }

            // Postal code validation (must be 6 digits)
            if (postalCode.length !== 6 || !/^\d{6}$/.test(postalCode)) {
                errorMessage += "Postal code must be exactly 6 digits. Please check your details again.\n";
            }

            // Gender validation (must be selected)
            if (gender === "") {
                errorMessage += "Please select your gender.\n";
            }

            if (errorMessage !== "") {
                showFailureMessage(errorMessage);
                return false;  // Prevent form submission
            }

            return true;  // Allow form submission
        }
    </script>
</head>
<body class="is-preload homepage">
    <form id="form1" runat="server" onsubmit="return validateForm();">
        <div style="width: 600px; margin: auto; padding-top: 50px;">
            <h2>Member Registration Form</h2>

            <!-- Error Message Display -->
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br />

            <!-- Username Input (Required) -->
            <div style="margin-bottom: 10px;">
                <asp:Label ID="lblUsername" runat="server" Text="Username: *" style="display: inline-block; width: 150px;"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" style="display: inline-block;"></asp:TextBox>
            </div>

            <!-- Email Input (Required) -->
            <div style="margin-bottom: 10px;">
                <asp:Label ID="lblEmail" runat="server" Text="Email: *" style="display: inline-block; width: 150px;"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" style="display: inline-block;"></asp:TextBox>
            </div>

            <!-- Password Input (Required) -->
            <div style="margin-bottom: 10px;">
                <asp:Label ID="lblPassword" runat="server" Text="Password: *" style="display: inline-block; width: 150px;"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" style="display: inline-block;"></asp:TextBox>
            </div>

            <!-- Confirm Password Input (Required) -->
            <div style="margin-bottom: 10px;">
                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password: *" style="display: inline-block; width: 150px;"></asp:Label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" style="display: inline-block;"></asp:TextBox>
            </div>

            <!-- First Name Input (Required) -->
            <div style="margin-bottom: 10px;">
                <asp:Label ID="lblFirstName" runat="server" Text="First Name: *" style="display: inline-block; width: 150px;"></asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server" style="display: inline-block;"></asp:TextBox>
            </div>

            <!-- Last Name Input (Required) -->
            <div style="margin-bottom: 10px;">
                <asp:Label ID="lblLastName" runat="server" Text="Last Name: *" style="display: inline-block; width: 150px;"></asp:Label>
                <asp:TextBox ID="txtLastName" runat="server" style="display: inline-block;"></asp:TextBox>
            </div>

            <!-- Mobile Number Input (Required) -->
            <div style="margin-bottom: 10px;">
                <asp:Label ID="lblPhone" runat="server" Text="Phone: * (8 digits)" style="display: inline-block; width: 150px;"></asp:Label>
                <asp:TextBox ID="txtPhone" runat="server" MaxLength="8" style="display: inline-block;"></asp:TextBox>
            </div>

            <!-- Street Input (Not Required) -->
            <div style="margin-bottom: 10px;">
                <asp:Label ID="lblStreet" runat="server" Text="Street:" style="display: inline-block; width: 150px;"></asp:Label>
                <asp:TextBox ID="txtStreet" runat="server" style="display: inline-block;"></asp:TextBox>
            </div>

            <!-- Postal Code Input (Required) -->
            <div style="margin-bottom: 10px;">
                <asp:Label ID="lblPostalCode" runat="server" Text="Postal Code: (6 digits)" style="display: inline-block; width: 150px;"></asp:Label>
                <asp:TextBox ID="txtPostalCode" runat="server" MaxLength="6" style="display: inline-block;"></asp:TextBox>
            </div>

            <!-- Gender Dropdown (Required) -->
            <div style="margin-bottom: 10px;">
                <asp:Label ID="lblGender" runat="server" Text="Gender: *" style="display: inline-block; width: 150px;"></asp:Label>
                <asp:DropDownList ID="ddlGender" runat="server" style="display: inline-block;">
                    <asp:ListItem Text="Select Gender" Value=""></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Prefer not to say" Value="Prefer not to say"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <!-- Register Button -->
            <div style="margin-top: 20px;">
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            </div>

            <!-- Link to Login Page -->
            <asp:HyperLink ID="hlLogin" runat="server" NavigateUrl="Login.aspx" Text="Already have an account? Login here" ForeColor="Blue"></asp:HyperLink>
        </div>
    </form>
</body>
</html>
