using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Capstone1 {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            // Display error message if present in ViewState
            if (ViewState["ErrorMessage"] != null) {
                ErrorMessage.Text = ViewState["ErrorMessage"].ToString();
                ViewState["ErrorMessage"] = null; // Clear the message after displaying
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e) {
            // Retrieve the username and password from the Login control
            string emailOrUsername = Login1.UserName;
            string password = Login1.Password;

            // Validate input
            if (string.IsNullOrEmpty(emailOrUsername) || string.IsNullOrEmpty(password)) {
                ErrorMessage.Text = "Username or email and password are required.";
                return;
            }

            // Retrieve the connection string from web.config
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;

            try {
                using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("LoginUser", conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Set parameters
                        cmd.Parameters.AddWithValue("pEmailOrUsername", emailOrUsername);
                        cmd.Parameters.AddWithValue("pPassword", password);

                        // Define output parameters
                        MySqlParameter resultParam = new MySqlParameter("pResult", MySqlDbType.Int32) {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(resultParam);

                        MySqlParameter errorMsgParam = new MySqlParameter("pErrorMsg", MySqlDbType.VarChar, 255) {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(errorMsgParam);

                        // Execute the command
                        cmd.ExecuteNonQuery();

                        // Retrieve results
                        int result = Convert.ToInt32(resultParam.Value);
                        string errorMsg = errorMsgParam.Value.ToString();

                        // Check if login was successful
                        if (result == 1) {
                            // Start session
                            Session["Username"] = emailOrUsername;
                            Session["IsLoggedIn"] = true;

                            // Confirm session variables
                            if (Session["Username"] != null && (bool)Session["IsLoggedIn"]) {
                                // Redirect to Default.aspx
                                Response.Redirect("Default.aspx", false);
                                HttpContext.Current.ApplicationInstance.CompleteRequest();
                            }
                            else {
                                ErrorMessage.Text = "Session variables are not set properly.";
                            }
                        }
                        else {
                            // Display error message
                            ErrorMessage.Text = errorMsg;
                            ViewState["ErrorMessage"] = errorMsg;
                        }
                    }
                }
            }
            catch (Exception ex) {
                // Log the exception details
                Console.WriteLine($"Exception: {ex.Message}\nStack Trace: {ex.StackTrace}");
                // Optionally, set a user-friendly error message
                ErrorMessage.Text = "An error occurred. Please try again.";
            }
        }
    }
}