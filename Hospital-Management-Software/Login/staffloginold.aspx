<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="staffloginold.aspx.cs" Inherits="Hospital_Management_Software.Login.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    Staff Login<br />

    <table style="width:100%;">
        <tr>
            <td style="width: 143px">Login ID:</td>
            <td style="width: 375px">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td>Error control</td>
        </tr>
        <tr>
            <td style="width: 143px">Password: </td>
            <td style="width: 375px">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td>Error control</td>
        </tr>
        <tr>
            <td style="width: 143px">&nbsp;</td>
            <td style="width: 375px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 143px">&nbsp;</td>
            <td style="width: 375px">
                <asp:Button ID="Button1" runat="server" Text="Button" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table> 

    <br />
    
</asp:Content>
