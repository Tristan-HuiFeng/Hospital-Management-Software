<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Administrator.Master" AutoEventWireup="true" CodeBehind="UserRoleList.aspx.cs" Inherits="Hospital_Management_Software.Administrator.RoleList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <div class="container" style="margin-top:60px">


        <h3>Role List</h3>
        <hr />
        <div>
            <asp:Label ID="lb_message" CssClass="alert alert-primary" runat="server" Text="Message to be displayed here"></asp:Label>
        </div>

        <div>
            <asp:Label ID="lb_debugger" style="background-color:#f8d7da" runat="server" Text="Message to be displayed here"></asp:Label>
        </div>

        <div class="mt-2 my-2">
            <asp:Label class="" ID="lb_common2" runat="server" Text="Role Id:"></asp:Label>
            <div class="form-inline">
                <asp:Label class="" ID="lb_role_id" runat="server" Text=""></asp:Label>
            </div>
            
        </div>
        <asp:GridView ID="gv_roleUserList" class="table myGrid" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_roleUserList_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField DataField="role_name" HeaderText="Role Name" ReadOnly="True" />
                <asp:BoundField DataField="user_id" HeaderText="User ID" ReadOnly="True" />
                <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" />
                <asp:BoundField DataField="department" HeaderText="Department" ReadOnly="True" />
                
                <asp:CommandField AccessibleHeaderText="View_User" CausesValidation="False" HeaderText="View User" SelectText="View User" ShowSelectButton="True">
                </asp:CommandField>
            </Columns>
        </asp:GridView>


         <!--<asp:BoundField DataField="num_user" HeaderText="Number of Users" ReadOnly="True" />
             <asp:BoundField DataField="status" HeaderText="Status" />-->
    </div>


</asp:Content>
