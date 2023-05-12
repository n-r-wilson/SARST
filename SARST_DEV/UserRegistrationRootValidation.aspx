<%@ Page Title="User Registration Root Validation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegistrationRootValidation.aspx.cs" Inherits="SARST_DEV.UserRegistrationRootValidation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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

    <h1 style="text-align:center;">User Registration Requests</h1>
    <p style="text-align:center;">
        As ROOT user, you may accept and deny user registration requests.<br />
        Below is the queue of all active registration requests.
    </p>

    <div id="user_list_div" style="width: 500px; margin: auto; padding: 10px;">
        <asp:ListView ID="user_list"  
            ItemType="SARST_DEV.Model.RegistrationRequest" 
            runat="server"
            SelectMethod="GetRegistrationRequestQueue">
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
                            <td><%#: Item.user_type %></td>
                        </tr>
                        <tr>
                            <td style="padding-top: 10px;">
                                <asp:Button runat="server" Width="80px" style="background-color: #88ff88; border-color: #228822; border-radius: 3px; color: black;"
                                Text="Approve" 
                                OnClick="ApproveButton_Click"
                                CommandArgument="<%#: Item.username %>"/>
                            </td>
                            <td style="padding-top: 10px;">
                            <asp:Button runat="server" Width="80px" style="background-color: #ff8888; border-color: #882222; border-radius: 3px; color: black;"
                                Text="Deny" 
                                OnClick="DenyButton_Click"
                                CommandArgument="<%#: Item.username %>"/>
                            </td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

</asp:Content>
