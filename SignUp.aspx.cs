using System;
using System.Web.Security;

namespace Capstone1 {
    public partial class SignUp : System.Web.UI.Page {
        protected void SignUpButton_Click(object sender, EventArgs e) {
            // Get user input
            string username = UserName.Text;
            string email = Email.Text;
            string password = Password.Text;

            // Perform validation (if necessary)
            if (IsValid) {
                // Attempt to create the user
                MembershipCreateStatus status;
                Membership.CreateUser(username, password, email, null, null, true, out status);

                // Check if user creation was successful
                if (status == MembershipCreateStatus.Success) {
                    // Optionally, sign the user in automatically
                    FormsAuthentication.SetAuthCookie(username, false);

                    // Redirect to signup success page or another page
                    Response.Redirect("SignUpSuccess.aspx");
                }
                else {
                    // Handle the error if user creation fails
                    ErrorMessage.Text = GetErrorMessage(status);
                }
            }
        }

        private string GetErrorMessage(MembershipCreateStatus status) {
            // Return appropriate error message based on MembershipCreateStatus
            // Implement as per your specific needs
            // Example implementation shown earlier in previous conversations
            return "An error occurred. Please try again.";
        }
    }
}