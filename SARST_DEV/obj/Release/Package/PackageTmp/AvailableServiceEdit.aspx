<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AvailableServiceEdit.aspx.cs" Inherits="SARST_DEV.AvailableServiceEdit" %>

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

    <div id="ContentBlocker" style="position:absolute; width:100%; height:100%; background-color:rgba(77, 77, 77, 0.15)"></div>

    <div id="Content">

    <h1 style="text-align:center;">Edit an Available Service</h1>
    <p style="text-align:center;">Edit or Replace an AvailableService which will be available to residents and the AvailableService to the database.</p>
        
    <table style="margin:auto;">
        <tr>
            <td class="rowLabel">Title:</td>
            <td class="dataEntry">
                <asp:TextBox id="TextBoxTitle" 
                    runat="server" 
                    Width="200px"></asp:TextBox>
            </td>
            <td class="validation">
                <asp:RequiredFieldValidator
                    runat="server" 
                    ControlToValidate="TextBoxTitle" 
                    ErrorMessage="RequiredFieldValidator" 
                    ForeColor="#FF3300">Title is required!</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="rowLabel">Desciption</td>
            <td class="dataEntry">
                <asp:TextBox id="TextBoxDescription" 
                    runat="server" 
                    Width="200px"></asp:TextBox>
            </td>
            <td class="validation">
                <asp:RequiredFieldValidator
                    runat="server" 
                    ControlToValidate="TextBoxDescription" 
                    ErrorMessage="RequiredFieldValidator" 
                    ForeColor="#FF3300">Description is required!</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="rowLabel">Discontinue Date</td>
            <td class="dataEntry">
                <asp:TextBox ID="DiscontinueBox"
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

    </div>

    <script>
            if (<%: (((SARST_DEV.Model.AvailableService)Session["editService"]).type != SARST_DEV.Model.AvailableService.ServiceType.SA_Service).ToString().ToLower() %>) {
                document.getElementById("ContentBlocker").remove();
            }
            else document.getElementById("Content").style.pointerEvents = "none";
    </script>

</asp:Content>
