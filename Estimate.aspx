<%@ Page Title="Estimate" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Estimate.aspx.cs" Inherits="Capstone1.Estimate" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" />
    <style>
        .contentEstimate {
            padding: 20px 20px;
            margin-top: 60px;
            background-color: #fff;
            margin: 20px auto;
            max-width: 1400px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .hero {
            color: #fff;
            text-align: center;
            margin-top: 160px;
            padding-bottom: 10px;
        }

        .hero-text {
            max-width: 800px;
            margin: 0 auto;
        }

        .hero-text h1 {
            margin-bottom: 10px;
            font-size: 36px;
        }

        .hero-text p {
            margin-top: 0;
            font-size: 18px;
        }

        .estimate-form, .upload-image-form {
            max-width: 50%;
            margin: 40px auto; /* Adjust margin as needed */
            padding: 20px;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .estimate-form h2, .upload-image-form h2 {
            color: #333;
        }

        .form-group {
            margin-bottom: 15px;
            text-align: left;
        }

        .form-group label {
            display: block;
            color: #555;
            margin-bottom: 5px;
        }

        .form-control {
            width: calc(100% - 20px);
            padding: 10px;
            margin: 0 auto;
            font-size: 16px;
        }

        .button-primary {
            display: block;
            width: fit-content; /* Ensures button width fits its content */
            margin: 20px auto; /* Center horizontally with auto margins */
            padding: 10px 20px;
            background-color: #ff6347;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            text-align: center;
        }

        .button-primary:hover {
            background-color: #e5533a;
        }

        .clearfix::after {
            content: "";
            display: table;
            clear: both;
        }
          
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="contentEstimate">
    <div class="hero">
        <div class="hero-text">
            <h1>Get Your Free Estimate</h1>
            <p>Fill out the forms below to get a free estimate for your vehicle repair.</p>
        </div>
    </div>

    <!-- Upload Image Form -->
    <div class="upload-image-form">
        <h2>Upload Detailed Images</h2>
        <div class="form-group">
            <label for="FileUpload">Once you've selected your images, press the Upload Images button</label>
            <asp:FileUpload ID="FileUpload" runat="server" CssClass="form-control" AllowMultiple="true" />
        </div>
        <div class="form-group">
            <asp:Button ID="UploadImageButton" runat="server" Text="Upload Images" CssClass="button-primary" OnClick="UploadImageButton_Click" />
        </div>
    </div>

    <div class="estimate-form">
        <h2>Complete Estimate Form</h2>
        <div class="form-group">
            <label for="FirstName">First Name</label>
            <asp:TextBox ID="FirstName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="LastName">Last Name</label>
            <asp:TextBox ID="LastName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Email">Email</label>
            <asp:TextBox ID="Email" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="PhoneNumber">Phone Number</label>
            <asp:TextBox ID="PhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="VehicleBrand">Vehicle Brand</label>
            <asp:DropDownList ID="VehicleBrand" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Brand" Value=""></asp:ListItem>
                <asp:ListItem Text="Toyota" Value="Toyota"></asp:ListItem>
                <asp:ListItem Text="Honda" Value="Honda"></asp:ListItem>
                <asp:ListItem Text="Ford" Value="Ford"></asp:ListItem>     
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="VehicleModel">Vehicle Model</label>
            <asp:DropDownList ID="VehicleModel" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Model" Value=""></asp:ListItem>
                <asp:ListItem Text="Camry" Value="Camry"></asp:ListItem>
                <asp:ListItem Text="Accord" Value="Accord"></asp:ListItem>
                <asp:ListItem Text="Mustang" Value="Mustang"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="VehicleYear">Vehicle Year</label>
            <asp:DropDownList ID="VehicleYear" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Year" Value=""></asp:ListItem>
                <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="Message">Message</label>
            <asp:TextBox ID="Message" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="AcceptTerms">Accept Terms</label>
            <asp:CheckBox ID="AcceptTerms" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <asp:Button ID="Button2" runat="server" Text="Submit" CssClass="button-primary" OnClick="SubmitButton_Click" />
        </div>
    </div>

    <div class="contact-info">
        <h2>Contact Information</h2>
        <p>For further inquiries, please contact us at:</p>
        <p>Email: support@cindydentrepair.com</p>
        <p>Phone: +1 (123) 456-7890</p>
        <p>Address: 100 Smith Street Collingwood VIC 3066 AU</p>
    </div>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SubscribeContent" runat="server">
    <!-- Subscribe section -->
    <div class="subscribe">
        <h3>Stay Updated with Our Latest Offers and News</h3>
        <p>Subscribe to our newsletter to receive updates on our services, special offers, and industry news. Don't miss out on valuable information that can benefit you.</p>
        <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control" placeholder="Enter your email address" />
        <asp:Button ID="SubscribeButton" runat="server" Text="Subscribe" CssClass="button-primary" />
    </div>
</asp:Content>