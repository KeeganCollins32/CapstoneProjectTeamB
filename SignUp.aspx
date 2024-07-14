<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Capstone1.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-title {
            text-align: center;
            color: #ff6347;
            font-size: 36px;
            margin-bottom: 20px;
        }

        .signup-container {
            text-align: center;
            margin-top: 20px;
            
        }

        .signup-form {
            display: inline-block;
            text-align: left;
            width: 300px; /* Adjust width as needed */
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .signup-label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }

        .signup-input {
            width: calc(100% - 20px); /* Adjust padding for left and right (10px each side) */
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .error-message {
            color: red;
            font-size: 12px;
            margin-top: -10px;
            margin-bottom: 10px;
        }

        .signup-checkbox {
            display: inline-block;
            margin-bottom: 10px;
        }

        .centered {
            text-align: center;
        }

        .signup-button {
            display: block;
            width: 100%;
            margin-top: 10px;
            text-align: center;
        }

        .login-link {
            display: block;
            text-align: center;
            margin: 10px 0;
            color: #ff6347;
            text-decoration: none;
        }

        .login-link:hover {
            color: #e5533a;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <h1 class="page-title">Sign Up - Cincy Dent Repair</h1>
        <div class="signup-container">
            <div class="signup-form">
                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="signup-label">Username:</asp:Label>
                <asp:TextBox ID="UserName" runat="server" CssClass="signup-input"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="The username is required." CssClass="error-message" />

                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email" CssClass="signup-label">Email:</asp:Label>
                <asp:TextBox ID="Email" runat="server" CssClass="signup-input"></asp:TextBox>
                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="The email is required." CssClass="error-message" />
                <asp:RegularExpressionValidator ID="EmailValidator" runat="server" ControlToValidate="Email"
                    ErrorMessage="Please enter a valid email address." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="error-message" />

                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="signup-label">Password:</asp:Label>
                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="signup-input"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="The password is required." CssClass="error-message" />

                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword" CssClass="signup-label">Confirm Password:</asp:Label>
                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CssClass="signup-input"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="Please confirm your password." CssClass="error-message" />
                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    ErrorMessage="The passwords do not match." CssClass="error-message" />

                <div class="centered">
                    <asp:CheckBox ID="AgreeTerms" runat="server" CssClass="signup-checkbox" Text="I agree to the Terms and Conditions" />
                </div>

                <div class="signup-button">
                    <asp:Button ID="SignUpButton" runat="server" Text="Sign Up" CssClass="button-primary" OnClick="SignUpButton_Click" />
                </div>

                <div class="login-link">
                    Already have an account? <asp:HyperLink ID="LoginLink" runat="server" NavigateUrl="Login.aspx" CssClass="login-link">Log in</asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>