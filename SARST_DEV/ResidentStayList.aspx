<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResidentStayList.aspx.cs" Inherits="SARST_DEV.ResidentStayList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        h1, p {
            color: #32292f;
        }
        tr {
            height: 20px;
        }
        td.rowLabel {
            width: 300px;
            text-align:right;
            padding-right:20px;<a href="ResidentStayList.aspx.cs">ResidentStayList.aspx.cs</a>
        }
        td.data {
            width: 500px;
        }
    </style>
    <div style="width: 500px; margin: auto;">
        <h1 style="text-align: center;">ResidentStay List</h1>
        <p style="text-align: center;">This is a full listing of all ResidentStays in the database.</p>
        <asp:ListView ID="user_list"  
            ItemType="SARST_DEV.Model.ResidentStay" 
            runat="server"
            SelectMethod="GetResidentStays">
            <ItemTemplate>
                <div class="list-item">
                    <div class="list-item-label">
                        <asp:Button runat="server" Width="80px" ID="EditViewButton"
                            Text="View" 
                            OnClick="EditViewButton_Click"
                            CommandArgument="<%#: Item.id %>" CssClass="list-item-button"/>
                    </div>
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


</asp:Content>
