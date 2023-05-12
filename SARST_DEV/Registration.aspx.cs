using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using SARST_DEV.Model;
using Microsoft.AspNetCore.Identity;

namespace SARST_DEV
{
    public partial class Registration : SARSTPage {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void SubmitButton_Click(object sender, EventArgs e) {
            RegistrationRequest registrationRequest = new RegistrationRequest {
                username        = TextBoxUsername.Text,
                password        = TextBoxPassword.Text,
                email_address   = TextBoxEmail.Text,
                user_type       = (UserType)Enum.Parse(typeof(UserType), UserTypeEntry.SelectedValue)
            };

            if (!Utility.IsValidPassword(registrationRequest.password)) {
                Session.Add("messageFromSender", "Password must contain at least 8 characters, 2 numbers, and 2 symbols. Valid symbols are: !@#$%^&*()-_=+");
                return;
            }

            var result = registrationRequest.CheckDuplicated();
            if (result.duplicated) {
                Session.Add("messageFromSender", result.message);
                return;
            }

            var passwordHasher = new PasswordHasher<SARSTUser>();
            registrationRequest.password = passwordHasher.HashPassword(null, TextBoxPassword.Text);
            Session.Add("registrationRequest", registrationRequest);
            Response.Redirect("~/RegistrationEmailConfirmation");
        }
    }
}