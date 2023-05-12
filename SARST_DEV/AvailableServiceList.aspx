<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AvailableServiceList.aspx.cs" Inherits="SARST_DEV.AvailableServiceList" %>

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
        }
        td.data {
        }
    </style>
    <div style="width: 600px; margin: auto;">
        <h1 style="text-align: center;">Available Services List</h1>
        <p style="text-align: center;">This is a full listing of all Available Services in the database.</p>
        <asp:ListView ID="user_list"  
            ItemType="SARST_DEV.Model.AvailableService" 
            runat="server"
            SelectMethod="GetAvailableServices">
            <ItemTemplate>
                <div class="list-item">
                    <div class="list-item-label">
                        <asp:Button runat="server" Width="80px" ID="EditButton"
                            Text="Edit" 
                            OnClick="EditButton_Click"
                            CommandArgument="<%#: Item.id %>" CssClass="list-item-button"/>
                    </div>
                    <div class="list-item-content">
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
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

</asp:Content>
