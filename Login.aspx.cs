using System;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Web.UI;

namespace Capstone1 {
    public partial class Login : Page {
        protected void Page_Load(object sender, EventArgs e) {
            // Display error message if present in ViewState
            if (ViewState["ErrorMessage"] != null) {
                ErrorMessage.Text = ViewState["ErrorMessage"].ToString();
                ViewState["ErrorMessage"] = null; // Clear the message after displaying
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e) {
            string email = Email.Text.Trim();
            string password = Password.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) {
                ErrorMessage.Text = "Email and password are required.";
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["MyDbContext"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString)) {
                ErrorMessage.Text = "Database connection string is not configured.";
                return;
            }

            try {
                using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                    conn.Open();

                    string query = "SELECT UserID, UserType FROM users WHERE email = @Email AND password = @Password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.Read()) {
                                // Retrieve userID and userType
                                string userID = reader["UserID"].ToString();
                                string userType = reader["UserType"].ToString();

                                // Create session
                                Session["UserID"] = userID; // Set the session variable
                                Session["UserType"] = userType; // Set the userType session variable

                                string sessionToken = Guid.NewGuid().ToString();
                                CreateSession(userID, sessionToken);

                                // Set session token in cookie
                                HttpCookie sessionCookie = new HttpCookie("SessionToken", sessionToken);
                                Response.Cookies.Add(sessionCookie);

                                // Debugging info
                                System.Diagnostics.Debug.WriteLine("Session UserID: " + Session["UserID"]);
                                System.Diagnostics.Debug.WriteLine("Session UserType: " + Session["UserType"]);
                                System.Diagnostics.Debug.WriteLine("Session Token Cookie: " + Request.Cookies["SessionToken"]?.Value);

                                // Redirect to a protected page
                                Response.Redirect("Default.aspx", false);
                                HttpContext.Current.ApplicationInstance.CompleteRequest();
                            }
                            else {
                                ErrorMessage.Text = "Invalid email or password.";
                                ViewState["ErrorMessage"] = "Invalid email or password.";
                            }
                        }
                    }
                }
            }
            catch (MySqlException mySqlEx) {
                ErrorMessage.Text = "A database error occurred. Please try again.";
            }
            catch (Exception ex) {
                ErrorMessage.Text = "An error occurred. Please try again.";
            }
        }

        private void CreateSession(string userID, string sessionToken) {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbContext"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString)) {
                return;
            }

            try {
                using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                    conn.Open();

                    string query = "INSERT INTO sessions (UserID, SessionToken, CreatedAt, ExpiresAt) VALUES (@UserID, @SessionToken, @CreatedAt, @ExpiresAt)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@SessionToken", sessionToken);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ExpiresAt", DateTime.Now.AddHours(1)); // Set session expiry

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException) {
                // Log and handle MySql exceptions if necessary
            }
            catch (Exception) {
                // Log and handle general exceptions if necessary
            }
        }
    }
}

