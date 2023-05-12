using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using SARST_DEV.Model;

namespace SARST_DEV {
    public partial class RegistrationEmailConfirmation : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {
            RegistrationRequest registrationRequest = (RegistrationRequest)Session["registrationRequest"];

            if (registrationRequest == null) {
                Session.Add("messageFromSender", "An error occured submitting your registration request, please try again.");
                Response.Redirect("~/Registration");
            }

            if (!IsPostBack) GenerateConfirmationCode();
        }

        protected void SubmitButton_Click(object sender, EventArgs e) {
            RegistrationRequest registrationRequest = (RegistrationRequest)Session["registrationRequest"];
            string confirmationCode = (string)Session["confirmationCode"];

            if (registrationRequest == null || confirmationCode == null) {
                Session.Add("messageFromSender", "An error occured submitting your registration request, please try again.");
                Response.Redirect("~/Registration");
            }

            if (TextBoxConfirmCode.Text == confirmationCode) {
                SARSTDataContext.RegistrationRequestQueue.Add(registrationRequest);
                Session.Add("messageFromSender", "Registration request submitted successfully. We will notify you once the request has been approved by the system administrator.");
                Response.Redirect("~/");
            }
            else {
                Session.Add("messageFromSender", "The confirmation code you entered was incorrect. Please try again.");
            }
        }

        protected void ResendButton_Click(object sender, EventArgs e) {
            RegistrationRequest registrationRequest = (RegistrationRequest)Session["registrationRequest"];
            if (registrationRequest == null) {
                Session.Add("messageFromSender", "An error occured submitting your registration request, please try again.");
                Response.Redirect("~/Registration");
            }
            GenerateConfirmationCode();
        }

        protected void GenerateConfirmationCode() {
            RegistrationRequest registrationRequest = (RegistrationRequest)Session["registrationRequest"];

            // this is probably not the best possibel way to do this, but it should be fine
            string confirmationCode = "";
            Random random = new Random();
            for (int i = 0; i < 9; i++) {
                confirmationCode += random.Next(0, 10).ToString();
            }

            Session.Add("confirmationCode", confirmationCode);

            //using string.Format for text alignment and font properties in the email sent to the user
            string body = string.Format
            (
                 "<center><p>Hi, " + registrationRequest.username + "</p></center>" +
                 "<center><p>Thank you for using the Salvation Army Resident Services Tracker.</p></center>" +
                 "<center><p>To finalize submission of your login request, please enter this confirmation code listed below into the SARST application:</p></center>" +
                 "<center><p><span style='font-size:24px; font-weight:bold;'>" + confirmationCode + "</span></p></center>" +
                 "<center><p>If you did not submit a login request with SARST, please ignore this confirmation code and consider regularly changing passwords.</p></center>"
            );

            MailMessage mailMessage = new MailMessage("RubberDucksCPSCEmail@gmail.com", registrationRequest.email_address);
            mailMessage.Subject = "Please confirm your SARST email address.";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(mailMessage);
        }


    }
}