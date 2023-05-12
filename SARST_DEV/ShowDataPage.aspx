<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowDataPage.aspx.cs" Inherits="SARST_DEV.WebForm1" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        h1, p {
            color: #32292f;
        }
        tr {
            height: 20px;
        }
        td.rowLabel {
            text-align:right;
            padding-right:20px;
            width:150px;
        }
        td.data {
        }

    </style>

    <div style="width: 500px; margin: auto;">
        <h1 style="text-align: center;">Database Output</h1>
        <p style="text-align:center;">This page allows for viewing the data of different tables in the database.</p>
    </div>

    <asp:Button runat="server" Text="Resident List" OnClick="ShowResidentList"/> 
    <asp:Button runat="server" Text="Resident Stay List" OnClick="ShowResidentStayList"/> 
    <asp:Button runat="server" Text="Available Services" OnClick="ShowAvailableServices" />
    <asp:Button runat="server" Text="Provided Services" OnClick="ShowProvidedServices" />
    <asp:Button runat="server" Text="Disciplinary Actions" OnClick="ShowDisciplinaryActions" />

    <div style="width: 500px; margin: auto;" id="residentDIV" runat="server">
        <h1 style="text-align: center;">Resident List</h1>
        <p style="text-align: center;">This is a full listing of all Residents in the database.</p>

        <asp:ListView ID="user_list"  
            ItemType="SARST_DEV.Model.Resident" 
            runat="server"
            SelectMethod="GetResidentsSearch">
            <ItemTemplate>
                <div class="list-item">
                    <div class="list-item-content">
                        <table>
                            <tr>
                                <td class="rowLabel">First Name:</td>
                                <td class="data"><%#: Item.first_name %></td>
                            </tr>
                            <tr>
                                <td class="rowLabel">Last Name:</td>
                                    <td class="data"><%#: Item.last_name %></td>
                            </tr>
                            <tr>
                                <td class="rowLabel">Date of Birth:</td>
                                <td class="data"><%#: Item.date_of_birth.ToShortDateString() %></td>
                            </tr>
                            <tr>
                                <td class="rowLabel">Sex:</td>
                                <td class="data"><%#: Item.sex %></td>
                            </tr>
                            <tr>
                                <td class="rowLabel">Gender:</td>
                                <td class="data"><%#: Item.gender %></td>
                            </tr>
                            <tr>
                                <td class="rowLabel">Pronouns:</td>
                                <td class="data"><%#: Item.pronouns %></td>
                            </tr>
                            <tr>
                                <td class="rowLabel">Distinguishing Features:</td>
                                <td class="data"><%#: Item.distinguishing_features %></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

    <div style="width: 500px; margin: auto;" id="residentStayDIV" runat="server">
        <h1 style="text-align: center;">Resident Stay List</h1>
        <p style="text-align: center;">This is a full listing of all Resident Stays in the database.</p>

         <asp:ListView ID="ListView1"  
            ItemType="SARST_DEV.Model.ResidentStay" 
            runat="server"
            SelectMethod="GetResidentStays">
            <ItemTemplate>
                <div class="list-item">
                    <%--<div class="list-item-label">
                        <asp:Button runat="server" Width="80px" ID="EditViewButton"
                            Text="View" 
                            OnClick="EditViewButton_Click"
                            CommandArgument="<%#: Item.id %>" CssClass="list-item-button"/>
                            CommandArgument="<%#: Item.id %>" CssClass="list-item-button"/>
                    </div>--%>
                    <div class="list-item-content">
                        <table>
                            <tr>
                                <td class="rowLabel">Provider:</td>
                                <td class="data"><%#: Item.provider.username %></td>
                            </tr>
                            <tr>
                                <td class="rowLabel">Resident:</td>
                                <td class="data"><%#: Item.resident.first_name %> <%#: Item.resident.last_name %></td>
                            </tr>
                            <tr>
                                <td class="rowLabel">Time In:</td>
                                <td class="data"><%#: ((DateTime)Item.dateTime_in).ToString() %></td>
                            </tr>
                            <tr>
                                <td class="rowLabel">Time Out:</td>
                                <td class="data"><%#: Item.isActive() ? "" : ((DateTime)Item.dateTime_out).ToString() %></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

    <div style="width: 600px; margin: auto;" id="availableServiceDIV" runat="server">
        <h1 style="text-align: center;">Available Services List</h1>
        <p style="text-align: center;">This is a full listing of all Available Services in the database.</p>
        <asp:ListView ID="ListView2"  
            ItemType="SARST_DEV.Model.AvailableService" 
            runat="server"
            SelectMethod="GetAvailableServices">
            <ItemTemplate>
                <div class="list-item-content list-item">
                    <table>
                        <tr>
                            <td class="rowLabel">Title:</td>
                            <td class="data"><%#: Item.title %></td>
                        </tr>
                        <tr>
                            <td class="rowLabel">Description:</td>
                            <td class="data"><%#: Item.description %></td>
                        </tr>
                        <tr>
                            <td class="rowLabel">Effective:</td>
                            <td class="data"><%#: Item.date_effective.ToShortDateString() %> - <%#: Item.dateTime_discontinued_string() %></td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

    <div style="width: 600px; margin: auto;" id="providedServiceDIV" runat="server">
        <h1 style="text-align: center;">Provided Services List</h1>
        <p style="text-align: center;">This is a full listing of all Provided Services in the database.</p>
        <asp:ListView ID="ListView3"  
            ItemType="SARST_DEV.Model.ProvidedService" 
            runat="server"
            SelectMethod="GetProvidedServices">
            <ItemTemplate>
                <div class="list-item-content list-item">
                    <table>
                        <tr>
                            <td class="rowLabel">Service ID:</td>
                            <td class="data"><%#: Item.service_id %></td>
                        </tr>
                        <tr>
                            <td class="rowLabel">Stay ID:</td>
                            <td class="data"><%#: Item.stay_id %></td>
                        </tr>
                        <tr>
                            <td class="rowLabel">Effective:</td>
                            <td class="data"><%#: Item.dateTime %></td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

    <div style="width: 600px; margin: auto;" id="disciplinaryActionDIV" runat="server">
        <h1 style="text-align: center;">Disciplinary Actions List</h1>
        <p style="text-align: center;">This is a full listing of all Disciplinary Actions in the database.</p>
        <asp:ListView ID="ListView4"  
            ItemType="SARST_DEV.Model.DisciplinaryAction" 
            runat="server"
            SelectMethod="GetDisciplinaryActions">
            <ItemTemplate>
                <div class="list-item-content list-item">
                    <table>
                        <tr>
                            <td class="rowLabel">Type:</td>
                            <td class="data"><%#: Item.type %></td>
                        </tr>
                        <tr>
                            <td class="rowLabel">Stay ID:</td>
                            <td class="data"><%#: Item.stay_id %></td>
                        </tr>
                        <tr>
                            <td class="rowLabel">Effective:</td>
                            <td class="data"><%#: Item.dateTime %></td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>



</asp:Content>
