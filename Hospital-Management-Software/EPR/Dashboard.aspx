<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Hospital_Management_Software.Views.EPR.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GV_patients" runat="server" AutoGenerateColumns="False">
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
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
