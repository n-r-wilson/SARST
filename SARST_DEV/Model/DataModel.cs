using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace SARST_DEV.Model {

    // User Login Data Model
    public enum UserType {
        ROOT,
        ADMIN,
        SERVICE_PROVIDER
    }
    public class SARSTUser
    {
        [Required, Key, DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public UserType type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email_address { get; set; }
    }

    public class LoginRequest {
        public string username;
        public string password;

        public (SARSTUser user, string message) Validate() {
            var _db = new SARST_DEV.Model.SARSTDataContext();
            //creates a new instance of the PasswordHasher<SARSTUser> class
            var passwordHasher = new PasswordHasher<SARSTUser>();

            foreach (var user in _db.SARSTUsers) {
                if (user.username == username) {
                    var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.password, password);
                    if (passwordVerificationResult == PasswordVerificationResult.Success) {
                        return (user, "Login successful.");
                    }
                    return (null, "Username and password do not match.");
                }
            }
            return (null, "No user found with matching username.");
        }
    }
    public class RegistrationRequest {
        public UserType user_type;
        public string username;
        public string password;
        public string email_address;

        public (bool duplicated, string message) CheckDuplicated() {
            var _db = new SARSTDataContext();
            foreach (var user in _db.SARSTUsers) {
                if (user.username == username)
                    return (true, "Username is already taken.");
                if (user.email_address == email_address)
                    return (true, "Email Address is already taken.");
            }

            foreach (var user in SARSTDataContext.RegistrationRequestQueue) {
                if (user.username == username)
                    return (true, "Username is already taken.");
                if (user.email_address == email_address)
                    return (true, "Email Address is already taken. Do you have a registration request that is already pending?");
            }

            return (false, "");
        }
    }

    // Resident Services Data Model
    public enum Sex { Male, Female, Intersex }
    public enum Gender { Male, Female, Transgender, Non_Binary, Gender_Fluid, Other }
    public enum Pronouns { He_Him, She_Her, They_Them }

    public class Resident {
        [Required, Key, DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime date_of_birth { get; set; }
        public Sex sex { get; set; }
        public Gender gender { get; set; }
        public Pronouns pronouns { get; set; }
        public string distinguishing_features { get; set; }

        public string full_name { get => $"{first_name} {last_name}"; }
    }
    public class ResidentStay {
        [Required, Key, DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("resident_id")]
        public Resident resident {
            get => new SARSTDataContext().Residents.FirstOrDefault(r => r.id == resident_id);
        }
        public int resident_id { get; set; }

        public DateTime dateTime_in { get; set; }
        public DateTime dateTime_out { get; set; } = DateTime.MaxValue;

        [ForeignKey("provider_id")]
        public SARSTUser provider {
            get => new SARSTDataContext().SARSTUsers.FirstOrDefault(u => u.id == provider_id);
        }
        public int provider_id { get; set; }

        public string events { get; set; }

        public bool isActive() => dateTime_out.Date == DateTime.MaxValue.Date;

        public List<ProvidedService> getProvidedServices() {
            var list = new List<ProvidedService>();
            var db = new SARSTDataContext();
            foreach (var service in db.ProvidedServices) {
                if (service.stay_id == this.id)
                    list.Add(service);
            }
            return list;
        }

        public List<DisciplinaryAction> getDisciplinaryActions() {
            var list = new List<DisciplinaryAction>();
            var db = new SARSTDataContext();
            foreach (var action in db.DisciplinaryActions) {
                if (action.stay_id == this.id)
                    list.Add(action);
            }
            return list;
        }

    }
    public class AvailableService {
        [Required, Key, DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public ServiceType type { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime date_effective { get; set; }
        public DateTime date_discontinued { get; set; }

        public string dateTime_discontinued_string() {
            return date_discontinued > DateTime.Now ? "" : date_discontinued.ToShortDateString();
        }

        public enum ServiceType {
            SA_Service,
            SetupService
        }
    }
    public class ProvidedService {
        [Required, Key, DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("service_id")]
        public AvailableService service {
            get => new SARSTDataContext().AvailableServices.FirstOrDefault(s => s.id == service_id);
        }
        public int service_id { get; set; }

        [ForeignKey("stay_id")]
        public ResidentStay stay {
            get => new SARSTDataContext().ResidentStays.FirstOrDefault(u => u.id == stay_id);
        }
        public int stay_id { get; set; }

        public DateTime dateTime { get; set; }
    }
    public class DisciplinaryAction {
        [Required, Key, DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DisciplinaryActionType type { get; set; }

        [ForeignKey("stay_id")]
        public ResidentStay stay {
            get => new SARSTDataContext().ResidentStays.FirstOrDefault(u => u.id == stay_id);
        }
        public int stay_id { get; set; }

        public DateTime dateTime { get; set; }
        public string notes { get; set; }

        public enum DisciplinaryActionType {
            Warning,
            Education,
            Last_Chance_Contact,
            Step_Away
        }
    }

}