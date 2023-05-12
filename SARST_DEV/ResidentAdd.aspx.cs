using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SARST_DEV.Model;


namespace SARST_DEV {
    public partial class ResidentEntry : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {
            var user = GetCurrentUser();
            if (user == null) {
                Response.Redirect("~/");
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e) {

            Resident resident = new Resident {
                first_name      = TextBoxFirstName.Text,
                last_name       = TextBoxLastName.Text,
                date_of_birth   = DateTime.Parse(TextBoxDOB.Text),
                sex             = (Sex)Enum.Parse(typeof(Sex), SexEntry.SelectedValue),
                gender          = (Gender)Enum.Parse(typeof(Gender), GenderEntry.SelectedValue),
                pronouns        = (Pronouns)Enum.Parse(typeof(Pronouns), PronounsEntry.SelectedValue),
                distinguishing_features = TextBoxFeatures.Text
            };

            var _db = new SARSTDataContext();
            _db.Residents.Add(resident);
            _db.SaveChanges();

            Session.Add("messageFromSender", "Resident added to database.");
            Response.Redirect("~/ResidentList");

        }

    }
}