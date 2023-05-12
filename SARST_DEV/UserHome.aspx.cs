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
    public partial class UserHome : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {
            var user = GetCurrentUser();
            if (user == null) {
                Response.Redirect("~/");
            }
        }

        protected void ResidentDataButton_Click(object sender, EventArgs e) {
            List<Resident> residents = GetResidents().ToList();

            CSV csv = new CSV();
            csv.data.Add(new List<string> { 
                "ID", "First Name", "Last Name", "Date of Birth", "Sex", "Gender", "Pronouns", "Distinguishing Features"
            });
            foreach (Resident resident in residents) {
                List<string> resident_data = new List<string>();

                resident_data.Add(resident.id.ToString());
                resident_data.Add(resident.first_name);
                resident_data.Add(resident.last_name);
                resident_data.Add(resident.date_of_birth.ToString());
                resident_data.Add(resident.sex.ToString());
                resident_data.Add(resident.gender.ToString());
                resident_data.Add(resident.pronouns.ToString());
                resident_data.Add(resident.distinguishing_features.ToString());

                csv.data.Add(resident_data);
            }

            Response.ContentType = "text/plain";
            Response.AddHeader("content-disposition", "attachment;filename=" + string.Format("sarst-resident-data-{0}.csv", string.Format("{0:ddMMyyyy}", DateTime.Today)));
            Response.Clear();

            using (StreamWriter writer = new StreamWriter(Response.OutputStream, Encoding.UTF8)) {
                foreach (var line in csv.data) {
                    foreach (var cell in line) {
                        writer.Write(cell);
                        writer.Write(csv.delimiter);
                    }
                    writer.Write("\n");
                }
            }

            Response.End();
        }

    }
}