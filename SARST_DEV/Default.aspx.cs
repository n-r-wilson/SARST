using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SARST_DEV.Model;
using Microsoft.AspNetCore.Identity;
using System.Data.Entity;


namespace SARST_DEV {

    public partial class SARSTPage : Page {
        public IEnumerable<SARSTUser> GetSARSTUsers() {
            var _db = new SARST_DEV.Model.SARSTDataContext();
            return _db.SARSTUsers;
        }
        public IEnumerable<Resident> GetResidents() {
            var _db = new SARST_DEV.Model.SARSTDataContext();
            return _db.Residents;
        }
        public IEnumerable<AvailableService> GetAvailableServices() {
            var _db = new SARST_DEV.Model.SARSTDataContext();
            return _db.AvailableServices;
        }
        public IEnumerable<ResidentStay> GetResidentStays() {
            var _db = new SARST_DEV.Model.SARSTDataContext();
            return _db.ResidentStays;
        }
        public IEnumerable<ProvidedService> GetProvidedServices() {
            var _db = new SARST_DEV.Model.SARSTDataContext();
            return _db.ProvidedServices;
        }
        public IEnumerable<DisciplinaryAction> GetDisciplinaryActions() {
            var _db = new SARST_DEV.Model.SARSTDataContext();
            return _db.DisciplinaryActions;
        }
        public IEnumerable<RegistrationRequest> GetRegistrationRequestQueue() {
            return SARSTDataContext.RegistrationRequestQueue;
        }
        public SARSTUser GetCurrentUser() {
            return (SARSTUser)Session["user"];
        }
    }

    public partial class _Default : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {
            var user = GetCurrentUser();
            if (user != null) {
                Response.Redirect("~/UserHome");
            }
        }
        protected void InitDB(object sender, EventArgs e) {
            SARSTDataContext context = new SARSTDataContext();

            GetSARSTUsers().ForEach(u => context.SARSTUsers.Add(u));
            GetResidents().ForEach(u => context.Residents.Add(u));
            context.SaveChanges();

            GetResidentStays().ForEach(u => context.ResidentStays.Add(u));
            GetAvailableServices().ForEach(u => context.AvailableServices.Add(u));
            context.SaveChanges();

            GetProvidedServices().ForEach(u => context.ProvidedServices.Add(u));
            GetDisciplinaryActions().ForEach(u => context.DisciplinaryActions.Add(u));
            context.SaveChanges();

            List<SARSTUser> GetSARSTUsers() {
                var passwordHasher = new PasswordHasher<SARSTUser>();
                //creates an instance of the PasswordHasher class, which provides methods to hash and verify passwords for SARSTUser
                var data = new List<SARSTUser> {
                new SARSTUser {
                    type = UserType.ROOT,
                    username = "ROOT",
                    password = passwordHasher.HashPassword(null, "123"),
                    //hashes the password and set it as the value of "password." the first parameter is set to "null" because a user object is not needed for this method
                }
            };
                return data;
            }

            List<Resident> GetResidents() {
                var data = new List<Resident> {
                new Resident {
                    first_name      = "johnny",
                    last_name       = "appleseed",
                    date_of_birth   = DateTime.Parse("11/11/1999"),
                    sex             = Sex.Male,
                    gender          = Gender.Male,
                    pronouns        = Pronouns.He_Him,
                    distinguishing_features = "none"
                }
            };
                return data;
            }

            List<AvailableService> GetAvailableServices() {
                var data = new List<AvailableService> {
                new AvailableService {
                    type = AvailableService.ServiceType.SA_Service,
                    title = "Snack",
                    description = "Provision of a snack to a shelter resident.",
                    date_effective    = DateTime.Parse("01/01/2000"),
                    date_discontinued = DateTime.Parse("12/31/2100")
                },
                new AvailableService {
                    type = AvailableService.ServiceType.SA_Service,
                    title = "Dinner",
                    description = "Provision of a dinner to a shelter resident.",
                    date_effective    = DateTime.Parse("01/01/2000"),
                    date_discontinued = DateTime.Parse("12/31/2100")
                },
                new AvailableService {
                    type = AvailableService.ServiceType.SA_Service,
                    title = "Laundry Services",
                    description = "Washing and/or drying of a resident's clothing.",
                    date_effective    = DateTime.Parse("01/01/2000"),
                    date_discontinued = DateTime.Parse("12/31/2100")
                },
                new AvailableService {
                    type = AvailableService.ServiceType.SA_Service,
                    title = "Hygiene Products",
                    description = "Provision of hygiene products to a shelter resident.",
                    date_effective    = DateTime.Parse("01/01/2000"),
                    date_discontinued = DateTime.Parse("12/31/2100")
                },
                new AvailableService {
                    type = AvailableService.ServiceType.SA_Service,
                    title = "Mental Health Services",
                    description = "Rehabilitation, Spiritual Healing, Veterans Services, and Help for Domestic Abuse",
                    date_effective    = DateTime.Parse("01/01/2000"),
                    date_discontinued = DateTime.Parse("12/31/2100")
                },
            };
                return data;
            }

            List<ProvidedService> GetProvidedServices() {
                var data = new List<ProvidedService> {
                new ProvidedService {
                    service_id = 1,
                    stay_id = 1,
                    dateTime = DateTime.Parse("01/01/2001")
                },
                new ProvidedService {
                    service_id = 2,
                    stay_id = 1,
                    dateTime = DateTime.Parse("01/01/2001")
                }
            };
                return data;
            }

            List<ResidentStay> GetResidentStays() {
                var data = new List<ResidentStay> {
                new ResidentStay {
                    resident_id  = 1,
                    provider_id  = 1,
                    dateTime_in  = DateTime.Parse("01/01/2000"),
                    dateTime_out = DateTime.Parse("01/02/2000")
                }
            };
                return data;
            }

            List<DisciplinaryAction> GetDisciplinaryActions() {
                var data = new List<DisciplinaryAction> {
                new DisciplinaryAction {
                    type = DisciplinaryAction.DisciplinaryActionType.Education,
                    stay_id = 1,
                    dateTime = DateTime.Parse("01/01/2001")
                },
                new DisciplinaryAction {
                    type = DisciplinaryAction.DisciplinaryActionType.Warning,
                    stay_id = 1,
                    dateTime = DateTime.Parse("01/01/2001")
                }
            };
                return data;
            }
        }
    }

}
