<%@ Title="Login" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SARST_DEV.Login" %>

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
        
    <h1 style="text-align:center;">Login</h1>
    <p style="text-align:center;">Enter user info below to sign in to your account.</p>
        
    <table style="margin:auto;">
        <tr>
            <td class="rowLabel">Username:</td>
            <td class="dataEntry">
                <asp:TextBox ID="TextBoxUN" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td class="validation">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUN" ErrorMessage="RequiredFieldValidator" ForeColor="#FF3300">Username is required!</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="rowLabel">Password:</td>
            <td class="dataEntry">
                <asp:TextBox ID="TextBoxPW" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
            </td>
            <td class="validation">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPW" ErrorMessage="RequiredFieldValidator" ForeColor="#FF3300">Password is required!</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="rowLabel">&nbsp;</td>
            <td class="dataEntry">
                <asp:Button runat="server" Text="Login" OnClick="LoginButton_Click" style="width: 200px;"/>
            <td class="validation">&nbsp;</td>
        </tr>
    </table>

</asp:Content>