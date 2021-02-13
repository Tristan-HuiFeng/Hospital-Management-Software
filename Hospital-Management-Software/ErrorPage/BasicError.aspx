<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site_No_Footer.Master" AutoEventWireup="true" CodeBehind="BasicError.aspx.cs" Inherits="Hospital_Management_Software.ErrorPage.BasicError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top:60px">
        <h1> Oops. Something went wrong. </h1>
        <hr />
        <p> We will work on this soon!</p>
        <a runat="server" href="~/Login/StaffLogin"> return to login / account page</a>
    </div>

</asp:Content>
