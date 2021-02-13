<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Administrator.Master" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="Hospital_Management_Software.Administrator.Role" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top:60px">


        <h3>Role Management</h3>
        <hr />
        <div>
            <asp:Label ID="lb_message" CssClass="alert alert-primary" runat="server" Text="Message to be displayed here"></asp:Label>
        </div>

        <div>
            <asp:Label ID="lb_debugger" style="background-color:#f8d7da" runat="server" Text="Message to be displayed here"></asp:Label>
        </div>
        
        

        <div class="mt-5 my-5">
            <asp:Label class="" ID="lb_newRoleName" runat="server" Text="New Role Name:"></asp:Label>
            <div class="form-inline">
                <asp:TextBox ID="tb_newRoleName" class="form-control mr-2" runat="server"></asp:TextBox>
                <asp:Button ID="btn_createRole" runat="server" class="btn btn-primary" Text="Create Role" OnClick="btn_createRole_Click" />
            </div>
            <asp:RequiredFieldValidator style="color:#f71126;" ID="rfv_createRole" runat="server" ErrorMessage="New role's name cannot be empty" ControlToValidate="tb_newRoleName"></asp:RequiredFieldValidator>
            
        </div>

        <asp:GridView ID="gv_role" class="table myGrid" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_role_SelectedIndexChanged" OnRowCommand="CustomersGridView_RowCommand" >
            <Columns>
                <asp:BoundField DataField="role_name" HeaderText="Role Name" ReadOnly="True" />
                <asp:BoundField DataField="role_id" HeaderText="Role ID" ReadOnly="True" />
                <asp:ButtonField Text="Delete Role" HeaderText="Delete" CommandName="DeleteRole" AccessibleHeaderText="Delete_Role">
                <ItemStyle ForeColor="Red" />
                </asp:ButtonField>
                <asp:CommandField AccessibleHeaderText="Manage_Role"  ShowSelectButton="True" HeaderText="Manage Role" SelectText="Manage Role" CausesValidation="False" />
            </Columns>
        </asp:GridView>


         <!--<asp:BoundField DataField="status" HeaderText="Status" />
                <asp:ButtonField Text="Enable/Disable" HeaderText="Toggle Role Status" CommandName="ToggleRole" AccessibleHeaderText="Toggle_Role_Status"/>-->
    </div>
</asp:Content>
