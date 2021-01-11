<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="Hospital_Management_Software.Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../src/css/HRStyleSheet.css" rel="stylesheet" />
    <script src="https://use.fontawesome.com/0ff67f73a3.js"></script>

    <div class="card shadow-sm p-3 mb-5 bg-white rounded" style="width: 40%;">
        <div class="card-body">
            <div class="input-group">
                <asp:TextBox CssClass="bg-light border-0 small form-control" placeholder="Search for ..." ID="TextBox1" runat="server"></asp:TextBox>
                <div class="input-group-append">
                    <asp:HyperLink CssClass="btn btn-primary" ID="HyperLink1" runat="server"><i class="fa fa-search" aria-hidden="true"></i></asp:HyperLink>
                </div>
            </div>
            <br />
            <p class="card-text">
                <asp:DropDownList CssClass="btn btn-primary" ID="DropDownList1" runat="server">
                    <asp:ListItem Selected="True" hidden="true">+2 Filters</asp:ListItem>
                    <asp:ListItem>Gender</asp:ListItem>
                    <asp:ListItem>DOB</asp:ListItem>
                </asp:DropDownList>
            </p>
            <asp:Button CssClass="btn btn-info btn-sm" ID="Button1" runat="server" Text="+New Record" />

        </div>
    </div>
    <br />
    <div class="shadow rounded-corners">
        <asp:GridView AutoGenerateColumns="False" runat="server" ID="GridView1" HorizontalAlign="Center" CssClass="Grid table table-condensed table-hover" AllowPaging="True" PageSize="5">
            <Columns>
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="First Name" HeaderText="First Name" />
                <asp:BoundField DataField="Last Name" HeaderText="Last Name" />
                <asp:BoundField DataField="E-Mail" HeaderText="E-Mail" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:BoundField DataField="Location" HeaderText="Location" />
                <asp:BoundField DataField="Date of Birth" HeaderText="Date of Birth" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                        <i class="fa fa-money" aria-hidden="true"></i>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
