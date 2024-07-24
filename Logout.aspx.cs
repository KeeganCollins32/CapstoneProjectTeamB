using System;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Web.UI;

namespace Capstone1 {
    public partial class Logout : Page {
        protected void Page_Load(object sender, EventArgs e) {
            // Invalidate session
            HttpCookie sessionCookie = Request.Cookies["SessionToken"];
            if (sessionCookie != null) {
                string sessionToken = sessionCookie.Value;
                InvalidateSessionToken(sessionToken);

                // Remove the session cookie
                sessionCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Set(sessionCookie);
            }

            // Clear the session
            Session.Clear();
            Session.Abandon();

            // Redirect to login page
            Response.Redirect("Login.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private void InvalidateSessionToken(string sessionToken) {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbContext"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString)) {
                return;
            }

            try {
                using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                    conn.Open();

                    string query = "DELETE FROM sessions WHERE SessionToken = @SessionToken";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@SessionToken", sessionToken);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex) {
                // Log exception details
                // Example: LogError("MySQL Exception: " + ex.Message);
            }
            catch (Exception ex) {
                // Log exception details
                // Example: LogError("General Exception: " + ex.Message);
            }
        }
    }
}
