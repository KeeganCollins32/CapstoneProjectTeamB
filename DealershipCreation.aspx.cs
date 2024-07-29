using System;
using Capstone1;

namespace Capstone1 {
    public partial class DealershipCreation : BasePage {
        protected void Page_Load(object sender, EventArgs e) {
            // Any necessary code for Page Load
        }

        protected void SubmitButton_Click(object sender, EventArgs e) {
            string dealershipName = DealershipName.Text;
            string dealershipBrand = DealershipBrand.Text;
            string email = Email.Text;
            string password = Password.Text;
            string confirmPassword = ConfirmPassword.Text;
            string phone = Phone.Text;
            string address = Address.Text;
            string userType = "Dealership";

            if (IsValid) {
                // Clear previous error messages
                ErrorMessageDealershipName.Text = "";
                ErrorMessageDealershipBrand.Text = "";
                ErrorMessagePassword.Text = "";
                ErrorMessageConfirmPassword.Text = "";

                // Validate passwords match
                if (password != confirmPassword) {
                    ErrorMessageConfirmPassword.Text = "Passwords do not match.";
                    return;
                }

                var dealershipService = new DealershipService();

                // Add the dealership to the database
                if (dealershipService.CreateDealership(dealershipName, dealershipBrand, email, password, phone, address, userType)) {
                    // Dealership creation successful
                    Response.Redirect("Default.aspx");
                }
                else {
                    // Dealership creation failed
                    ErrorMessageDealershipName.Text = "Dealership creation failed. Please try again.";
                }
            }
        }
    }
}