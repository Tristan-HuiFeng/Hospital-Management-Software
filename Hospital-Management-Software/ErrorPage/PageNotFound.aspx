<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site_No_Footer.Master" AutoEventWireup="true" CodeBehind="PageNotFound.aspx.cs" Inherits="Hospital_Management_Software.ErrorPage.PageNotFound" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top:60px">
        <h1> Oops. Something went wrong. ERROR 404</h1>
        <hr />
        <p> Page not found </p>
        <a runat="server" href="~/Login/StaffLogin"> return to login / account page</a>
    </div>


</asp:Content>
