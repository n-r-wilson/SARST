<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResidentAdd.aspx.cs" Inherits="SARST_DEV.ResidentEntry" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
        
    <h1 style="text-align:center;">Add a Resident</h1>
    <p style="text-align:center;">Enter the resident's information below and click submit to add the resident to the database.</p>
        
    <table style="margin:auto;">
        <tr>
            <td class="rowLabel">First Name:</td>
            <td class="dataEntry">
                <asp:TextBox id="TextBoxFirstName" 
                    runat="server" 
                    Width="200px"></asp:TextBox>
            </td>
            <td class="validation">
                <asp:RequiredFieldValidator
                    runat="server" 
                    ControlToValidate="TextBoxFirstName" 
                    ErrorMessage="RequiredFieldValidator" 
                    ForeColor="#FF3300">First name is required!</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="rowLabel">Last Name:</td>
            <td class="dataEntry">
                <asp:TextBox id="TextBoxLastName" 
                    runat="server" 
                    Width="200px"></asp:TextBox>
            </td>
            <td class="validation">
                <asp:RequiredFieldValidator
                    runat="server" 
                    ControlToValidate="TextBoxLastName" 
                    ErrorMessage="RequiredFieldValidator" 
                    ForeColor="#FF3300">Last name is required!</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="rowLabel">Date of Birth:</td>
            <td class="dataEntry">
                <asp:TextBox id="TextBoxDOB" 
                    runat="server" 
                    Width="200px"
                    textmode="Date"></asp:TextBox>
            </td>
            <td class="validation">
                <asp:RequiredFieldValidator
                    runat="server" 
                    ControlToValidate="TextBoxDOB" 
                    ErrorMessage="RequiredFieldValidator" 
                    ForeColor="#FF3300">Date of Birth is required!</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="rowLabel">Sex:</td>
            <td class="dataEntry">
                <asp:DropDownList id="SexEntry" runat="server" Width="200px">
                    <asp:ListItem Value="Male"    >Male</asp:ListItem>
                    <asp:ListItem Value="Female"  >Female</asp:ListItem>
                    <asp:ListItem Value="Intersex">Intersex</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="rowLabel">Gender:</td>
            <td class="dataEntry">
                <asp:DropDownList id="GenderEntry" runat="server" Width="200px">
                    <asp:ListItem Value="Male"    >Male</asp:ListItem>
                    <asp:ListItem Value="Female"  >Female</asp:ListItem>
                    <asp:ListItem Value="Transgender">Transgender</asp:ListItem>
                    <asp:ListItem Value="Non_Binary">Non-Binary</asp:ListItem>
                    <asp:ListItem Value="Gender_Fluid">Gender Fluid</asp:ListItem>
                    <asp:ListItem Value="Other">Other</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="rowLabel">Pronouns:</td>
            <td class="dataEntry">
                <asp:DropDownList id="PronounsEntry" runat="server" Width="200px">
                    <asp:ListItem Value="He_Him"   >he/him</asp:ListItem>
                    <asp:ListItem Value="She_Her"  >she/her</asp:ListItem>
                    <asp:ListItem Value="They_Them">they/them</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="rowLabel">Distinguishing Features:</td>
            <td class="dataEntry">
                <asp:TextBox id="TextBoxFeatures" 
                    runat="server" 
                    Width="200px"></asp:TextBox>
            </td>
            <td class="validation"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><asp:Button style="margin-top: 10px;" runat="server" Text="Submit" OnClick="SubmitButton_Click" Width="200px"/></td>
            <td>&nbsp;</td>
        </tr>

    </table>

</asp:Content>
