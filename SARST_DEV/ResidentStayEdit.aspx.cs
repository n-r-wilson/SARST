using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SARST_DEV.Model;

namespace SARST_DEV {
    public partial class ResidentStayEdit : SARSTPage {

        public List<ProvidedService> GetResidentStayProvidedServices(object sender, EventArgs e) {
            return ((ResidentStay)Session["editResidentStay"]).getProvidedServices();
        }

        public List<DisciplinaryAction> GetResidentStayDisciplinaryActions(object sender, EventArgs e) {
            return ((ResidentStay)Session["editResidentStay"]).getDisciplinaryActions();
        }

        protected void Page_Load(object sender, EventArgs e) {
            var user = GetCurrentUser();
            if (user == null) {
                Response.Redirect("~/");
            }

            ResidentStay editResidentStay = (ResidentStay)Session["editResidentStay"];

            if (editResidentStay == null
             || editResidentStay.provider == null
             || editResidentStay.resident == null) {
                Session.Add("messageFromSender", "An error occured trying to access residentStay data, please try again.");
                Response.Redirect("~/ResidentStayList");
            }

            if (!IsPostBack) {
                TextBoxEvents.Text = editResidentStay.events;
            }

            // Init list of avialable services which can be added to the ResidentStay
            IEnumerable<AvailableService> services = GetAvailableServices();
            if (services != null) {
                foreach (var service in services) {
                    ServiceEntry.Items.Add(new ListItem {
                        Value = service.id.ToString(),
                        Text = service.title
                    });
                }
            }

            for (DisciplinaryAction.DisciplinaryActionType actionType = DisciplinaryAction.DisciplinaryActionType.Warning; actionType <= DisciplinaryAction.DisciplinaryActionType.Step_Away; actionType++) {
                DisciplineEntry.Items.Add(new ListItem {
                    Value = actionType.ToString(),
                    Text = actionType.ToString()
                });
            }
        }

        protected void AddServiceButton_Click(object sender, EventArgs e) {
            ResidentStay editResidentStay = (ResidentStay)Session["editResidentStay"];

            if (editResidentStay == null
             || editResidentStay.provider == null
             || editResidentStay.resident == null
             || !editResidentStay.isActive()) {
                Session.Add("messageFromSender", "An error occured trying to access residentStay data, please try again.");
                Response.Redirect("~/ResidentStayList");
            }

            ProvidedService service = new ProvidedService {
                service_id = int.Parse(ServiceEntry.SelectedValue),
                stay_id = ((ResidentStay)Session["editResidentStay"]).id,
                dateTime = DateTime.Now
            };

            var _db = new SARSTDataContext();
            _db.ProvidedServices.Add(service);
            _db.SaveChanges();

            Session.Add("messageFromSender", "ProvidedService added to database.");
            Response.Redirect("~/ResidentStayEdit");
        }

        protected void AddDisciplinaryActionButton_Click(object sender, EventArgs e) {
            ResidentStay editResidentStay = (ResidentStay)Session["editResidentStay"];

            if (editResidentStay == null
             || editResidentStay.provider == null
             || editResidentStay.resident == null
             || !editResidentStay.isActive()) {
                Session.Add("messageFromSender", "An error occured trying to access residentStay data, please try again.");
                Response.Redirect("~/ResidentStayList");
            }

            DisciplinaryAction action = new DisciplinaryAction {
                type = (DisciplinaryAction.DisciplinaryActionType)Enum.Parse(typeof(DisciplinaryAction.DisciplinaryActionType), DisciplineEntry.SelectedValue),
                stay_id = ((ResidentStay)Session["editResidentStay"]).id,
                dateTime = DateTime.Now,
                notes = TextBoxDisciplineNotes.Text
            };

            var _db = new SARSTDataContext();
            _db.DisciplinaryActions.Add(action);
            _db.SaveChanges();

            Session.Add("messageFromSender", "DisciplinaryAction added to database.");
            Response.Redirect("~/ResidentStayEdit");
        }

        protected void CheckOutButton_Click(object sender, EventArgs e) {
            ResidentStay editResidentStay = (ResidentStay)Session["editResidentStay"];

            if (editResidentStay == null
             || editResidentStay.provider == null
             || editResidentStay.resident == null
             || !editResidentStay.isActive()) {
                Session.Add("messageFromSender", "An error occured trying to access residentStay data, please try again.");
                Response.Redirect("~/ResidentStayList");
            }
            
            using (var db = new SARSTDataContext()) {
                var result = db.ResidentStays.SingleOrDefault(b => b.id == editResidentStay.id);
                if (result != null) {
                    result.dateTime_out = DateTime.Now;
                    result.events = TextBoxEvents.Text;
                    db.SaveChanges();

                    Session.Add("messageFromSender", "Resident checked out successfully.");
                    Response.Redirect("~/ResidentStayList");
                }
            }

            Session.Add("messageFromSender", "An error occured trying to access residentStay data, please try again.");
            Response.Redirect("~/ResidentStayList");
        }

        protected void SaveButton_Click(object sender, EventArgs e) {
            ResidentStay editResidentStay = (ResidentStay)Session["editResidentStay"];

            if (editResidentStay == null
             || editResidentStay.provider == null
             || editResidentStay.resident == null
             || !editResidentStay.isActive()) {
                Session.Add("messageFromSender", "An error occured trying to access residentStay data, please try again.");
                Response.Redirect("~/ResidentStayList");
            }

            using (var db = new SARSTDataContext()) {
                var result = db.ResidentStays.SingleOrDefault(b => b.id == editResidentStay.id);
                if (result != null) {
                    result.events = TextBoxEvents.Text;
                    db.SaveChanges();
                }
            }
        }
    }
}