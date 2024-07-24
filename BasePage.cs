using System;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Capstone1 {
    public class BasePage : Page {
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            // Check if the user is authenticated
            if (!IsUserAuthenticated()) {
                // Redirect to the login page if not authenticated
                Response.Redirect("Login.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }

        private bool IsUserAuthenticated() {
            // Check if the session token exists in cookies
            HttpCookie sessionCookie = Request.Cookies["SessionToken"];
            if (sessionCookie != null) {
                string sessionToken = sessionCookie.Value;

                // Verify the session token with the database
                return VerifySessionToken(sessionToken);
            }
            return false;
        }

        private bool VerifySessionToken(string sessionToken) {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbContext"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString)) {
                return false;
            }

            try {
                using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                    conn.Open();

                    string query = "SELECT UserID FROM sessions WHERE SessionToken = @SessionToken AND ExpiresAt > @CurrentTime";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@SessionToken", sessionToken);
                        cmd.Parameters.AddWithValue("@CurrentTime", DateTime.Now);

                        using (MySqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.Read()) {
                                // Set user ID in session for use on the page
                                HttpContext.Current.Session["UserID"] = reader["UserID"];
                                return true;
                            }
                        }
                    }
                }
            }
            catch (MySqlException) {
                // Log and handle MySql exceptions if necessary
                return false;
            }
            catch (Exception) {
                // Log and handle general exceptions if necessary
                return false;
            }
            return false;
        }
    }
}

