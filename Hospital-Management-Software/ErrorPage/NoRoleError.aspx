<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site_No_Footer.Master" AutoEventWireup="true" CodeBehind="NoRoleError.aspx.cs" Inherits="Hospital_Management_Software.ErrorPage.BasicError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top:60px">
        <h1> Oops. Something went wrong. </h1>
        <hr />
        <p> We will work on this soon!</p>
        <div>
            <asp:Label ID="lb_debugger" Style="background-color:#f8d7da;padding:5px;" runat="server" Text="No roles assigned or role have no permission to access any resource"></asp:Label>
        </div>

        <a runat="server" href="~/Login/Logout"> return to login / account page to change account</a>
    </div>

</asp:Content>
