using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SARST_DEV.Model;

namespace SARST_DEV {
    public partial class Login : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void LoginButton_Click(object sender, EventArgs e) {
            LoginRequest loginRequest = new LoginRequest {
                username = TextBoxUN.Text,
                password = TextBoxPW.Text,
            };

            var result = loginRequest.Validate();
            Session.Add("messageFromSender", result.message);
            if (result.user != null) {
                Session.Add("user", result.user);
                Response.Redirect("~/UserHome");
            }
        }
    }
}