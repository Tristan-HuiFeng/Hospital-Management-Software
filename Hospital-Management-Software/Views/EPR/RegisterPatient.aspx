<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="RegisterPatient.aspx.cs" Inherits="Hospital_Management_Software.Views.RegisterPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;" class="table">
        <tr>
            <td scope="row" style="width: 185px">Name:</td>
            <td style="width: 198px">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator hidden="true" ID="RequiredFieldValidator1" controltovalidate="TextBox1" runat="server" ErrorMessage="Name is required!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td style="width: 44px">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 185px">NRIC:</td>
            <td style="width: 198px">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="mt-0"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator hidden="true" ID="RequiredFieldValidator2" controltovalidate="TextBox2" runat="server" ErrorMessage="NRIC is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator hidden="true" ID="RegularExpressionValidator1" controltovalidate="TextBox2" runat="server" ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator>
            </td>
            <td style="width: 44px">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 185px">Date of Birth:</td>
            <td style="width: 198px">
                <asp:TextBox ID="tb_DOB" runat="server" TextMode="Date" ></asp:TextBox>
            </td>
            <td style="width: 44px">Age:</td>
            <td style="width: 493px">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 185px">Sex:</td>
            <td style="width: 198px">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td style="width: 44px">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 185px">Nationality:</td>
            <td style="width: 198px">
                <asp:DropDownList ID="ddl_nationality" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 44px">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 185px">Citizenship:</td>
            <td style="width: 198px">
                <asp:DropDownList ID="ddl_nationality0" runat="server">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem Value="Sg">Singaporean</asp:ListItem>
                    <asp:ListItem Value="sg-pr">Singapore-PR</asp:ListItem>
                    <asp:ListItem Value="other">Others</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 44px">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 185px">Postal Code:</td>
            <td style="width: 198px">
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
            <td style="width: 44px">Address:</td>
            <td style="width: 493px">
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 185px">Allergies:</td>
            <td style="width: 198px">
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            </td>
            <td style="width: 44px">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 185px">Medical conditions:</td>
            <td style="width: 198px">
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            </td>
            <td style="width: 44px">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 185px">&nbsp;</td>
            <td style="width: 198px">
                <asp:Button ID="Button1" runat="server" Text="Submit" />
            </td>
            <td style="width: 44px">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
