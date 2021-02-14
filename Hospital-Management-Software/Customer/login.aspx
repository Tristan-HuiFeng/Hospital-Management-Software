<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Customer.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Hospital_Management_Software.Customer.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://www.google.com/recaptcha/api.js?render=6LceN0caAAAAAKawSUyFpUmoiBf5IVYpDTrA7A8B"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; text-align:center">
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="NRIC:  " hint="S*******X" ></asp:Label>
        <asp:TextBox ID="tb_nric" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Date of birth:  " hint="DD/MM/YYYY"></asp:Label>
        <asp:TextBox ID="tb_dob" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td><asp:Label ID="lblVerification" runat="server" Text="Please ensure all fields on this page are correct and / or agree to the terms and conditions!" Visible="false"></asp:Label></td></tr>
        <tr><td><asp:Label ID="lbllbl" runat="server" Text="Please ensure all fields on this page are correct and / or agree to the terms and conditions!" Visible="false"></asp:Label></td></tr>
        <tr>
            <td><asp:CheckBox ID="chkPublic" runat="server" Text= "&nbsp;I agree to the terms and conditions of Lee's General Hospital."/></td>
        </tr>
        <tr>
            <td><asp:Button ID="btnSubmit" class="btnSubmit" runat="server" Text="Submit" onclick="btn_Submit"/>
            <asp:Button ID="btnCancel" class="btnCancel" runat="server" Text="Cancel" /></td>
        </tr>
    </table>

    <script>
        grecaptcha.ready(function () {
            grecaptcha.execute('6LceN0caAAAAAKawSUyFpUmoiBf5IVYpDTrA7A8B', { action: 'Login' }).then(function (token) {
                document.getElementById("g-recaptcha-response").value = token;
            });
        });
    </script>
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