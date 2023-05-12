<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResidentSearch.aspx.cs" Inherits="SARST_DEV.ResidentSearch" %>

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
        
    <h1 style="text-align:center;">Resident Search</h1>
    <p style="text-align:center;">Search for a resident based on identifying information.</p>
        
    <table style="margin:auto;">
        <tr>
            <td class="rowLabel">First Name:</td>
            <td class="dataEntry">
                <asp:TextBox id="TextBoxFirstName" 
                    runat="server" 
                    Width="200px"></asp:TextBox>
            </td>
            <td class="validation"></td> <!-- Here for formatting purposes -->
        </tr>
        <tr>
            <td class="rowLabel">Last Name:</td>
            <td class="dataEntry">
                <asp:TextBox id="TextBoxLastName" 
                    runat="server" 
                    Width="200px"></asp:TextBox>
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
        </tr>
        <tr>
            <td class="rowLabel">Distinguishing Features:</td>
            <td class="dataEntry">
                <asp:TextBox id="TextBoxFeatures" 
                    runat="server" 
                    Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><asp:Button style="margin-top: 10px;" runat="server" Text="Submit" OnClick="SubmitButton_Click" Width="200px"/></td>
            <td>&nbsp;</td>
        </tr>

    </table>


</asp:Content>
