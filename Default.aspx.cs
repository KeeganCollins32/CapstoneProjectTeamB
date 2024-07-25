using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capstone1 {
	public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            // Your page load logic
        }

        protected void btnGetQuote_Click(object sender, EventArgs e) {
            if (Session["UserID"] != null)
            {
                Response.Redirect("Estimate.aspx");
            }
            else {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnLearnMore_Click(object sender, EventArgs e) {
            Response.Redirect("AboutUs.aspx");
        }

        protected void CustomerEstimateButton_Click(object sender, EventArgs e) {
            if (Session["UserID"] != null)
            {
                Response.Redirect("Estimate.aspx");
            }
            else {
                Response.Redirect("Login.aspx");
            }
        }

        protected void FAQButton_Click(object sender, EventArgs e) {
            Response.Redirect("FAQs.aspx");
        }
    }
}