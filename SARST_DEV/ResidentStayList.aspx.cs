using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SARST_DEV.Model;
using System.IO;
using System.Text;

namespace SARST_DEV {
    public partial class ResidentStayList : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {
            var user = GetCurrentUser();
            if (user == null) {
                Response.Redirect("~/");
            }
        }

        protected void EditViewButton_Click(object sender, EventArgs e) {
            int id = int.Parse(((Button)sender).CommandArgument);

            using (var db = new SARSTDataContext()) {
                ResidentStay result = db.ResidentStays.SingleOrDefault(r => r.id == id);
                if (result == null) {
                    Session.Add("messageFromSender", "An error occured trying to access residentStays data, please try again.");
                    Response.Redirect("~/ResidentStayList");
                }

                Session.Add("editResidentStay", result);
                Response.Redirect("~/ResidentStayEdit");
            }
        }
    }
}