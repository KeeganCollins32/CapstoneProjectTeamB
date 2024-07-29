using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capstone1 {
    public partial class Site : MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["UserID"] != null) {
                System.Diagnostics.Debug.WriteLine("UserID is set.");
                UpdateNavigation();
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
                string userType = Session["UserType"] as string;
                switch (userType) {
                    case "Technician":
                        DisplayTechnicianNavigation();
                        break;
                    case "Dealership":
                        DisplayDealershipNavigation();
                        break;
                    default:
                        DisplayUserNavigation();
                        break;
                }
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
                UserNav.Controls.Add(new LiteralControl(GetNavLink("Invoices.aspx", "Invoices")));
                UserNav.Controls.Add(new LiteralControl(GetNavLink("Logout.aspx", "Log Out")));
            }

            if (TechnicianNav != null) {
                TechnicianNav.Visible = false;
            }

            if (DealershipNav != null) {
                DealershipNav.Visible = false;
            }
        }

        private void DisplayTechnicianNavigation() {
            if (TechnicianNav != null) {
                TechnicianNav.Controls.Clear();
                TechnicianNav.Controls.Add(new LiteralControl(GetNavLink("EditAccount.aspx", "Edit Account")));
                TechnicianNav.Controls.Add(new LiteralControl(GetNavLink("RequestedEstimates.aspx", "Estimates")));
                TechnicianNav.Controls.Add(new LiteralControl(GetNavLink("ToolManagement.aspx", "Tool Management")));
                TechnicianNav.Controls.Add(new LiteralControl(GetNavLink("Invoices.aspx", "Invoices")));
                TechnicianNav.Controls.Add(new LiteralControl(GetNavLink("DealershipCreation.aspx", "Create Dealership")));
                TechnicianNav.Controls.Add(new LiteralControl(GetNavLink("Logout.aspx", "Log Out")));
            }

            if (UserNav != null) {
                UserNav.Visible = false;
            }

            if (DealershipNav != null) {
                DealershipNav.Visible = false;
            }
        }

        private void DisplayDealershipNavigation() {
            if (DealershipNav != null) {
                DealershipNav.Controls.Clear();
                DealershipNav.Controls.Add(new LiteralControl(GetNavLink("EditAccount.aspx", "Edit Account")));
                DealershipNav.Controls.Add(new LiteralControl(GetNavLink("DealershipEstimate.aspx", "Request Estimate")));
                UserNav.Controls.Add(new LiteralControl(GetNavLink("Invoices.aspx", "Invoices")));
                DealershipNav.Controls.Add(new LiteralControl(GetNavLink("Logout.aspx", "Log Out")));
            }

            if (UserNav != null) {
                UserNav.Visible = false;
            }

            if (TechnicianNav != null) {
                TechnicianNav.Visible = false;
            }
        }

        private void DisplayDefaultNavigation() {
            if (UserNav != null) {
                UserNav.Controls.Clear();
                UserNav.Controls.Add(new LiteralControl(GetNavLink("Login.aspx", "Log In")));
                UserNav.Controls.Add(new LiteralControl(GetNavLink("Signup.aspx", "Sign Up")));
            }

            if (TechnicianNav != null) {
                TechnicianNav.Visible = false;
            }

            if (DealershipNav != null) {
                DealershipNav.Visible = false;
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
