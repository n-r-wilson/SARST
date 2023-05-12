<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResidentList.aspx.cs" Inherits="SARST_DEV.ResidentList" %>

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
        <h1 style="text-align: center;">Resident List</h1>
        <p style="text-align: center;">This is a full listing of all Residents in the database.</p>

        <asp:ListView ID="user_list"  
            ItemType="SARST_DEV.Model.Resident" 
            runat="server"
            SelectMethod="GetResidentsSearch">
            <ItemTemplate>
                <div class="list-item">
                    <div class="list-item-label">
                        <asp:Button runat="server" Width="80px"
                            Text="Edit" 
                            OnClick="EditButton_Click"
                            CommandArgument="<%#: Item.id %>" CssClass="list-item-button"/>
                        <asp:Button runat="server" Width="80px"
                            Text="Check In" 
                            OnClick="CheckInButton_Click"
                            CommandArgument="<%#: Item.id %>" CssClass="list-item-button"/>
                    </div>
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

</asp:Content>
