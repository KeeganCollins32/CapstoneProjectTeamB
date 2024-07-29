using System;
using Capstone1;

namespace Capstone1 {
    public partial class SignUp : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            // Any necessary code for Page Load
        }

        protected void SignUpButton_Click(object sender, EventArgs e) {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string email = Email.Text;
            string password = Password.Text;
            string confirmPassword = ConfirmPassword.Text;
            string phone = Phone.Text;
            string address = Address.Text;
            string userType = "Client"; // Automatically assigning the user type to "Client"

            // Validate passwords match
            if (password != confirmPassword) {
                // Optionally display a message on the page if you want to show feedback
                // e.g., ErrorMessageConfirmPassword.Text = "Passwords do not match.";
                return; // Exit the method if passwords do not match
            }

            var userService = new UserService();

            // Attempt to register the user
            bool registrationSuccessful = userService.RegisterUser(firstName, lastName, email, password, phone, address, userType);

            if (registrationSuccessful) {
                // Redirect to login page if registration is successful
                Response.Redirect("Login.aspx");
            }
            else {
                // Optionally handle the case where registration fails
                // For example, you could display a generic message if needed
                // e.g., ErrorMessage.Text = "Registration failed. Please try again.";
            }
        }
    }
}