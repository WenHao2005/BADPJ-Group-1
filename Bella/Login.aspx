<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bella.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link href="CSS/Site1.css" rel="stylesheet" />
    <link href="CSS/Login.css" rel="stylesheet" />
</head>
<body class="is-preload homepage">
    <div id="page-wrapper">

<!-- Header -->
	<div id="header-wrapper">
		<header id="header" class="container">

			<!-- Logo -->
				<div id="logo">
					<h1><a href="homepage.aspx">Bella</a></h1>
				</div>

			<!-- Nav -->
				<nav id="nav">
					<ul>
						<li><a href="homepage.aspx">Welcome</a></li>
						<li class="current"><a href="Login.aspx">Login/Signup</a></li>
					</ul>
				</nav>

		</header>
	</div>


<!-- Login -->
        <form id="form1" runat="server">
            <div style="width: 300px; margin: auto; padding-top: 50px;">
                <h2>Login</h2>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="lblUsername" runat="server" Text="Username or Email:"></asp:Label><br />
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br /><br />
                
                <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label><br />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br /><br />
                
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />

				<br /><br />

                <!-- Add the clickable label here -->
               <asp:HyperLink ID="hlRegister" runat="server" NavigateUrl="Register.aspx" Text="Register here" ForeColor="Blue" />
            </div>
        </form>
    </div>

            	<!-- Footer -->
		<div id="footer-wrapper">
			<footer id="footer" class="container">
				<div class="row">
					<div class="col-3 col-6-medium col-12-small">

						<!-- Links -->
							<section class="widget links">
								<h3>Random Stuff</h3>
								<ul class="style2">
									<li><a href="#">Etiam feugiat condimentum</a></li>
									<li><a href="#">Aliquam imperdiet suscipit odio</a></li>
									<li><a href="#">Sed porttitor cras in erat nec</a></li>
									<li><a href="#">Felis varius pellentesque potenti</a></li>
									<li><a href="#">Nullam scelerisque blandit leo</a></li>
								</ul>
							</section>

					</div>
					<div class="col-3 col-6-medium col-12-small">

						<!-- Links -->
							<section class="widget links">
								<h3>Random Stuff</h3>
								<ul class="style2">
									<li><a href="#">Etiam feugiat condimentum</a></li>
									<li><a href="#">Aliquam imperdiet suscipit odio</a></li>
									<li><a href="#">Sed porttitor cras in erat nec</a></li>
									<li><a href="#">Felis varius pellentesque potenti</a></li>
									<li><a href="#">Nullam scelerisque blandit leo</a></li>
								</ul>
							</section>

					</div>
					<div class="col-3 col-6-medium col-12-small">

						<!-- Links -->
							<section class="widget links">
								<h3>Random Stuff</h3>
								<ul class="style2">
									<li><a href="#">Etiam feugiat condimentum</a></li>
									<li><a href="#">Aliquam imperdiet suscipit odio</a></li>
									<li><a href="#">Sed porttitor cras in erat nec</a></li>
									<li><a href="#">Felis varius pellentesque potenti</a></li>
									<li><a href="#">Nullam scelerisque blandit leo</a></li>
								</ul>
							</section>

					</div>
					<div class="col-3 col-6-medium col-12-small">

						<!-- Contact -->
							<section class="widget contact last">
								<h3>Contact Us</h3>
								<ul>
									<li><a href="#" class="icon brands fa-twitter"><span class="label">Twitter</span></a></li>
									<li><a href="#" class="icon brands fa-facebook-f"><span class="label">Facebook</span></a></li>
									<li><a href="#" class="icon brands fa-instagram"><span class="label">Instagram</span></a></li>
									<li><a href="#" class="icon brands fa-dribbble"><span class="label">Dribbble</span></a></li>
									<li><a href="#" class="icon brands fa-pinterest"><span class="label">Pinterest</span></a></li>
								</ul>
								<p>1234 Fictional Road<br />
								Nashville, TN 00000<br />
								(800) 555-0000</p>
							</section>

					</div>
				</div>
				<div class="row">
					<div class="col-12">
						<div id="copyright">
							<ul class="menu">
								<li>&copy; Untitled. All rights reserved</li><li>Design: <a href="http://html5up.net">HTML5 UP</a></li>
							</ul>
						</div>
					</div>
				</div>
			</footer>
		</div>

<!-- Scripts -->


	<script src="assets/js/jquery.min.js"></script>
	<script src="assets/js/jquery.dropotron.min.js"></script>
	<script src="assets/js/browser.min.js"></script>
	<script src="assets/js/breakpoints.min.js"></script>
	<script src="assets/js/util.js"></script>
	<script src="assets/js/main.js"></script>

</body>
</html>
