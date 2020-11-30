<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="UpdateMAR.aspx.cs" Inherits="Hospital_Management_Software.Views.UpdateMAR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;" class="table">
        <tr>
            <td style="width: 159px">Appointment Date:</td>
            <td style="width: 305px">
                <asp:TextBox ID="tb_apmtDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 29px; width: 159px">Appointment Time:</td>
            <td style="height: 29px; width: 305px;">
                <asp:TextBox ID="tb_apmtTime" runat="server" TextMode="Time"></asp:TextBox>
            </td>
            <td style="height: 29px"></td>
        </tr>
        <tr>
            <td style="width: 159px">NRIC:</td>
            <td style="width: 305px">
                <asp:TextBox ID="tb_NRIC" runat="server" MaxLength="9"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 159px">EPR number:</td>
            <td style="width: 305px">
                <asp:TextBox ID="tb_EPR" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 159px">Comment:</td>
            <td style="width: 305px">
                <asp:TextBox ID="tb_Comment" runat="server" TextMode="MultiLine" Width="270px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 159px">&nbsp;</td>
            <td style="width: 305px">
                <asp:Button ID="btn_Update" runat="server" Text="Update" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
