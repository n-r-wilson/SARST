<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResidentStayEdit.aspx.cs" Inherits="SARST_DEV.ResidentStayEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        h1, p {
            color: #32292f;
        }
        tr {
            height: 20px;
        }
        td.rowLabel {
            width: 100px;
            text-align:right;
            padding-right:20px;
        }
        td.data {
            width: 350px;
        }
    </style>

    <div id="ContentBlocker" style="position:absolute; width:100%; height:100%; background-color:rgba(77, 77, 77, 0.15)"></div>

    <div id="Content">

        <div style="width: 500px; margin: auto;">
            <h1 style="text-align: center;">ResidentStay Detail View</h1>
            <p style="text-align: center;"></p>
            <div class="list-item-content list-item">
                <table>
                    <tr>
                        <td class="rowLabel">Provider:</td>
                        <td class="data"><%: ((SARST_DEV.Model.ResidentStay)Session["editResidentStay"]).provider.username %></td>
                    </tr>
                    <tr>
                        <td class="rowLabel">Resident:</td>
                        <td class="data"><%: ((SARST_DEV.Model.ResidentStay)Session["editResidentStay"]).resident.full_name %> <%#: ((SARST_DEV.Model.ResidentStay)Session["editResidentStay"]).resident.last_name %></td>
                    </tr>
                    <tr>
                        <td class="rowLabel">Time In:</td>
                        <td class="data"><%: ((SARST_DEV.Model.ResidentStay)Session["editResidentStay"]).dateTime_in == null ? "" : ((DateTime)((SARST_DEV.Model.ResidentStay)Session["editResidentStay"]).dateTime_in).ToString() %></td>
                    </tr>
                    <tr>
                        <td class="rowLabel">Time Out:</td>
                        <td class="data"><%: ((SARST_DEV.Model.ResidentStay)Session["editResidentStay"]).dateTime_out == null ? "" : ((DateTime)((SARST_DEV.Model.ResidentStay)Session["editResidentStay"]).dateTime_out).ToString() %></td>
                    </tr>
                </table>
            </div>
            <hr />

            <h2 style="text-align: center;">Provided Services</h2>
            <asp:ListView ID="provided_services_list"  
                ItemType="SARST_DEV.Model.ProvidedService" 
                runat="server"
                SelectMethod="GetResidentStayProvidedServices">
                <ItemTemplate>
                    <div class="list-item-content list-item">
                        <table>
                            <tr>
                                <td class="rowLabel">Service:</td>
                                <td class="data"><%#: Item.service.title %></td>
                            </tr>
                            <tr>
                                <td class="rowLabel">Description:</td>
                                <td class="data"><%#: Item.service.description %></td>
                            </tr>
                            <tr>
                                <td class="rowLabel">Date/Time:</td>
                                <td class="data"><%#: Item.dateTime.ToString() %></td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <div class="list-item-content list-item">
                <table>
                    <tr>
                        <td class="rowLabel">
                            <asp:DropDownList id="ServiceEntry" runat="server" Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td class="dataEntry">
                            <asp:Button Text="Add Service" runat="server" OnClick="AddServiceButton_Click"/>
                        </td>
                    </tr>
                </table>
            </div>
            <hr />

            <h2 style="text-align: center;">Disciplinary Actions</h2>
            <asp:ListView ID="disciplinary_actions_list"  
                ItemType="SARST_DEV.Model.DisciplinaryAction" 
                runat="server"
                SelectMethod="GetResidentStayDisciplinaryActions">
                <ItemTemplate>
                    <div class="list-item-content list-item">
                        <table>
                            <tr>
                                <td class="rowLabel">Action Type:</td>
                                <td class="data"><%#: Item.type %></td>
                            </tr>
                            <tr>
                                <td class="rowLabel">Date/Time:</td>
                                <td class="data"><%#: Item.dateTime.ToString() %></td>
                            </tr>
                            <tr>
                                <td class="rowLabel">Notes:</td>
                                <td class="data"><%#: Item.notes %></td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <div class="list-item-content list-item">
                <table>
                    <tr>
                        <td class="rowLabel">
                            <asp:DropDownList id="DisciplineEntry" runat="server" Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td class="dataEntry">
                            <asp:Button Text="Add Disciplinary Action" runat="server" OnClick="AddDisciplinaryActionButton_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="padding-top:5px">
                            Notes:
                            <asp:TextBox id="TextBoxDisciplineNotes" 
                                runat="server" 
                                Width="600px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <hr />

            <h2 style="text-align: center;">Events</h2>
            <div style="text-align: center;">
                <p>Record any events of note for the resident's stay.</p>
                <asp:TextBox id="TextBoxEvents" 
                    runat="server" 
                    Width="200px"
                    TextMode="MultiLine"></asp:TextBox>
                <br />
                <asp:Button Text="Save" runat="server" OnClick="SaveButton_Click" />
            </div>
            <hr />

            <h2 style="text-align: center;">Check Out Resident</h2>
            <div style="margin:auto;">
                <p>NOTE: Once a resident has been checked out, the current Resident Stay is no longer active, and may not have any further services or disciplnary actions recorded under this visit. 
                    If further events must be recorded, the resident must be checked back in under a separate stay.</p>
                <asp:Button Text="Check Out Resident" runat="server" OnClick="CheckOutButton_Click" />
            </div>

        </div>

    </div>
    
        <script>
            if (<%: ((SARST_DEV.Model.ResidentStay)Session["editResidentStay"]).isActive().ToString().ToLower() %>) {
                document.getElementById("ContentBlocker").remove();
            }
            else document.getElementById("Content").style.pointerEvents = "none";
        </script>


</asp:Content>
