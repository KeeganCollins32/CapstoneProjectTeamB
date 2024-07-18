using MySqlConnector;
using System;
using System.Data;
using System.Web;

namespace Capstone1 {
    public partial class SignUp : System.Web.UI.Page {
        protected void SignUpButton_Click(object sender, EventArgs e) {
            string username = UserName.Text;
            string email = Email.Text;
            string password = Password.Text;

            if (IsValid) {
                ErrorMessageUsername.Text = "";
                ErrorMessageEmail.Text = "";
                ErrorMessage.Text = "";

                // Replace these values with your actual MySQL server details
                string connectionString = "server=localhost;port=5135;database=dent_repair;uid=root;password=CapstoneTeamB123;";

                try {
                    using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand("SignUpUser", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Adding input parameters
                        cmd.Parameters.AddWithValue("pUsername", username);
                        cmd.Parameters.AddWithValue("pEmail", email);
                        cmd.Parameters.AddWithValue("pPassword", password);

                        // Adding output parameters
                        MySqlParameter outputIdParam = new MySqlParameter("intUserID", MySqlDbType.Int32);
                        outputIdParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputIdParam);

                        MySqlParameter outputErrorMsgParam = new MySqlParameter("strErrorMsg", MySqlDbType.VarChar, 255);
                        outputErrorMsgParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputErrorMsgParam);

                        cmd.ExecuteNonQuery();

                        int intUserID = (int)outputIdParam.Value;
                        string errorMsg = outputErrorMsgParam.Value.ToString();

                        if (!string.IsNullOrEmpty(errorMsg)) {
                            // Display error messages under the respective text boxes
                            if (errorMsg == "Username already exists") {
                                ErrorMessageUsername.Text = errorMsg;
                            }
                            else if (errorMsg == "Email already exists") {
                                ErrorMessageEmail.Text = errorMsg;
                            }
                        }
                        else {
                            // Optionally, handle success (redirect to success page)
                            Response.Redirect("Login.aspx");
                        }
                    }
                }
                catch (Exception ex) {
                    // Handle exception (display error message)
                    ErrorMessage.Text = "An error occurred while signing up. Please try again later.";
                    // Optionally, log the exception for debugging purposes
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}