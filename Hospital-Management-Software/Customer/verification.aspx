<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Customer.Master" AutoEventWireup="true" CodeBehind="verification.aspx.cs" Inherits="Hospital_Management_Software.Customer.verification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr><td style="text-align:center">Please enter the verification code sent to your phone!</td></tr>
        <tr>
            <td style="text-align:center"><asp:Label ID="Label1" runat="server" Text="Verification code: "></asp:Label><asp:TextBox ID="TextBox1" runat="server" hint="XXXX"></asp:TextBox></td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td style="text-align:center"><asp:Button ID="btnSubmit" class="btnSubmit" runat="server" Text="Submit" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" /></td>
        </tr>
    </table>

    <style>
   .btnSubmit {
        background-color: orangered;
        color: white;
        text-align: center;
        display: inline-block;
        font-size: 16px;
    }
    </style>

</asp:Content>