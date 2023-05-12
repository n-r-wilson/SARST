using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using SARST_DEV.Model;

namespace SARST_DEV {
    public partial class SiteMaster : MasterPage {

        protected void Page_Load(object sender, EventArgs e) {
            
        }

        public SARSTUser GetCurrentUser() {
            return (SARSTUser)Session["user"];
        }

        public void LogOut_Click(object sender, EventArgs e) {
            Session.Remove("user");
            Response.Redirect("/");
        }

    }
}