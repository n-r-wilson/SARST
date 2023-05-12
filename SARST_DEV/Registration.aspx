<%@ Page Title="Registration" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="SARST_DEV.Registration" %>

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
        
    <h1 style="text-align:center;">Registration</h1>
    <p style="text-align:center;">Enter user info below to register for an account.</p>
        
    <table style="margin:auto;">
        <tr>
            <td class="rowLabel">Username:</td>
            <td class="dataEntry">
                <asp:TextBox id="TextBoxUsername" 
                    runat="server" 
                    Width="200px"></asp:TextBox>
            </td>
            <td class="validation">
                <asp:RequiredFieldValidator
                    runat="server" 
                    ControlToValidate="TextBoxUsername" 
                    ErrorMessage="RequiredFieldValidator" 
                    ForeColor="#FF3300">Username is required!</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="rowLabel">Password:</td>
            <td class="dataEntry">
                <asp:TextBox id="TextBoxPassword" 
                    runat="server" 
                    TextMode="Password" 
                    Width="200px"></asp:TextBox>
            </td>
            <td class="validation">
                <asp:RequiredFieldValidator 
                    runat="server" 
                    ControlToValidate="TextBoxPassword" 
                    ErrorMessage="RequiredFieldValidator" 
                    ForeColor="#FF3300">
                    Password is required!
                </asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="rowLabel">Confirm Password:</td>
            <td class="dataEntry">
                <asp:TextBox id="TextBoxConfirmPassword" 
                    runat="server" 
                    TextMode="Password" 
                    Width="200px"></asp:TextBox>
            </td>
            <td class="validation">
                <asp:RequiredFieldValidator 
                    runat="server" 
                    ControlToValidate="TextBoxConfirmPassword" 
                    ErrorMessage="RequiredFieldValidator" 
                    ForeColor="#FF3300">Confirm your password!</asp:RequiredFieldValidator>
                <br />
                <asp:CompareValidator id="CompareValidator1" runat="server" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxConfirmPassword" ErrorMessage="CompareValidator" ForeColor="#FF3300">Passwords don&#39;t match!</asp:CompareValidator>
            </td>
        </tr>

        <tr>
            <td class="rowLabel">E-Mail:</td>
            <td class="dataEntry">
                <asp:TextBox id="TextBoxEmail" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td class="validation">
                <asp:RequiredFieldValidator 
                    runat="server" 
                    ControlToValidate="TextBoxEmail" 
                    ErrorMessage="RequiredFieldValidator" 
                    ForeColor="#FF3300">E-Mail is required!</asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator 
                    runat="server" 
                    ControlToValidate="TextBoxEmail" 
                    ErrorMessage="You must enter a valid E-Mail." 
                    ForeColor="#FF3300" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td class="rowLabel">User Type:</td>
            <td class="dataEntry">
                <asp:DropDownList id="UserTypeEntry" runat="server" Width="200px">
                    <asp:ListItem Value="ADMIN"           >Admin           </asp:ListItem>
                    <asp:ListItem Value="SERVICE_PROVIDER">Service Provider</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="validation">
                <asp:RequiredFieldValidator 
                    runat="server" 
                    ControlToValidate="UserTypeEntry" 
                    ErrorMessage="RequiredFieldValidator" 
                    ForeColor="#FF3300">
                    User type is required!
                </asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td><asp:Button style="margin-top: 10px;" runat="server" Text="Submit" OnClick="SubmitButton_Click" Width="200px"/></td>
            <td>&nbsp;</td>
        </tr>

    </table>

</asp:Content>



