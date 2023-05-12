<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SARST_DEV._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Salvation Army <br /> Resident Services Tracker</h1>
    <p class="lead">
        SARST provides Salvation Army shelters with a robust system for tracking and managing shelter services. 
        <br /> 
        If you are a Salvation Army administrator or service provider, please sign in or register to begin.
    </p>
    <p>
        <a href="Login" class="btn btn-primary btn-lg">Sign in &raquo;</a>
        <a href="Registration" class="btn btn-primary btn-lg" style="margin-left: 20px;">Register &raquo;</a>
    </p>

    <div style="display:none;">
        <asp:Button Text="InitDB" runat="server" OnCLick="InitDB" />
    </div>

</asp:Content>
