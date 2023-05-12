using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SARST_DEV.Model;

namespace SARST_DEV {
    public partial class ResidentList : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {
            var user = GetCurrentUser();
            if (user == null) {
                Response.Redirect("~/");
            }
        }

        public List<Resident> GetResidentsSearch() {
            Resident search = (Resident)Session["residentSearch"];

            List<Resident> residents = GetResidents().ToList();
            if (search == null) return residents;

            // Rather complex resident search algorithm incoming
            // iterate over all residents, search for match in each field
            // each match equates to increase in confidence level
            // results will be ordered by confidence

            List<Tuple<int, Resident>> searchResult = new List<Tuple<int, Resident>>();

            foreach (var resident in GetResidents()) {
                int confidence = 0;

                if (search.first_name != "" 
                 && resident.first_name.ToLower().Contains(search.first_name.ToLower()))
                    confidence += search.first_name.Length;

                if (search.last_name != "" 
                 && resident.last_name.ToLower().Contains(search.last_name.ToLower()))
                    confidence += search.last_name.Length;

                if (resident.date_of_birth.Date == search.date_of_birth.Date)
                    confidence += 3;

                if (search.distinguishing_features != "" 
                 && resident.distinguishing_features.ToLower().Contains(search.distinguishing_features.ToLower()))
                    confidence += 2;

                if (confidence > 0)
                    searchResult.Add(new Tuple<int, Resident>(confidence, resident));
            }

            // get only residents from list of tuple, now ordered by confidence
            searchResult = searchResult.OrderByDescending(x => x.Item1).ToList();
            var ret = new List<Resident>();
            foreach (var item in searchResult)
                ret.Add(item.Item2);

            Session.Remove("residentSearch");
            return ret;
        }


        protected void EditButton_Click(object sender, EventArgs e) {
            int id = int.Parse(((Button)sender).CommandArgument);

            using (var db = new SARSTDataContext()) {
                Resident result = db.Residents.SingleOrDefault(r => r.id == id);
                if (result == null) {
                    Session.Add("messageFromSender", "An error occured trying to access resident data, please try again.");
                    Response.Redirect("~/ResidentList");
                }

                Session.Add("editResident", result);
                Response.Redirect("~/ResidentEdit");
            }
        }

        protected void CheckInButton_Click(object sender, EventArgs e) {
            int id = int.Parse(((Button)sender).CommandArgument);

            ResidentStay stay = new ResidentStay {
                provider_id = GetCurrentUser().id,
                resident_id = id,
                dateTime_in = DateTime.Now
            };

            using (var db = new SARSTDataContext()) {
                Resident result = db.Residents.SingleOrDefault(r => r.id == id);
                if (result == null) {
                    Session.Add("messageFromSender", "An error occured trying to access resident data, please try again.");
                    Response.Redirect("~/ResidentList");
                }

                // TODO: add a check to make sure that we are not trying to check in a resident for whom there is already an active residentStay

                stay = db.ResidentStays.Add(stay);
                db.SaveChanges();
            }

            Session.Add("editResidentStayID", stay.id);
            Response.Redirect("~/ResidentStayList");
        }

    }

}