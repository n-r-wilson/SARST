using SARST_DEV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Css.Ast.Selectors;

namespace SARST_DEV {
    public partial class WebForm1 : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {
            var user = GetCurrentUser();
            if (user == null) {
                Response.Redirect("~/");
            }
            residentDIV.Visible             = false;
            residentStayDIV.Visible         = false;
            availableServiceDIV.Visible     = false;
            providedServiceDIV.Visible      = false;
            disciplinaryActionDIV.Visible   = false;
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

        protected void ShowResidentList(object sender, EventArgs e) {
            residentDIV.Visible = true;
        }

        protected void ShowResidentStayList(object sender, EventArgs e) {
            residentStayDIV.Visible = true;
        }

        protected void ShowAvailableServices(object sender, EventArgs e) {
            availableServiceDIV.Visible = true;
        }

        protected void ShowProvidedServices(object sender, EventArgs e) {
            providedServiceDIV.Visible = true;
        }

        protected void ShowDisciplinaryActions(object sender, EventArgs e) {
            disciplinaryActionDIV.Visible = true;
        }


    }

}