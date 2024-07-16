<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Capstone1.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Include any page-specific head content here -->
    <!-- Additional page-specific scripts or styles -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header Section -->
    <!-- Main Content -->
    <div class="content">
        <div class="hero">
            <!-- Hero slider content -->
            <div class="hero-slider">
                <div class="hero-slide">
                    <img src="https://picsum.photos/1200/600?random=1" alt="Slide 1" />
                    <div class="hero-text">
                        <h1>Welcome to Cincy Dent Repair</h1>
                        <h2>Expert Dent Removal Services</h2>
                        <p>At Cincy Dent Repair, we specialize in providing top-notch, mobile dent repair solutions tailored to your needs.</p>
                        <button class="button-primary">Get a Quote</button>
                    </div>
                </div>
                <div class="hero-slide">
                    <img src="https://picsum.photos/1200/600?random=2" alt="Slide 2" />
                    <div class="hero-text">
                        <h1>Quality and Efficiency</h1>
                        <h2>Repairing Dents with Precision</h2>
                        <p>Our skilled technicians use advanced techniques to ensure your vehicle looks flawless again.</p>
                        <button class="button-primary">Learn More</button>
                    </div>
                </div>
                <!-- Add more slides as needed -->
            </div>
        </div>

        <div class="services">
            <!-- Services section -->
            <div class="service left">
                <div class="service-text">
                    <h2>For Customers</h2>
                    <p>Easily enter your personal information and vehicle details for accurate estimates.</p>
                    <asp:Button ID="CustomerEstimateButton" runat="server" Text="Get Estimate" CssClass="button-secondary" />
                </div>
                <div class="service-image">
                    <img src="https://picsum.photos/800/600" alt="Service Image 1" />
                </div>
            </div>
            <div class="service right">
                <div class="service-image">
                    <img src="https://picsum.photos/800/600" alt="Service Image 2" />
                </div>
                <div class="service-text">
                    <h2>For Dealerships</h2>
                    <p>Effortlessly submit multiple vehicle details and damage photos for estimates.</p>
                    <asp:Button ID="CreateAccountButton" runat="server" Text="Create Account" CssClass="button-secondary" PostBackUrl="~/SignUp.aspx" />
                </div>
            </div>
        </div>

        <div class="features">
            <!-- Features section -->
            <div class="feature left">
                <div class="feature-image">
                    <img src="https://picsum.photos/800/600" alt="Feature Image 1" />
                </div>
                <div class="feature-text">
                    <h3>Quick Turnaround Time</h3>
                    <p>We understand the importance of getting your vehicle repaired quickly. Our dedicated team works efficiently to ensure a fast turnaround time.</p>
                </div>
            </div>
            <div class="feature right">
                <div class="feature-text">
                    <h3>Reliable Service</h3>
                    <p>Our experienced technicians provide reliable and high-quality repairs for your vehicle. You can count on us to get the job done right.</p>
                </div>
                <div class="feature-image">
                    <img src="https://picsum.photos/800/600" alt="Feature Image 2" />
                </div>
            </div>
            <div class="feature left">
                <div class="feature-image">
                    <img src="https://picsum.photos/800/600" alt="Feature Image 3" />
                </div>
                <div class="feature-text">
                    <h3>Exceptional Support</h3>
                    <p>We pride ourselves on delivering exceptional customer support. Our friendly staff is available to assist you throughout the entire repair process.</p>
                </div>
            </div>
        </div>

        <div class="faqs">
            <!-- FAQs section -->
            <h3>Have Questions? We've Got Answers.</h3>
            <p>Check out our frequently asked questions section to find answers to common inquiries. If you can't find what you're looking for, feel free to contact us directly.</p>
            <asp:Button ID="FAQButton" runat="server" Text="View FAQs" CssClass="button-secondary" />
        </div>  
    </div>
</asp:Content>