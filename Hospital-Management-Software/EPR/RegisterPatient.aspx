<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="RegisterPatient.aspx.cs" Inherits="Hospital_Management_Software.Views.RegisterPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h1>Patient Registration</h1>
    <p>
        Please fill in the required fields below. For any field that is non-applicable please put NIL.
    </p>
    <table style="width: 100%;" class="table">
        <tr>
            <td scope="row" class="auto-style2">First name:</td>
            <td style="width: 198px">
                <asp:TextBox ID="tb_FirstName" runat="server"></asp:TextBox>
                <br />
            </td>
            <td class="auto-style1">Last name:</td>
            <td style="width: 493px">
                <asp:TextBox ID="tb_LastName" runat="server"></asp:TextBox>
                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">NRIC:</td>
            <td style="width: 198px">
                <asp:TextBox ID="tb_NRIC" runat="server" CssClass="mt-0" ></asp:TextBox>
                <br />
            </td>
            <td class="auto-style1">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Date of Birth:</td>
            <td style="width: 198px">
                <asp:TextBox ID="tb_DOB" runat="server" TextMode="Date" ></asp:TextBox>
            </td>
            <td class="auto-style1">Age:</td>
            <td style="width: 493px">
                <asp:TextBox ID="tb_age" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Sex:</td>
            <td style="width: 198px">
                <asp:RadioButtonList ID="rad_Sex" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="auto-style1">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Nationality:</td>
            <td style="width: 198px">
                <asp:DropDownList ID="ddl_nationality" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style1">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Citizenship:</td>
            <td style="width: 198px">
                <asp:DropDownList ID="ddl_citizenship" runat="server">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem Value="Sg">Singaporean</asp:ListItem>
                    <asp:ListItem Value="sg-pr">Singapore-PR</asp:ListItem>
                    <asp:ListItem Value="other">Others</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style1">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Postal Code:</td>
            <td style="width: 198px">
                <asp:TextBox ID="tb_PostalCode" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style1">Address:</td>
            <td style="width: 493px">
                <asp:TextBox ID="tb_Address" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Allergies:</td>
            <td style="width: 198px">
                <asp:TextBox ID="tb_Allergies" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style1">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Medical conditions:</td>
            <td style="width: 198px">
                <asp:TextBox ID="tb_MedicalConditon" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style1">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Phone number:</td>
            <td style="width: 198px">
                <asp:TextBox ID="tb_phoneNumber" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style1">Home number</td>
            <td style="width: 493px">
                <asp:TextBox ID="tb_homeNumber" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Email:</td>
            <td style="width: 198px">
                <asp:TextBox ID="tb_email" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style1">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td style="width: 198px">
                <asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click" />
            </td>
            <td class="auto-style1">&nbsp;</td>
            <td style="width: 493px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 262px;
        }
        .auto-style2 {
            width: 320px;
        }
    </style>
</asp:Content>

