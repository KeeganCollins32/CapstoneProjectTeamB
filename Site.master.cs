using System;
using System.Web;
using System.Web.UI;

namespace Capstone1 {
    public partial class Site : System.Web.UI.MasterPage {

        protected void Page_Load(object sender, EventArgs e) {
            // Page load logic (if any)
        }

        // Method to check if a page is active
        protected string CheckActive(string page) {
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            return currentPage.Equals(page, StringComparison.OrdinalIgnoreCase) ? "active" : "";
        }

        protected void LogoutButton_Click(object sender, EventArgs e) {
            // Handle logout functionality
        }
    }
}