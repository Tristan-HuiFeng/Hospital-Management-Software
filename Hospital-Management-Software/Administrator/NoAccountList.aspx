<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Administrator.Master" AutoEventWireup="true" CodeBehind="NoAccountList.aspx.cs" Inherits="Hospital_Management_Software.Administrator.CreateAcount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top: 60px">
        <h3>Users without account</h3>
        <hr />

         <div class="mt-3 mb-3">
            <asp:Label ID="lb_message" CssClass="alert alert-primary" runat="server" Text="Message to be displayed here"></asp:Label>
        </div>

        <div class="mt-3 mb-3">
            <asp:Label ID="lb_debugger" style="background-color:#f8d7da" runat="server" Text="Message to be displayed here"></asp:Label>
        </div>

        
        <asp:GridView ID="gv_userNoAccList" class="table myGrid" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_userNoAccList_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" />
                <asp:BoundField DataField="employee_id" HeaderText="Employee ID" ReadOnly="True" />
                <asp:BoundField DataField="department" HeaderText="Department" ReadOnly="True" />
                <asp:BoundField DataField="email" HeaderText="Email" ReadOnly="True" />
                
                <asp:CommandField AccessibleHeaderText="Create_Account" CausesValidation="False" HeaderText="Create Account" SelectText="Create Account" ShowSelectButton="True">
                </asp:CommandField>
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>
