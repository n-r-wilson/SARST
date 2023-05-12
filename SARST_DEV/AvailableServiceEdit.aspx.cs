using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SARST_DEV.Model;

namespace SARST_DEV {
    public partial class AvailableServiceEdit : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {
            var user = GetCurrentUser();
            if (user == null || !(user.type == UserType.ROOT || user.type == UserType.ADMIN)) {
                Response.Redirect("~/");
            }

            AvailableService editService = (AvailableService)Session["editService"];
            
            if (editService == null) {
                Session.Add("messageFromSender", "An error has occured trying to access our services, please try again.");
                Response.Redirect("~/AvailableServiceList");
            }

            if (!IsPostBack) {
                TextBoxTitle.Text = editService.title;
                TextBoxDescription.Text = editService.description;
                DiscontinueBox.Text = editService.date_discontinued.ToString();
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e) {
            AvailableService editService = (AvailableService)Session["editService"];
            if (editService == null) {
                Session.Add("messageFromSender", "An error has occured trying to access our services, please try again.");
                Response.Redirect("~/AvailableServiceList");
            }

            using (var db = new SARSTDataContext()) {
                var result = db.AvailableServices.SingleOrDefault(s => s.id == editService.id);
                if (result != null) {
                    result.title             = TextBoxTitle.Text;
                    result.description       = TextBoxDescription.Text;
                    result.date_discontinued = DateTime.Parse(DiscontinueBox.Text);
                    db.SaveChanges();

                    Session.Add("messageFromSender", "AvailableService edited successfully.");
                    Response.Redirect("~/AvailableServiceList");
                }
            }

            Session.Add("messageFromSender", "An error has occured trying to access our services, please try again.");
            Response.Redirect("~/AvailableServiceList");
        }
    }
}
