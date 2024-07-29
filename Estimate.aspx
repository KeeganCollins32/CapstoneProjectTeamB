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
            flex: 1;
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
            margin: 40px auto;
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
            width: fit-content; 
            margin: 20px auto; 
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

        .error-message {
            color: red;
            font-size: 12px;
            margin-top: -10px;
            margin-bottom: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contentEstimate">
        <!-- Hero Section -->
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
                <!-- Label for success or error messages related to image upload -->
                <asp:Label ID="uploadMessage" runat="server" CssClass="success-message" />
                <asp:Label ID="uploadErrorMessage" runat="server" CssClass="error-message" />
                <!-- FileUpload control for selecting images -->
                <label for="FileUpload">Once you've selected your images, press the Upload Images button</label>
                <asp:FileUpload ID="FileUploadControl" runat="server" CssClass="form-control" AllowMultiple="true" />
            </div>
            <div class="form-group">
                <!-- Button to trigger the image upload process -->
                <asp:Button ID="UploadImageButton" runat="server" Text="Upload Images" CssClass="button-primary" OnClick="UploadImageButton_Click" />
            </div>
            <div class="form-group">
                <!-- ListBox to display the uploaded images -->
                <asp:ListBox ID="UploadedImagesList" runat="server" CssClass="form-control" Height="200px"></asp:ListBox>
            </div>
        </div>

        <!-- Estimate Form -->
        <div class="estimate-form">
            <h2>Complete Estimate Form</h2>

            <div class="form-group">
                <!-- RequiredFieldValidator for the First Name field -->
                <asp:RequiredFieldValidator ID="FirstNameRequired" runat="server" ControlToValidate="FirstNameTextBox" ErrorMessage="First Name is required" CssClass="error-message" />
                <label for="FirstName">First Name</label>
                <asp:TextBox ID="FirstNameTextBox" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <!-- RequiredFieldValidator for the Last Name field -->
                <asp:RequiredFieldValidator ID="LastNameRequired" runat="server" ControlToValidate="LastNameTextBox" ErrorMessage="Last Name is required" CssClass="error-message" />
                <label for="LastName">Last Name</label>
                <asp:TextBox ID="LastNameTextBox" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <!-- RequiredFieldValidator and RegularExpressionValidator for the Email field -->
                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="Email is required" CssClass="error-message" />
                <asp:RegularExpressionValidator ID="EmailRegularExpression" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="Invalid email address" CssClass="error-message" ValidationExpression="\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b" />
                <label for="Email">Email</label>
                <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control" TextMode="Email" />
            </div>
            <div class="form-group">
                <!-- RequiredFieldValidator for the Phone Number field -->
                <asp:RequiredFieldValidator ID="PhoneNumberRequired" runat="server" ControlToValidate="PhoneNumberTextBox" ErrorMessage="Phone Number is required" CssClass="error-message" />
                <label for="PhoneNumber">Phone Number</label>
                <asp:TextBox ID="PhoneNumberTextBox" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <!-- RequiredFieldValidator for the Vehicle Brand dropdown -->
                <asp:RequiredFieldValidator ID="VehicleBrandRequired" runat="server" ControlToValidate="VehicleBrandDropDown" InitialValue="" ErrorMessage="Vehicle Brand is required" CssClass="error-message" />
                <label for="VehicleBrand">Vehicle Brand</label>
                <asp:DropDownList ID="VehicleBrandDropDown" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="VehicleBrandDropDown_SelectedIndexChanged">
                    <asp:ListItem Text="Select Brand" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <!-- RequiredFieldValidator for the Vehicle Model dropdown -->
                <asp:RequiredFieldValidator ID="VehicleModelRequired" runat="server" ControlToValidate="VehicleModelDropDown" InitialValue="" ErrorMessage="Vehicle Model is required" CssClass="error-message" />
                <label for="VehicleModel">Vehicle Model</label>
                <asp:DropDownList ID="VehicleModelDropDown" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="VehicleModelDropDown_SelectedIndexChanged">
                    <asp:ListItem Text="Select Model" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <!-- RequiredFieldValidator for the Vehicle Year dropdown -->
                <asp:RequiredFieldValidator ID="VehicleYearRequired" runat="server" ControlToValidate="VehicleYearDropDown" InitialValue="" ErrorMessage="Vehicle Year is required" CssClass="error-message" />
                <label for="VehicleYear">Vehicle Year</label>
                <asp:DropDownList ID="VehicleYearDropDown" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Select Year" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <!-- RequiredFieldValidator for the Message field -->
                <asp:RequiredFieldValidator ID="MessageRequired" runat="server" ControlToValidate="MessageTextBox" ErrorMessage="Message is required" CssClass="error-message" />
                <label for="Message">Message</label>
                <asp:TextBox ID="MessageTextBox" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
            </div>
            <div class="form-group">
                <!-- Button to submit the estimate form -->
                <asp:Button ID="SubmitEstimateButton" runat="server" Text="Submit Estimate" CssClass="button-primary" OnClick="SubmitEstimateButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>

