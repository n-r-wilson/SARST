using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SARST_DEV.Model;

namespace SARST_DEV {
    public partial class AvailableServiceList : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {
            var user = GetCurrentUser();
            if (user == null) {
                Response.Redirect("~/");
            }
        }

        public void EditButton_Click(object sender, EventArgs e) {
            int id = int.Parse(((Button)sender).CommandArgument);

            using (var db = new SARSTDataContext()) {
                AvailableService result = db.AvailableServices.SingleOrDefault(r => r.id == id);
                if (result == null) {
                    Session.Add("messageFromSender", "An error occured trying to access availableService data, please try again.");
                    Response.Redirect("~/AvailableServiceList");
                }

                Session.Add("editService", result);
                Response.Redirect("~/AvailableServiceEdit");
            }
        }
    }
}