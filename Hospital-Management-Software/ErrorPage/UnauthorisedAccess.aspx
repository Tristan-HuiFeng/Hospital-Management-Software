<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site_No_Footer.Master" AutoEventWireup="true" CodeBehind="UnauthorisedAccess.aspx.cs" Inherits="Hospital_Management_Software.ErrorPage.UnauthorisedAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top:60px">
        <h1> Oops. Something went wrong. ERROR 403</h1>
        <hr />
        <p> Forbidden. You do not have access </p>
        <a runat="server" href="~/Login/StaffLogin"> return to login / account page</a>
    </div>

</asp:Content>
