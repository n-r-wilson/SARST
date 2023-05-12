<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="SARST_DEV.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        h1, p {
            color: #32292f;
        }
        tr {
            height: 20px;
        }
        td.rowLabel {
            width: 120px;
        }
    </style>
    <div style="width: 500px; margin: auto;">
        <h1 style="text-align: center;">User List</h1>
        <p style="text-align: center;>This is a full listing of all SARSTUsers in the database. This is present for debugging purposes and may not be present in the final release.</pstyle="text-align:>
        <asp:ListView ID="user_list"  
            ItemType="SARST_DEV.Model.SARSTUser" 
            runat="server"
            SelectMethod="GetSARSTUsers">
            <ItemTemplate>
                <div style="border-radius: 5px; border: 2px solid darkblue; padding: 10px; margin-top: 10px;">
                    <table>
                        <tr>
                            <td class="rowLabel">Username:</td>
                            <td><%#: Item.username %></td>
                        </tr>
                        <tr>
                            <td class="rowLabel">Email Address:</td>
                            <td><%#: Item.email_address %></td>
                        </tr>
                        <tr>
                            <td class="rowLabel">User Type:</td>
                            <td><%#: Item.type %></td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

</asp:Content>
