<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Administrator.Master" AutoEventWireup="true" CodeBehind="UserAccountInformation.aspx.cs" Inherits="Hospital_Management_Software.Administrator.UserAccountInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 60px">


        <h3>User Account Information</h3>
        <hr />
        <div>
            <asp:Label ID="lb_message" CssClass="alert alert-primary" runat="server" Text="Message to be displayed here"></asp:Label>
        </div>

        <div>
            <asp:Label ID="lb_debugger" Style="background-color: #f8d7da" runat="server" Text="Message to be displayed here"></asp:Label>
        </div>


        <div class="container" style="margin-bottom: 40px">

            <div class="mt-2 my-2 row">
                <asp:Label class="record-label col-3" style="margin-top:auto;margin-bottom:auto;" ID="Label1" runat="server" Text="Change Role:"></asp:Label>
                <div class="col-6">
                    <asp:DropDownList ID="ddl_roleList" CssClass="mr-3 form-control" runat="server"></asp:DropDownList>
                   
                </div>
                <div class="col-3">
                      <asp:Button ID="btn_changeRole" CssClass="btn btn-primary" runat="server" Text="Change Role" OnClick="btn_changeRole_Click" />
                </div>

            </div>

            <div class="mt-2 my-2 row">
                <asp:Label CssClass="record-label col-3" style="margin-top:auto;margin-bottom:auto;" ID="Label12" runat="server" Text="Account Status:&nbsp"></asp:Label>
                <div class="col-6">
                    <asp:Label ID="lb_status" runat="server" style="margin:auto;" Text="{}"></asp:Label>
                   
                </div>
                <div class="col-3">
                     <asp:Button ID="btn_toggleStatus" CssClass="btn btn-primary" runat="server" Text="" CausesValidation="False" OnClick="btn_toggleStatus_Click" />
                </div>
            </div>


            <div class="row mt-5">
                <h6>Role Information</h6>
            </div>
            <hr />
            <div class="row my-3">
                <asp:Label CssClass="record-label" ID="Label2" runat="server" Text="Role ID:&nbsp"></asp:Label>
                <asp:Label ID="lb_roleID" runat="server" Text=""></asp:Label>
            </div>

            <div class="row my-3">
                <asp:Label CssClass="record-label" ID="Label3" runat="server" Text="Role Name:&nbsp"></asp:Label>
                <asp:Label ID="lb_roleName" runat="server" Text=""></asp:Label>
            </div>

            <div class="row mt-5">
                <h6>User Information</h6>
            </div>
            <hr />

            <div class="row my-3">
                <asp:Label CssClass="record-label" ID="Label4" runat="server" Text="Account ID:&nbsp"></asp:Label>
                <asp:Label ID="lb_userID" runat="server" Text=""></asp:Label>
            </div>

            <div class="row mt-5">
                <h6>Employee Details</h6>
            </div>
            <hr />
            <div class="row my-3">
                <asp:Label CssClass="record-label" ID="Label10" runat="server" Text="Employee's Name:&nbsp"></asp:Label>
                <asp:Label ID="lb_userName" runat="server" Text=""></asp:Label>
            </div>

            <div class="row my-3">
                <asp:Label CssClass="record-label" ID="Label6" runat="server" Text="Position:&nbsp"></asp:Label>
                <asp:Label ID="lb_position" runat="server" Text=""></asp:Label>
            </div>

            <div class="row my-3">
                <asp:Label CssClass="record-label" ID="Label8" runat="server" Text="Department:&nbsp"></asp:Label>
                <asp:Label ID="lb_department" runat="server" Text=""></asp:Label>
            </div>

            <hr />
            <div class="row d-flex flex-row bd-highlight mb-3">
                <div class="form-group p-2 bd-highlight">
                    <asp:Label ID="lb_password" runat="server" Text="New Password:"></asp:Label>
                    <asp:TextBox ID="tb_password" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                </div>

                <div class="form-group p-2 bd-highlight align-self-end">
                    <asp:Button ID="btn_changePassword" class="btn btn-primary" runat="server" Text="Change Password" OnClick="btn_changePassword_Click" />
                </div>
                <div class="form-group p-2 bd-highlight align-self-end">
                    <asp:Label ID="lb_passwordResult" runat="server" Text="Label"></asp:Label>
                </div>

            </div>





        </div>
</asp:Content>
