<!DOCTYPE HTML>
<html>
<head>
    <title>Services</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link href="CSS/Site1.css" rel="stylesheet" />
    <style>
        /* Additional Styles for Services Section */
        .services-container {
            text-align: center;
            padding: 20px;
        }

        .services {
            display: flex;
            justify-content: space-around; /* Space out items */
            gap: 20px; /* Add spacing between items */
            flex-wrap: wrap; /* Wrap items if viewport is too small */
            margin-top: 20px;
        }

        .service {
            border: 1px solid #ddd; /* Optional: Add border for styling */
            border-radius: 8px; /* Rounded corners */
            padding: 20px;
            width: 300px; /* Fixed width for uniformity */
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); /* Optional: Add shadow */
        }

        .service img {
            max-width: 100%; /* Ensure images fit within the container */
            height: auto;
            border-radius: 5px; /* Optional: Rounded corners for images */
        }

        .service button {
            margin-top: 10px;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
        }

        /* Responsive Design */
        @media (max-width: 768px) {
            .services {
                flex-direction: column; /* Stack items vertically on small screens */
                align-items: center;
            }

            .service {
                width: 90%; /* Adjust width for smaller screens */
            }
        }
    </style>
</head>
<body>
    <!-- Header -->
    <div id="header-wrapper">
        <header id="header" class="container">
            <!-- Logo -->
            <div id="logo">
                <h1><a href="Products.aspx">Bella</a></h1>
            </div>

            <!-- Nav -->
            <nav id="nav">
                <ul>
                    <li><a href="Products.aspx">Welcome</a></li>
                    <li><a href="Homepage.aspx">Logout</a></li>
                    <li><a href="Products.aspx">Products</a></li>
                    <li><a href="Donations.aspx">Donations</a></li>
                    <li><a href="Cart.aspx">Cart</a></li>
                    <li class="current"><a href="Services.aspx">Services</a></li>
                    <li style="float: right;">
                        <asp:Label ID="lblLoggedInUser" runat="server" Text=""></asp:Label>
                    </li>
                </ul>
            </nav>
        </header>
    </div>

    <!-- Services Section -->
    <div class="services-container">
        <h1 style="font-size: 40px;">Our Services</h1>
        <div class="services">
            <!-- Service 1 -->
            <div class="service">
                <img src="WHtailoring.jpg.png" alt="Professional Tailoring">
                <h5>Paid Professional Tailoring & Styling Services</h5>
                <p>Get personalized styling and tailoring to fit your needs.</p>
                <p>Comprehensive, hands-on consultation.</p>
                <p>Private session with a tailor for color matching, style consultation, and wardrobe curation.</p>
                <button onclick="location.href='BookStyling.aspx'" style="background-color: #FF1493; color: white;">Book an Appointment</button>
            </div>

            <!-- Service 2 -->
            <div class="service">
                <img src="WHsurvey.jpg.png" alt="Styling Survey">
                <h5>Free Online Styling Profile Survey</h5>
                <p>Discover your unique style with our survey.</p>
                <button onclick="location.href='Survey.aspx'" style="background-color: #FF1493; color: white;">Take Survey</button>
            </div>

            <!-- Service 3 -->
            <div class="service">
                <img src="WHcharityclothing.jpg.jpeg" alt="Charity Collection">
                <h5>Charity Clothing Collection Program</h5>
                <p>Contribute to those in need by donating your clothes.</p>
                <button onclick="location.href='DonateClothes.aspx'" style="background-color: #FF1493; color: white;">Donate Clothes</button>
            </div>
        </div>
    </div>
</body>
</html>
