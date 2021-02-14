<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Administrator.Master" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="Hospital_Management_Software.Administrator.SendEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top: 60px">
        <h3>Sending Email</h3>
        <hr />

        <div class="mt-5 my-5">
            <asp:Label ID="lb_message" CssClass="alert alert-primary" runat="server" Text="Message to be displayed here"></asp:Label>
        </div>

        <div class="mt-5 my-5">
            <asp:Label ID="lb_debugger" Style="background-color: #f8d7da" runat="server" Text="Message to be displayed here"></asp:Label>
        </div>


        <div class="form-group">
            <label for="exampleFormControlSelect1">Select Email Target:</label>
            <asp:DropDownList class="form-control" ID="ddl_emailTarget" runat="server">
                <asp:ListItem Value="0">Hospital&#39;s Employee</asp:ListItem>
                <asp:ListItem Value="1">Patients of Hospital</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="row">
            <div class="col form-group">
                <asp:Label ID="lb_emailSubject" runat="server" Text="Email Subject:"></asp:Label>
                <asp:TextBox ID="tb_emailSubject" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="text-danger" ID="tfv_subject" runat="server" ErrorMessage="Subject must not be empty" ControlToValidate="tb_emailSubject" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>


        <div class="row">
            <div class="col form-group">
                <asp:Label ID="lb_emailBody" runat="server" Text="Email Body:"></asp:Label>
                <asp:TextBox ID="tb_emailBody" class="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="text-danger" ID="rfv_emailBody" runat="server" ErrorMessage="Body must not be empty" ControlToValidate="tb_emailBody" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <asp:Button ID="btn_sendEmail" class="btn btn-primary" runat="server" Text="Send Email" OnClick="btn_sendEmail_Click"/>

    </div>

</asp:Content>

