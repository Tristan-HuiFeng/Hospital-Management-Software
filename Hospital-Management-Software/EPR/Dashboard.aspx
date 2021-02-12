<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Hospital_Management_Software.Views.EPR.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lb_genMsg" runat="server" Visible="False"></asp:Label>
    <br />
    <asp:Button ID="btn_RegisterPatient" runat="server" OnClick="btn_RegisterPatient_Click" Text="Register Patient" />
    <asp:GridView ID="GV_patients" runat="server" AutoGenerateColumns="False" OnRowCommand="GV_patients_RowCommand">
        <Columns>
            <asp:BoundField DataField="patientID" HeaderText="Patient ID" />
            <asp:BoundField DataField="firstName" HeaderText="First Name" />
            <asp:BoundField DataField="lastName" HeaderText="Last Name" />
            <asp:BoundField DataField="NRIC" HeaderText="NRIC" />
            <asp:BoundField DataField="phoneNumber" HeaderText="Phone Number" />
            <asp:BoundField DataField="homeNumber" HeaderText="Home Number" />
            <asp:BoundField DataField="email" HeaderText="Email" />
            <asp:BoundField DataField="address" HeaderText="Address" />
            <asp:BoundField DataField="postalCode" HeaderText="Postal Code" />
            <asp:ButtonField ButtonType="Button" Text="Disable" CommandName="Disable" />
            <asp:ButtonField ButtonType="Button" CommandName="EditRecord" Text="Edit" />
        </Columns>
    </asp:GridView>
</asp:Content>

