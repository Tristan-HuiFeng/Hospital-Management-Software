<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Customer.Master" AutoEventWireup="true" CodeBehind="makeAppointment.aspx.cs" Inherits="Hospital_Management_Software.Customer.makeAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:center"><asp:Label ID="Label3" runat="server" Text="Make an appointment! If you would like to cancel your appointment, choose Cancel under reason."></asp:Label></div>
    <br />
    <table style="width: 100%; text-align:center">
        <tr>
            <td class="auto-style1"><asp:Label ID="Label1" runat="server" Text="Reason: "></asp:Label></td>
            <td><asp:DropDownList ID="DDL_reason" runat="server">
                <asp:ListItem Selected="True" Value="Please select a reason!"></asp:ListItem>
                <asp:ListItem Value="General Visit"></asp:ListItem>
                <asp:ListItem Value="Specialist visit"></asp:ListItem>
                <asp:ListItem Value="Medication Collection"></asp:ListItem>
                <asp:ListItem Value="Others"></asp:ListItem>
                <asp:ListItem Value="CANCELLED"></asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr><td class="auto-style1">&nbsp;</td></tr>
        <tr>
            <td class="auto-style1"><asp:Label ID="Label2" runat="server" Text="Select a time: "></asp:Label></td>
            <td><asp:DropDownList ID="DDL_time" runat="server">
                <asp:ListItem Selected="True" Value="0">Please select a time!</asp:ListItem>
                <asp:ListItem Value="12:00 PM"></asp:ListItem>
                <asp:ListItem Value="12:30 PM"></asp:ListItem>
                <asp:ListItem Value="1:00 PM"></asp:ListItem>
                <asp:ListItem Value="1:30 PM"></asp:ListItem>
                <asp:ListItem Value="2:00 PM"></asp:ListItem>
                <asp:ListItem Value="2:30 PM"></asp:ListItem>
                <asp:ListItem Value="3:00 PM"></asp:ListItem>
                <asp:ListItem Value="3:30 PM"></asp:ListItem>
                <asp:ListItem Value="4:00 PM"></asp:ListItem>
                <asp:ListItem Value="4:30 PM"></asp:ListItem>
                <asp:ListItem Value="5:00 PM"></asp:ListItem>
                <asp:ListItem Value="5:30 PM"></asp:ListItem>
                </asp:DropDownList></td>
        </tr>
    </table>
    <div style="text-align:center"><asp:Label runat="server" Text="Please select a reason and time!" Visible="false" id="lblError"></asp:Label></div>
    <div style="text-align:center">
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="btnSubmit"/>
        <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="btnCancel"/>
    </div>
</asp:Content>