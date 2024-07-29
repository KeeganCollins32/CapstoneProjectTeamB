<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="Capstone1.Invoices" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-title {
            text-align: center;
            color: #ff6347;
            font-size: 36px;
            margin-bottom: 20px;
        }

        .invoices-container {
            text-align: center;
            margin: 20px auto;
        }

        .invoices-content {
            display: inline-block;
            text-align: left;
            width: 80%;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        
        .table {
            width: 100%;
            border-collapse: collapse;
        }

        .table th, .table td {
            border: 1px solid #ddd;
            padding: 8px;
        }

        .table th {
            background-color: #f2f2f2;
            text-align: left;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <!-- Page title for user invoices -->
        <h1 class="page-title">User Invoices</h1>
        <div class="invoices-container">
            <!-- Container for the invoices content -->
            <div class="invoices-content">
                <!-- GridView to display invoices data -->
                <asp:GridView ID="GridViewInvoices" runat="server" AutoGenerateColumns="False" CssClass="table">
                    <Columns>
                        <!-- Column for Invoice ID -->
                        <asp:BoundField DataField="InvoiceID" HeaderText="Invoice ID" />
                        <!-- Column for Customer Name -->
                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                        <!-- Column for Amount with currency format -->
                        <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:C}" />
                        <!-- Column for Date Paid with date format -->
                        <asp:BoundField DataField="DatePaid" HeaderText="Date Paid" DataFormatString="{0:MM/dd/yyyy}" />
                        <!-- Column for Vehicle Brand -->
                        <asp:BoundField DataField="VehicleBrand" HeaderText="Vehicle Brand" />
                        <!-- Column for Vehicle Model -->
                        <asp:BoundField DataField="VehicleModel" HeaderText="Vehicle Model" />
                        <!-- Column for Vehicle Year -->
                        <asp:BoundField DataField="VehicleYear" HeaderText="Vehicle Year" />
                        <!-- Column for Job Date with date format -->
                        <asp:BoundField DataField="JobDate" HeaderText="Job Date" DataFormatString="{0:MM/dd/yyyy}" />
                        <!-- Column for Technician Name -->
                        <asp:BoundField DataField="TechnicianName" HeaderText="Technician Name" />
                        <!-- Column for Job Description -->
                        <asp:BoundField DataField="JobDescription" HeaderText="Job Description" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

