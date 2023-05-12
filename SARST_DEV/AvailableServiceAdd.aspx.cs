using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SARST_DEV.Model;

namespace SARST_DEV {
    public partial class AvailableServiceAdd : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {
            var user = GetCurrentUser();
            if (user == null || !(user.type == UserType.ROOT || user.type == UserType.ADMIN)) {
                Response.Redirect("~/");
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e) {

            AvailableService service = new AvailableService {
                type = AvailableService.ServiceType.SetupService, // all created services are SetupServices
                title = TextBoxTitle.Text,
                description = TextBoxDescription.Text,
                date_effective = DateTime.Now,
                date_discontinued = DateTime.Parse("12/31/2100")
            };

            var _db = new SARSTDataContext();
            _db.AvailableServices.Add(service);
            _db.SaveChanges();

            Session.Add("messageFromSender", "AvailableService added to database.");
            Response.Redirect("~/AvailableServiceList");
        }
    }
}