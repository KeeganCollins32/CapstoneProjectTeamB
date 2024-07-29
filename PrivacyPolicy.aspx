<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrivacyPolicy.aspx.cs" Inherits="Capstone1.PrivacyPolicy" %>
<%@ MasterType VirtualPath="~/site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-title {
            text-align: center;
            color: #ff6347;
            font-size: 36px;
            margin-bottom: 20px;
        }

        .policy-container {
            text-align: center;
            margin: 20px auto; 
        }

        .policy-content {
            display: inline-block;
            text-align: left;
            width: 80%; 
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            margin: 0 auto;
        }

        .policy-content h2 {
            color: #ff6347;
        }

        .policy-content p, .policy-content ul {
            font-size: 16px;
            line-height: 1.6;
            color: #333;
        }

        .policy-content ul {
            list-style-type: disc;
            margin-left: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <!-- Page title for the privacy policy -->
        <h1 class="page-title">Privacy Policy</h1>
        <div class="policy-container">
            <!-- Container for the privacy policy content -->
            <div class="policy-content">
                <!-- Section: Introduction -->
                <h2>Introduction</h2>
                <p>We value your privacy and are committed to protecting your personal data. This privacy policy will inform you about how we look after your personal data when you visit our website and tell you about your privacy rights and how the law protects you.</p>

                <!-- Section: Information We Collect -->
                <h2>Information We Collect</h2>
                <p>We may collect, use, store and transfer different kinds of personal data about you which we have grouped together as follows:</p>
                <ul>
                    <li>Identity Data: includes first name, last name, username or similar identifier.</li>
                    <li>Contact Data: includes billing address, delivery address, email address and telephone numbers.</li>
                    <li>Technical Data: includes internet protocol (IP) address, browser type and version, time zone setting and location, browser plug-in types and versions, operating system and platform, and other technology on the devices you use to access this website.</li>
                    <li>Profile Data: includes your username and password, purchases or orders made by you, your interests, preferences, feedback and survey responses.</li>
                    <li>Usage Data: includes information about how you use our website, products and services.</li>
                    <li>Marketing and Communications Data: includes your preferences in receiving marketing from us and your communication preferences.</li>
                </ul>

                <!-- Section: How We Use Your Personal Data -->
                <h2>How We Use Your Personal Data</h2>
                <p>We use your personal data in the following ways:</p>
                <ul>
                    <li>To process and manage your account.</li>
                    <li>To deliver and improve our services.</li>
                    <li>To communicate with you, including responding to your queries and sending you updates.</li>
                    <li>To personalize your experience on our website.</li>
                    <li>To comply with legal obligations and protect our rights.</li>
                </ul>

                <!-- Section: Data Retention -->
                <h2>Data Retention</h2>
                <p>We will retain your personal data only for as long as necessary to fulfill the purposes for which it was collected, or as required by law. Once the data is no longer needed, we will securely delete or anonymize it.</p>

                <!-- Section: Your Rights -->
                <h2>Your Rights</h2>
                <p>You have rights under data protection laws, including:</p>
                <ul>
                    <li>The right to access your personal data.</li>
                    <li>The right to rectify inaccurate or incomplete data.</li>
                    <li>The right to request erasure of your data under certain conditions.</li>
                    <li>The right to object to processing based on legitimate interests.</li>
                    <li>The right to request restriction of processing under certain circumstances.</li>
                    <li>The right to data portability.</li>
                </ul>

                <!-- Section: Security Measures -->
                <h2>Security Measures</h2>
                <p>We implement appropriate technical and organizational measures to protect your personal data from unauthorized access, disclosure, alteration, or destruction. However, no method of transmission over the internet or electronic storage is completely secure.</p>

                <!-- Section: Third-Party Links -->
                <h2>Third-Party Links</h2>
                <p>Our website may contain links to third-party sites. We are not responsible for the privacy policies or practices of these sites. We encourage you to read their privacy policies before providing any personal data.</p>

                <!-- Section: Changes to This Privacy Policy -->
                <h2>Changes to This Privacy Policy</h2>
                <p>We may update this privacy policy from time to time. Any changes will be posted on this page with an updated revision date. Your continued use of the website after any changes indicates your acceptance of the revised policy.</p>

                <!-- Section: Contact Us -->
                <h2>Contact Us</h2>
                <p>If you have any questions or concerns about this privacy policy or our data practices, please contact us at [Contact Information].</p>
            </div>
        </div>
    </div>
</asp:Content>