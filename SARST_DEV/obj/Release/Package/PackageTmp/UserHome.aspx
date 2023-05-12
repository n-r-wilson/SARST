<%@ Page Title="User Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="SARST_DEV.UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        h1, p {
            color: #32292f;
        }
        tr {
            height: 20px;
        }
        td.rowLabel {
            padding-right:20px;
        }
    </style>
    <div style="width: 80%; margin:auto;">
        <h1>Welcome</h1>
        <p>You have been logged in successfully.</p>

        <h2>User Info</h2>
            <asp:FormView ID="userDetail" runat="server" ItemType="SARST_DEV.Model.SARSTUser" SelectMethod ="GetCurrentUser" RenderOuterTable="false">
            <ItemTemplate>
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
            </ItemTemplate>
        </asp:FormView>

    </div>

</asp:Content>
