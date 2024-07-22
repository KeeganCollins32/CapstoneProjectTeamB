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
            string phone = Phone.Text;
            string role = Role.SelectedValue;

            if (IsValid) {
                ErrorMessageEmail.Text = "";
                ErrorMessage.Text = "";

                var userService = new UserService();

                if (userService.RegisterUser(email, password, firstName, lastName, phone, role)) {
                    // Registration successful
                    Response.Redirect("Login.aspx");
                }
                else {
                    // Registration failed - email already exists
                    ErrorMessageEmail.Text = "Email already exists";
                }
            }
        }
    }
}