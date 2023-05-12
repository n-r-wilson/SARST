using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SARST_DEV.Model;

namespace SARST_DEV {
    public partial class ResidentSearch : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {
            var user = GetCurrentUser();
            if (user == null) {
                Response.Redirect("~/");
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e) {
            Resident search = new Resident {
                first_name      = TextBoxFirstName.Text,
                last_name       = TextBoxLastName.Text,
                date_of_birth   = DateTime.MinValue,
                distinguishing_features = TextBoxFeatures.Text
            };
            DateTime dob;
            if (DateTime.TryParse(TextBoxDOB.Text, out dob))
                search.date_of_birth = dob;

            Session.Add("residentSearch", search);
            Response.Redirect("~/ResidentList.aspx");
        }


    }
}