<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Administrator.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="Hospital_Management_Software.Administrator.CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top: 60px">
        <h3>Create Account</h3>
        <hr />

        <div>
            <asp:Label ID="lb_message" CssClass="alert alert-primary" runat="server" Text="Message to be displayed here"></asp:Label>
        </div>

        <div>
            <asp:Label ID="lb_debugger" Style="background-color: #f8d7da" runat="server" Text="Message to be displayed here"></asp:Label>
        </div>

        <div class="row mt-5">
            <h6>User Information</h6>
        </div>
        <hr />
        <div class="row my-3">
            <asp:Label CssClass="record-label" ID="Label2" runat="server" Text="Name:&nbsp"></asp:Label>
            <asp:Label ID="lb_name" runat="server" Text=""></asp:Label>
        </div>

        <div class="row my-3">
            <asp:Label CssClass="record-label" ID="Label3" runat="server" Text="Department:&nbsp"></asp:Label>
            <asp:Label ID="lb_department" runat="server" Text=""></asp:Label>
        </div>

        <div class="row my-3">
            <asp:Label CssClass="record-label" ID="Label1" runat="server" Text="Employee ID:&nbsp"></asp:Label>
            <asp:Label ID="lb_empId" runat="server" Text=""></asp:Label>
        </div>

        <div class="row my-3">
            <asp:Label CssClass="record-label" ID="Label5" runat="server" Text="Email:&nbsp"></asp:Label>
            <asp:Label ID="lb_email" runat="server" Text=""></asp:Label>
        </div>


        <hr />


        <div class="mt-2 my-2 row">
            <asp:Label class="record-label align-middle" ID="Label4" runat="server" Text="Select Role:"></asp:Label>
            <div class="ml-3">
                <asp:DropDownList ID="ddl_roleList" Style="margin-top: auto; margin-bottom: auto;" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>

        </div>

        <div class="row">
            <div class="col form-group">
                <asp:Label ID="lb_username" runat="server" Text="Username:"></asp:Label>
                <asp:TextBox ID="tb_username" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="text-danger" ID="rfv_username" runat="server" ErrorMessage="Username must not be empty" ControlToValidate="tb_username" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col form-group">
                <asp:Label ID="lb_password" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="tb_password" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="text-danger" ID="rfv_password" runat="server" ErrorMessage="Password must not be empty" ControlToValidate="tb_password" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <asp:Button ID="btn_createAccount" class="btn btn-primary" runat="server" Text="Create Account" OnClick="btn_createAccount_Click" />
    </div>

</asp:Content>
