<%@ Page Title="About Us Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="Capstone1.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Include any page-specific head content here -->
    <!-- Additional page-specific scripts or styles -->
    <style>
        .small-image {
            max-width: 200px; 
            display: block; 
            margin: 20px auto; 
            border-radius: 50%; 
        }
        .AboutUsHeader {
            text-align: center; 
            margin-top: 25px; 
        }
        .AboutUsHeader h1 {
            color: #ff6347; 
            font-size: 36px; 
            margin-bottom: 10px;
        }
        .AboutUsHeader h2 {
            color: #000; 
            font-size: 24px; 
            margin-bottom: 20px; 
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header Section -->
    <!-- Main Content -->
    <div class="content">
        <div class="AboutUsHeader">
            <h1>Our Story</h1>
            <h2>Cincy Dent Repair: Where Challenges Become Solutions</h2>
        </div>
        <!-- Services section -->
        <div class="services">
            <div class="service left">
                <div class="service-text">
                    <p>Chris Young's journey into the dent repair industry is a story of determination and entrepreneurial spirit. After spending years in various jobs, Chris decided to take a leap of faith. In 2017, he became his own employer and ventured into the dent repair business. Starting small, Chris built his reputation as a skilled traveling dent repair specialist.</p>
                </div>
                <div class="service-image">
                    <img src="https://picsum.photos/450/250" alt="Service Image 3" />
                </div>
            </div>
            <div class="service right">
                <div class="service-text">
                    <p>Fast forward to 2024, Chris's business has flourished. He not only caters to individual customer orders for dent repair but also partners with multiple dealerships. These dealerships rely on Chris for routine dent repairs across their vehicle inventory and count on him for emergency services, such as fixing damage from hailstorms that can affect numerous cars simultaneously.</p>
                </div>
                <div class="service-image">
                    <img src="https://picsum.photos/450/250" alt="Service Image 4" />
                </div>
            </div>
            <div class="service left">
                <div class="service-text">
                    <p>Chris's commitment to quality service and customer satisfaction has made Cincy Dent Repair a trusted name in the industry. Whether you're an individual car owner or a dealership, Chris's expertise ensures your vehicle is in the best hands.</p>
                </div>
            </div>
        </div>
        <!-- Contact Info section -->
        <section class="contact-info">
            <div class="image-container">
                <img src="https://picsum.photos/200/200" alt="Small Image" class="small-image" />
                <p><strong>Chris Young</strong></p>
            </div>
            <h1>We're Here to Help</h1>
            <p>Email: <a href="mailto:hello@relume.io">hello@relume.io</a></p>
            <p>Phone: <a href="tel:+15550000000">+1 (555) 000-0000</a></p>
            <p>Office: 123 Sample St, Sydney NSW 2000 AU</p>
        </section>
    </div>
</asp:Content>
