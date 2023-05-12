using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using SARST_DEV.Model;
using System.Text;

namespace SARST_DEV
{
    public partial class DataOutput : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {
            var user = GetCurrentUser(); 
            if (user == null) {
                Response.Redirect("~/");
            }
        }

        protected void GenerateReportButton_Click(object sender, EventArgs e) {
            DateTime startDate = DateTime.MinValue,
                     endDate   = DateTime.MaxValue;

            DateTime.TryParse(StartDateTextBox.Text, out startDate);
            DateTime.TryParse(EndDateTextBox.Text, out endDate);

            List<ResidentStay> stays = GetResidentStays().ToList();
            stays.RemoveAll(s => s.dateTime_in < startDate || s.dateTime_in > endDate);

            CSV csv = new CSV();
            csv.data.Add(new List<string> {
                "ID", "Resident ID", "Resident Name", "Provider ID", "Provider Username", "Date/Time In", "Date/Time Out"
            });
            foreach (var stay in stays) {
                List<string> residentStay_data = new List<string>();

                residentStay_data.Add(stay.id.ToString());
                residentStay_data.Add(stay.resident_id.ToString());
                residentStay_data.Add(stay.resident.full_name);
                residentStay_data.Add(stay.provider_id.ToString());
                residentStay_data.Add(stay.provider.username.ToString());
                residentStay_data.Add(stay.dateTime_in.ToString());
                residentStay_data.Add(stay.dateTime_out.ToString());

                csv.data.Add(residentStay_data);
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

        protected void ResidentDataButton_Click(object sender, EventArgs e) {
            var db = new SARSTDataContext();
            
            //List<Resident> residents = GetResidents().ToList();

            CSV csv = new CSV();
            csv.data.Add(new List<string> {
                "ID", "First Name", "Last Name", "Date of Birth", "Sex", "Gender", "Pronouns", "Distinguishing Features"
            });
            //foreach (Resident resident in residents)
            foreach (var resident in db.Residents)
            {
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

        protected void ResidentStayDataButton_Click(object sender, EventArgs e) {
            var db = new SARSTDataContext();

            CSV csv = new CSV();
            csv.data.Add( new List<string> {
                "ID", "Resident ID", "Date/Time In", "Date/Time Out", "Provider ID"
            });

            foreach(var residentStay in db.ResidentStays) {
                List<string> residentStay_data = new List<string>();

                residentStay_data.Add(residentStay.id.ToString());
                residentStay_data.Add(residentStay.resident_id.ToString());
                residentStay_data.Add(residentStay.dateTime_in.ToString());
                residentStay_data.Add(residentStay.dateTime_out.ToString());
                residentStay_data.Add(residentStay.provider_id.ToString());

                csv.data.Add(residentStay_data);
            }

            Response.ContentType = "text/plain";
            Response.AddHeader("content-disposition", "attachment;filename=" + string.Format("sarst-resident-stay-data-{0}.csv", string.Format("{0:ddMMyyyy}", DateTime.Today)));
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

        protected void ResidentAvailableServicesButton_Click(object sender, EventArgs e)
        {
            var db = new SARSTDataContext();

            CSV csv = new CSV();
            csv.data.Add(new List<string> {
                "ID", "Type of Service", "Title of Service", "Description of Service", "Effective Start Date", "Discontinued Date"
            });

            foreach (var residentStay in db.AvailableServices) {
                List<string> availableServices_data = new List<string>();

                availableServices_data.Add(residentStay.id.ToString());
                availableServices_data.Add(residentStay.type.ToString());
                availableServices_data.Add(residentStay.title.ToString());
                availableServices_data.Add(residentStay.description.ToString());
                availableServices_data.Add(residentStay.date_effective.ToString());
                availableServices_data.Add(residentStay.date_discontinued.ToString());

                csv.data.Add(availableServices_data);
            }

            Response.ContentType = "text/plain";
            Response.AddHeader("content-disposition", "attachment;filename=" + string.Format("sarst-available-services-data-{0}.csv", string.Format("{0:ddMMyyyy}", DateTime.Today)));
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

        protected void ResidentProvidedServicesButton_Click(object sender, EventArgs e) {
            var db = new SARSTDataContext();

            CSV csv = new CSV();
            csv.data.Add(new List<string> {
                "ID", "Type of Service", "Stay ID", "Time of Service"
            });

            foreach (var residentStay in db.ProvidedServices) {
                List<string> providedServices_data = new List<string>();

                providedServices_data.Add(residentStay.id.ToString());
                providedServices_data.Add(residentStay.service_id.ToString());
                providedServices_data.Add(residentStay.stay_id.ToString());
                providedServices_data.Add(residentStay.dateTime.ToString());

                csv.data.Add(providedServices_data);
            }

            Response.ContentType = "text/plain";
            Response.AddHeader("content-disposition", "attachment;filename=" + string.Format("sarst-provided-services-data-{0}.csv", string.Format("{0:ddMMyyyy}", DateTime.Today)));
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

        protected void ResidentDisciplinaryActionsButton_Click(object sender, EventArgs e) {
            var db = new SARSTDataContext();

            CSV csv = new CSV();
            csv.data.Add(new List<string> {
                "ID", "Disciplinary Type", "Stay ID", "Time of Action"
            });

            foreach (var residentStay in db.DisciplinaryActions) {
                List<string> disciplinaryAction_data = new List<string>();

                disciplinaryAction_data.Add(residentStay.id.ToString());
                disciplinaryAction_data.Add(residentStay.type.ToString());
                disciplinaryAction_data.Add(residentStay.stay_id.ToString());
                disciplinaryAction_data.Add(residentStay.dateTime.ToString());

                csv.data.Add(disciplinaryAction_data);
            }

            Response.ContentType = "text/plain";
            Response.AddHeader("content-disposition", "attachment;filename=" + string.Format("sarst-resident-disciplinary-actions-data-{0}.csv", string.Format("{0:ddMMyyyy}", DateTime.Today)));
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