<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="ViewContracts.aspx.cs" Inherits="Hospital_Management_Software.Management.ViewContracts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../src/css/HRStyleSheet.css" rel="stylesheet" />
    <script src="https://use.fontawesome.com/0ff67f73a3.js"></script>

    <div class="card shadow-sm p-3 mb-5 bg-white rounded" style="width: 40%;">
        <%--<div class="card-body">
            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch">
                <div class="input-group">
                <asp:TextBox CssClass="bg-light border-0 small form-control" placeholder="Search for ..." ID="tbSearch" runat="server"></asp:TextBox>
                <div class="input-group-append">
                    <asp:LinkButton CssClass="btn btn-primary" ID="btnSearch" runat="server" OnClick="btnSearch_Click"><i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>
                </div>
            </div>
            </asp:Panel>
            <br />
            <p class="card-text">
                <asp:DropDownList CssClass="btn btn-primary" ID="ddlFilter" runat="server">
                    <asp:ListItem Selected="True" hidden="true">Filters</asp:ListItem>
                    <asp:ListItem>Gender</asp:ListItem>
                    <asp:ListItem>DOB</asp:ListItem>
                </asp:DropDownList>

                <asp:DropDownList CssClass="btn btn-primary" ID="ddlOrder" runat="server">
                    <asp:ListItem>ASC</asp:ListItem>
                    <asp:ListItem>DESC</asp:ListItem>
                </asp:DropDownList>

                <asp:LinkButton CssClass="btn btn-primary" ID="btnFilter" runat="server" OnClick="btnFilter_Click"><i class="fa fa-arrow-right" aria-hidden="true"></i></asp:LinkButton>
                <asp:Button CssClass="btn btn-primary mr-1" ID="btnResetFilter" runat="server" Text="Reset" OnClick="btnResetFilter_Click"/>
            </p>
            <asp:HyperLink CssClass="btn btn-info" ID="HyperLink1" runat="server" NavigateUrl="~/Management/AddEmployee.aspx">+New Record</asp:HyperLink>

        </div>--%>
    </div>
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/HealthProfessional/Dashboard.aspx">Back</asp:HyperLink>
    <br />
    <div class="shadow rounded-corners">
        <asp:GridView AutoGenerateColumns="false" runat="server" ID="GridView1" HorizontalAlign="Center" CssClass="Grid table table-condensed table-hover" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="create_date" HeaderText="Date Created" />
                <asp:BoundField DataField="salary" HeaderText="Salary" />
                <asp:BoundField DataField="workingHours" HeaderText="Working Hours" />
                <asp:TemplateField HeaderText="View">
                    <ItemTemplate>
                        <%--<asp:LinkButton CssClass="btn m-0 p-0" ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%#Eval("Nric") %>'><i class="fa fa-pencil-square-o" aria-hidden="true"></i></asp:LinkButton>--%>
                        <asp:LinkButton CssClass="btn m-0 p-0" ID="btnContract" runat="server" OnClick="btnContract_Click" CommandArgument='<%#Eval("id") %>'><i class="fa fa-file" aria-hidden="true"></i></asp:LinkButton>                        
                        <%--<i class="fa fa-money" aria-hidden="true"></i>--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
