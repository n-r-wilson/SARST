using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using SARST_DEV.Model;

namespace SARST_DEV {
    public partial class UserRegistrationRootValidation : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {
            var user = GetCurrentUser();
            if (user == null || user.type != UserType.ROOT) {
                Response.Redirect("~/");
            }
        }

        protected void ApproveButton_Click(object sender, EventArgs e) {
            // gets registration request by username, and then removes it form the queue.
            // I don't like that it has to do this, but since I can only pass a string it is the only immediate solution.
            
            string username = ((Button)sender).CommandArgument;

            RegistrationRequest request = SARSTDataContext.RegistrationRequestQueue.Find(x => x.username == username);
            if (request != null) {
                SARSTUser user = new SARSTUser { 
                    username        = request.username,
                    password        = request.password,
                    email_address   = request.email_address,
                    type            = request.user_type,
                };

                var _db = new SARSTDataContext();
                _db.AddUser(user);

                SARSTDataContext.RegistrationRequestQueue.Remove(request);

                MailMessage mailMessage = new MailMessage("RubberDucksCPSCEmail@gmail.com", request.email_address);
                mailMessage.Subject = "Your SARST registration request has been accepted.";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = "<p>Name: " + request.username + "</p>" + "<p>Email: " + request.email_address + "</p>" + "<p>We are pleased to inform you that your SARST registration request has been accepted. You may now log in to your account using the SARST login portal.</p>";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(mailMessage);
            }

            user_list.DataBind(); // updates the listview
        }

        protected void DenyButton_Click(object sender, EventArgs e) {
            string username = ((Button)sender).CommandArgument;

            RegistrationRequest request = SARSTDataContext.RegistrationRequestQueue.Find(x => x.username == username);
            if (request != null) {
                SARSTDataContext.RegistrationRequestQueue.Remove(request);

                MailMessage mailMessage = new MailMessage("RubberDucksCPSCEmail@gmail.com", request.email_address);
                mailMessage.Subject = "Your SARST registration request has been denied.";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = "<p>Name: " + request.username + "</p>" + "<p>Email: " + request.email_address + "</p>" + "<p>We are sorry to inform you that your SARST registration request has been denied. If you believe this has been done in error, you may file a new registration request.</p>";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(mailMessage);
            }

            user_list.DataBind();
        }

    }
}