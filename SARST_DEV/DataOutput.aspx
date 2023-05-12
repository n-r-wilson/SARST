<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataOutput.aspx.cs" Inherits="SARST_DEV.DataOutput" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
        h1, p {
            color: #32292f;
        }
        tr {
            height: 50px;
        }
        td.rowLabel {
            text-align:right;
            padding-right:20px;
        }
    </style>
    
    <h1 style="text-align: center;">Export SARST Data</h1>
    <p style="text-align: center;">Below you may download CSV information files on residents, services, and disciplinary actions.</p>
    <hr />

    <asp:Panel runat="server" DefaultButton="GenerateReportButton">
        <h2 style="text-align: center;">Shelter Visit Reporting</h2>
        <p style="text-align: center;">This will generate a report on all shelter visits between the specified dates.</p>
        <div class="list-item-content list-item" style="width:500px; margin:auto;">
            <table style="margin-left:90px;">
                <tr>
                    <td class="rowLabel">Start Date:</td>
                    <td class="dataEntry">
                        <asp:TextBox runat="server" ID="StartDateTextBox" TextMode="Date"/>  
                    </td>
                </tr>
                <tr>
                    <td class="rowLabel">End Date:</td>
                    <td class="dataEntry">
                        <asp:TextBox runat="server" ID="EndDateTextBox" TextMode="Date"/>  
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="GenerateReportButton" runat="server" Text="Generate Report" OnClick="GenerateReportButton_Click" style="width:100%;" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:panel>
    <hr />

    <p>
        <%--<asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" Width="471px">Below you may put all user data from the SARST database into a CSV file!</asp:TextBox>
        <br />--%>

        <br />
        <asp:Button Text="Download Resident Data" runat="server" OnClick="ResidentDataButton_Click"/>
        <br />
        <asp:Button Text="Download Resident Stay Data" runat="server" OnClick="ResidentStayDataButton_Click"/>
            <br />
        <asp:Button Text="Download Available Service(s) Data" runat="server" OnClick="ResidentAvailableServicesButton_Click"/>
            <br />
        <asp:Button Text="Download Provided Service(s) Data" runat="server" OnClick="ResidentProvidedServicesButton_Click"/>
            <br />
        <asp:Button Text="Download Disciplinary Actions Data" runat="server" OnClick="ResidentDisciplinaryActionsButton_Click"/>
        
    </p>
    

</asp:Content>

