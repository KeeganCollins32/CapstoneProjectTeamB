using System;
using System.Web.UI;

namespace Capstone1 {
    public class Global : System.Web.HttpApplication {
        void Application_Start(object sender, EventArgs e) {
            // Register ScriptResourceMapping for jQuery
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition {
                Path = "~/Scripts/jquery-3.6.0.min.js",
                DebugPath = "~/Scripts/jquery-3.6.0.js",
                CdnPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js",
                CdnDebugPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.js"
            });
        }
    }
}