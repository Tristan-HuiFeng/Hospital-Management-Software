<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="CreateMAR.aspx.cs" Inherits="Hospital_Management_Software.Views.CreateMAR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="width: 159px">Appointment Date:</td>
            <td>
                <asp:TextBox ID="tb_apmtDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 29px; width: 159px">Appointment Time:</td>
            <td style="height: 29px">
                <asp:TextBox ID="tb_apmtTime" runat="server" TextMode="Time"></asp:TextBox>
            </td>
            <td style="height: 29px"></td>
        </tr>
        <tr>
            <td style="width: 159px">NRIC:</td>
            <td>
                <asp:TextBox ID="tb_NRIC" runat="server" MaxLength="9"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 159px">EPR number:</td>
            <td>
                <asp:TextBox ID="tb_EPR" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 159px">Comment:</td>
            <td>
                <asp:TextBox ID="tb_Comment" runat="server" TextMode="MultiLine" Width="270px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 159px">&nbsp;</td>
            <td>
                <asp:Button ID="btn_Create" runat="server" Text="Create" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
