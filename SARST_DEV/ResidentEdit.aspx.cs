using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SARST_DEV.Model;

namespace SARST_DEV {
    public partial class ResidentEdit : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {
            var user = GetCurrentUser();
            if (user == null) {
                Response.Redirect("~/");
            }

            Resident editResident = (Resident)Session["editResident"];
            
            if (editResident == null) {
                Session.Add("messageFromSender", "An error occured trying to access resident data, please try again.");
                Response.Redirect("~/ResidentList");
            }

            if (!IsPostBack) {
                TextBoxFirstName.Text       = editResident.first_name;
                TextBoxLastName.Text        = editResident.last_name;
                TextBoxDOB.Text             = editResident.date_of_birth.ToShortDateString();
                SexEntry.SelectedValue      = editResident.sex.ToString();
                GenderEntry.SelectedValue   = editResident.gender.ToString();
                PronounsEntry.SelectedValue = editResident.pronouns.ToString();
                TextBoxFeatures.Text        = editResident.distinguishing_features;
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e) {
            Resident editResident = (Resident)Session["editResident"];

            if (editResident == null) {
                Session.Add("messageFromSender", "An error occured trying to access resident data, please try again.");
                Response.Redirect("~/ResidentList");
            }

            using (var db = new SARSTDataContext()) {
                var result = db.Residents.SingleOrDefault(b => b.id == editResident.id);
                if (result != null) {
                    result.first_name               = TextBoxFirstName.Text;
                    result.last_name                = TextBoxLastName.Text;
                    result.date_of_birth            = DateTime.Parse(TextBoxDOB.Text);
                    result.sex                      = (Sex)Enum.Parse(typeof(Sex), SexEntry.SelectedValue);
                    result.gender                   = (Gender)Enum.Parse(typeof(Gender), GenderEntry.SelectedValue);
                    result.pronouns                 = (Pronouns)Enum.Parse(typeof(Pronouns), PronounsEntry.SelectedValue);
                    result.distinguishing_features  = TextBoxFeatures.Text;
                    db.SaveChanges();
                    Session.Add("messageFromSender", "Resident info updated successfully.");
                    Response.Redirect("~/ResidentList");
                }
            }

            Session.Add("messageFromSender", "An error occured trying to access resident data, please try again.");
            Response.Redirect("~/ResidentList");
        }

    }
}