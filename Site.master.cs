using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capstone1 {
    public partial class Site : MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["UserID"] != null) {
                System.Diagnostics.Debug.WriteLine("UserID is set.");
                DisplayUserNavigation();
            }
            else {
                System.Diagnostics.Debug.WriteLine("UserID is not set.");
                DisplayDefaultNavigation();
            }

            if (!IsPostBack) {
                UpdateNavigation();
            }
        }

        private void UpdateNavigation() {
            if (Session["UserID"] != null) {
                DisplayUserNavigation();
            }
            else {
                DisplayDefaultNavigation();
            }
        }

        private void DisplayUserNavigation() {
            if (UserNav != null) {
                UserNav.Controls.Clear();
                UserNav.Controls.Add(new LiteralControl(GetNavLink("EditAccount.aspx", "Edit Account")));
                UserNav.Controls.Add(new LiteralControl(GetNavLink("Estimate.aspx", "Request Estimate")));
                UserNav.Controls.Add(new LiteralControl(GetNavLink("Invoices.aspx", "User Invoices")));
                UserNav.Controls.Add(new LiteralControl(GetNavLink("Logout.aspx", "Log Out")));
            }
        }

        private void DisplayDefaultNavigation() {
            if (UserNav != null) {
                UserNav.Controls.Clear();
                UserNav.Controls.Add(new LiteralControl(GetNavLink("Login.aspx", "Log In")));
                UserNav.Controls.Add(new LiteralControl(GetNavLink("Signup.aspx", "Sign Up")));
            }
        }

        private string GetNavLink(string pageUrl, string linkText) {
            string activeClass = IsActivePage(pageUrl) ? "active" : "";
            return $"<a href='{pageUrl}' class='{activeClass}'>{linkText}</a>";
        }

        protected bool IsActivePage(string page) {
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            return currentPage.Equals(page, StringComparison.OrdinalIgnoreCase);
        }

        protected void LogoutButton_Click(object sender, EventArgs e) {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}