<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Customer.Master" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="Hospital_Management_Software.Customer.feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://www.google.com/recaptcha/api.js?render=6LceN0caAAAAAKawSUyFpUmoiBf5IVYpDTrA7A8B"></script>
    <asp:Label class="header" runat="server" Text="Feedback Form"></asp:Label>
    <hr />
    <asp:Label class="subheader" runat="server" Text="All fields marked with * are required."></asp:Label>
    <br />
    <br />
    <div>
        <asp:Label class="Label1" runat="server" Text="Subject *"></asp:Label>
        <asp:TextBox ID="tbSubject" runat="server" style="float:right" Width="282px"></asp:TextBox>
    </div>
    <br />
    <div>
        <asp:Label class="Label1" runat="server" Text="Please write your feedback and suggestions here *"></asp:Label>
        <asp:TextBox ID="tbFeedback" runat="server" CssClass="auto-style1" Height="100px" TextMode="MultiLine" Width="282px"></asp:TextBox>
    </div>
    <br />
    <br />
    <br />
    <hr />
    <asp:Label class="subheader" runat="server" Text="Please provide your particulars."></asp:Label>
    <br />
    <div>
        <asp:Label class="Label1" runat="server" Text="Name"></asp:Label>
        <%--<input id="Text1" type="text" style="float:right"/>--%>
        <asp:TextBox ID="tbName" runat="server" style="float:right" Width="282px"></asp:TextBox>
    </div>
    <br />
    <div>
        <asp:Label class="Label1" runat="server" Text="Email *"></asp:Label>
        <%--<input id="Text1" type="text" style="float:right"/>--%>
        <asp:TextBox ID="tbEmail" runat="server" style="float:right" Width="282px"></asp:TextBox>
    </div>
    <br />
    <div style="text-align:center"><asp:CheckBox ID="chkPublic" style="text-align:center" runat="server" Text= "&nbsp;I agree to the terms and conditions of Lee's General Hospital."/></div>
    <div style="text-align:center">
        <asp:Label ID="errorMsg" runat="server" Text="Label" Visible="False" ></asp:Label>
    </div>
    <br />
    <div style="text-align:center">
        <asp:Button class="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_click" />
        <asp:Button ID="Cancel" runat="server" Text="Cancel" />
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
        <script>
        grecaptcha.ready(function () {
            grecaptcha.execute('6LceN0caAAAAAKawSUyFpUmoiBf5IVYpDTrA7A8B', { action: 'Login' }).then(function (token) {
                document.getElementById("g-recaptcha-response").value = token;
            });
        });
        </script>
    <style type="text/css">
        .auto-style1 {
            float: right;
            margin-left: 191;
        }
    </style>
</asp:Content>