<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="Payrolls.aspx.cs" Inherits="Hospital_Management_Software.Payrolls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../src/css/HRStyleSheet.css" rel="stylesheet" />
    <script src="https://use.fontawesome.com/0ff67f73a3.js"></script>

    <div class="card shadow-sm p-3 mb-5 bg-white rounded" style="width: 40%;">
        <div class="card-body">
            <div class="input-group">
                <asp:TextBox CssClass="bg-light border-0 small form-control" placeholder="From-Date" ID="tbFirstDate" runat="server" TextMode="Date"></asp:TextBox>
                <%--<div class="input-group-append">
                    <asp:HyperLink CssClass="btn btn-primary" ID="HyperLink1" runat="server"><i class="fa fa-search" aria-hidden="true"></i></asp:HyperLink>
                </div>--%>
            </div>
            <asp:Label CssClass="border-0 small form-control" ID="Label1" runat="server" Text=" TO " Font-Bold="True"></asp:Label>
            <div class="input-group">
                <asp:TextBox CssClass="bg-light border-0 small form-control" placeholder="From-Date" ID="tbSecondDate" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <asp:Button CssClass="btn btn-primary mr-1" ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click"/>
            <asp:HyperLink CssClass="btn btn-info" ID="HyperLink1" runat="server" NavigateUrl="~/Management/AddPayroll.aspx">+New Payroll</asp:HyperLink>
            <br />
            <br />
            <%--<p class="card-text">
                <asp:DropDownList CssClass="btn btn-primary" ID="DropDownList1" runat="server">
                    <asp:ListItem Selected="True" hidden="true">+2 Filters</asp:ListItem>
                    <asp:ListItem>Gender</asp:ListItem>
                    <asp:ListItem>DOB</asp:ListItem>
                </asp:DropDownList>
            </p>--%>
        </div>
    </div>
    <br />
    <div class="shadow rounded-corners">
        <asp:GridView AutoGenerateColumns="False" runat="server" ID="GridView1" HorizontalAlign="Center" CssClass="Grid table table-condensed table-hover" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="createdDate" HeaderText="Date Created" />
                <asp:BoundField DataField="processed" HeaderText="Processed Status" />
                <asp:BoundField DataField="employeeName" HeaderText="Name" />
                <asp:BoundField DataField="employeePosition" HeaderText="Position" />             
                <asp:TemplateField HeaderText="...">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="btn m-0 p-0" ID="btnView" runat="server" OnClick="btnView_Click" CommandArgument='<%#Eval("id") %>'><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
