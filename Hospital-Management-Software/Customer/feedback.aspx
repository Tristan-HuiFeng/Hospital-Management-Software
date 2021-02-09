<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Customer.Master" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="Hospital_Management_Software.Customer.feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label class="header" runat="server" Text="Feedback Form"></asp:Label>
    <hr />
    <asp:Label class="subheader" runat="server" Text="All fields marked with * are required."></asp:Label>
    <br />
    <br />
    <div>
        <asp:Label class="Label1" runat="server" Text="Subject *"></asp:Label>
        <asp:TextBox ID="tbSubject" runat="server" style="float:right" Width="282px"></asp:TextBox>
    </div>
    <asp:Label ID="errorSubj" runat="server" Text="Label" Visible="false"></asp:Label>
    <br />
    <br />
    <div>
        <asp:Label class="Label1" runat="server" Text="Please write your feedback and suggestions here *"></asp:Label>
        <asp:TextBox ID="tbFeedback" runat="server" CssClass="auto-style1" Height="100px" TextMode="MultiLine" Width="282px"></asp:TextBox>
    </div>
    <asp:Label ID="errorFeedback" runat="server" Text="Label" Visible="false"></asp:Label>
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
    <asp:Label ID="errorEmail" runat="server" Text="Label" Visible="false"></asp:Label>
    <br />
<%--    <div>
        <asp:Label class="Label1" runat="server" Text="Were you the patient? *"></asp:Label>
        <asp:RadioButton ID="RadioButton1" runat="server" style="float:right" Text="No"/>
        <asp:RadioButton ID="RadioButton2" runat="server" style="float:right" Text="Yes"/>
    </div>--%>
<%--    <br />
    <div>
        <asp:Label class="Label1" runat="server" Text="Would you like us to contact you? *"></asp:Label>
        <asp:RadioButton ID="RadioButton3" runat="server" style="float:right" Text="No"/>
        <asp:RadioButton ID="RadioButton4" runat="server" style="float:right" Text="Yes"/>
    </div>--%>
    <img alt="" src="src/img/captcha.png" class="captcha"/>
    <br />
    <div style="text-align:center">    
        <asp:Label class="fdbkconfirm" runat="server" Text="​​By clicking on submit, you agree to our Terms and Conditions."></asp:Label>
    </div>
    <br />
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
    <style type="text/css">
        .auto-style1 {
            float: right;
            margin-left: 191;
        }
    </style>
</asp:Content>