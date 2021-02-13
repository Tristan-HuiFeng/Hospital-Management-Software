<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site_No_Footer.Master" AutoEventWireup="true" CodeBehind="MasterControl.aspx.cs" Inherits="Hospital_Management_Software.MasterControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top:80px">

   
    <h2> MASTER CONTROL </h2>
    <hr />
    <p> Delete data, insert dummy data etc</p>

    <div class="my-5">
        <asp:Label ID="lb_message" CssClass="alert alert-primary" runat="server" Text="Message to be displayed here"></asp:Label>
    </div>

        <div class="my-5">
        <asp:Label ID="lb_debugger" runat="server" Text="Debug message to be displayed here"></asp:Label>
    </div>

    <div class="mt-3">
        <asp:Button ID="btn_addAdminUser" class="btn btn-primary" runat="server" Text="Add Admin" OnClick="btn_addAdminUser_Click"  />
    </div>

     <div class="mt-3">
        <asp:Button ID="btn_addDoctorUser" class="btn btn-primary" runat="server" Text="Add Doctor" OnClick="btn_addDoctorUser_Click" />
    </div>
     </div>


</asp:Content>
