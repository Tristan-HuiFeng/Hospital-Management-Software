<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Hospital_Management_Software.Views.EPR.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lb_genMsg" runat="server" Visible="False"></asp:Label>
    <br />
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lb_searchPatient" runat="server" Text="Search Patient by ID"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btn_searchPatient" runat="server" Text="Search" Width="68px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:CheckBox ID="cb_disabeVisible" runat="server" OnCheckedChanged="cb_disabeVisible_CheckedChanged" Text="Show disabled records" />
            </td>
            <td class="auto-style2">&nbsp;</td>
            <td>
    <asp:Button ID="btn_RegisterPatient" runat="server" OnClick="btn_RegisterPatient_Click" Text="Register Patient" />
            </td>
        </tr>
    </table>
    <br />
    <br />
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

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 180px;
        }
        .auto-style2 {
            width: 260px;
        }
    </style>
</asp:Content>
