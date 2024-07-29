<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TermsOfService.aspx.cs" Inherits="Capstone1.TermsOfService" %>
<%@ MasterType VirtualPath="~/site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-title {
            text-align: center;
            color: #ff6347;
            font-size: 36px;
            margin-bottom: 20px;
        }

        .terms-container {
            text-align: center;
            margin: 20px auto;
        }

        .terms-content {
            display: inline-block;
            text-align: left;
            width: 80%; 
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            margin: 0 auto; 
        }

        .terms-content h2 {
            color: #ff6347; 
        }

        .terms-content p, .terms-content ul {
            font-size: 16px;
            line-height: 1.6;
            color: #333;
        }

        .terms-content ul {
            list-style-type: disc;
            margin-left: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <!-- Page title for the terms of service -->
        <h1 class="page-title">Terms of Service</h1>
        <div class="terms-container">
            <!-- Container for the terms content -->
            <div class="terms-content">
                <!-- Section: Welcome -->
                <h2>Welcome</h2>
                <p>Welcome to our website. If you continue to browse and use this website, you are agreeing to comply with and be bound by the following terms and conditions of use, which together with our privacy policy govern [Your Company Name]'s relationship with you in relation to this website. If you disagree with any part of these terms and conditions, please do not use our website.</p>

                <!-- Section: Usage -->
                <h2>Usage</h2>
                <p>The content of the pages of this website is for your general information and use only. It is subject to change without notice.</p>

                <!-- Section: Privacy -->
                <h2>Privacy</h2>
                <p>Your privacy is important to us. Please read our privacy policy for more information.</p>

                <!-- Section: Changes to Terms -->
                <h2>Changes to Terms</h2>
                <p>We may change these terms at any time. Your continued use of the website means that you accept any new or modified terms and conditions.</p>

                <!-- Section: Contact -->
                <h2>Contact</h2>
                <p>If you have any questions about these terms, please contact us at <asp:HyperLink ID="ContactLink" runat="server" NavigateUrl="~/AboutUs.aspx">Contact Us</asp:HyperLink>.</p>
            </div>
        </div>
    </div>
</asp:Content>
