<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Capstone1.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-title {
            text-align: center;
            color: #ff6347;
            font-size: 36px;
            margin-bottom: 20px;
        }

        .login-container {
            text-align: center;
            margin-top: 20px;
            margin-left: 420px;
        }

        .login-form {
            display: inline-block;
            text-align: left;
            width: 300px; /* Adjust width as needed */
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .login-label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }

        .login-input {
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

        .login-checkbox {
            display: inline-block;
            margin-bottom: 10px;
        }

        .centered {
            text-align: center;
        }

        .login-button {
            display: block;
            width: 100%;
            margin-top: 10px;
            text-align: center;
        }

        .forgot-password,
        .signup-link {
            display: block;
            text-align: center;
            margin: 10px 0;
            color: #ff6347;
            text-decoration: none;
        }

        .forgot-password:hover,
        .signup-link:hover {
            color: #e5533a;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <h1 class="page-title">Login - Cincy Dent Repair</h1>
        <div class="login-container">
            <asp:Login ID="Login1" runat="server">
                <LayoutTemplate>
                    <div class="login-form">
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="login-label">Email or Username:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="login-input"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="The username is required." CssClass="error-message" />

                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="login-label">Password:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="login-input"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="The password is required." CssClass="error-message" />

                        <div class="centered">
                            <asp:CheckBox ID="RememberMe" runat="server" CssClass="login-checkbox" Text="Remember me" />
                        </div>

                        <div class="login-button">
                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" CssClass="button-primary" />
                        </div>

                        <asp:HyperLink ID="ForgotPasswordLink" runat="server" NavigateUrl="ForgotPassword.aspx" CssClass="forgot-password">Forgot password?</asp:HyperLink>

                        <div class="signup-link">
                            Don’t have an account? <asp:HyperLink ID="SignupLink" runat="server" NavigateUrl="Signup.aspx" CssClass="signup-link">Sign up</asp:HyperLink>
                        </div>
                    </div>
                </LayoutTemplate>
            </asp:Login>
        </div>
    </div>
</asp:Content>