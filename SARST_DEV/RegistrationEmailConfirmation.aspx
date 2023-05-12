<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrationEmailConfirmation.aspx.cs" Inherits="SARST_DEV.RegistrationEmailConfirmation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        h1, p {
            color: #32292f;
        }
        tr {
            height: 50px;
        }
        td.rowLabel {
            width: 300px;
            text-align:right;
            padding-right:20px;
        }
        td.dataEntry {
            width: 200px;
        }
        td.validation {
            width: 300px;
            padding-left: 20px;
        }
    </style>
        
    <h1 style="text-align:center;">Email Confirmation</h1>
    <p style="text-align:center;">
        An email containing a confirmation code has been sent to the provided email address. 
        Please enter this confirmation code below to finalize submission of your registration request
    </p>
        
    <table style="margin:auto;">
        <tr>
            <td class="rowLabel">Confirmation Code:</td>
            <td class="dataEntry">
                <asp:TextBox ID="TextBoxConfirmCode" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td class="validation">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxConfirmCode" ErrorMessage="RequiredFieldValidator" ForeColor="#FF3300">Username is required!</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="rowLabel">&nbsp;</td>
            <td class="dataEntry">
                <asp:Button runat="server" Text="Submit" OnClick="SubmitButton_Click" style="width: 200px;"/>
            <td class="validation">&nbsp;</td>
        </tr>
    </table>

</asp:Content>
