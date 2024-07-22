using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Security.Cryptography;
using System.Text;

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
            // Retrieve the email and password from the TextBox controls
            string email = Email.Text.Trim();
            string password = Password.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) {
                ErrorMessage.Text = "Email and password are required.";
                return;
            }

            // Hash the password
            string hashedPassword = HashPassword(password);

            // Retrieve the connection string from web.config
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbContext"]?.ConnectionString;

            // Check if connection string is null
            if (string.IsNullOrEmpty(connectionString)) {
                ErrorMessage.Text = "Database connection string is not configured.";
                return;
            }

            try {
                using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                    conn.Open();

                    string query = "SELECT * FROM users WHERE email = @email AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        // Log the query for debugging
                        Console.WriteLine($"Executing SQL Query: {query}");
                        Console.WriteLine($"Parameters: Email = {email}, Password = {hashedPassword}");

                        using (MySqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.Read()) {
                                // Login successful
                                Session["Username"] = email;
                                Session["IsLoggedIn"] = true;

                                // Redirect to Default.aspx
                                Response.Redirect("Default.aspx", false);
                                HttpContext.Current.ApplicationInstance.CompleteRequest();
                            }
                            else {
                                // Invalid login
                                ErrorMessage.Text = "Invalid email or password.";
                                ViewState["ErrorMessage"] = "Invalid email or password.";
                            }
                        }
                    }
                }
            }
            catch (MySqlException mySqlEx) {
                // Log MySql-specific exceptions
                Console.WriteLine($"MySqlException: {mySqlEx.Message}\nStack Trace: {mySqlEx.StackTrace}");
                ErrorMessage.Text = "A database error occurred. Please try again.";
            }
            catch (Exception ex) {
                // Log general exceptions
                Console.WriteLine($"Exception: {ex.Message}\nStack Trace: {ex.StackTrace}");
                ErrorMessage.Text = "An error occurred. Please try again.";
            }
        }
        
        // Method to hash the password using SHA256
        private string HashPassword(string password) {
            using (SHA256 sha256 = SHA256.Create()) {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}




