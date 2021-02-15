<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeSchedule.aspx.cs" Inherits="Hospital_Management_Software.Management.EmployeeSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../src/css/HRStyleSheet.css" rel="stylesheet" />
    <script src="https://use.fontawesome.com/0ff67f73a3.js"></script>

    <div class="container-fluid">
        <h3 class="text-dark mb-4">Employee Schedules</h3>
        <div class="row mb-3">
            <div class="col-lg-2">
                <div class="card mb-3">
                    <div class="shadow rounded-corners">
                        <div class="input-group">
                            <%--<asp:TextBox CssClass="bg-light border-0 small form-control" placeholder="Search for ..." ID="TextBox3" runat="server"></asp:TextBox>
                            <div class="input-group-append">
                                <asp:HyperLink CssClass="btn btn-primary" ID="HyperLink1" runat="server"><i class="fa fa-search" aria-hidden="true"></i></asp:HyperLink>
                            </div>--%>
                        </div>
                        <br />
                        <asp:GridView AutoGenerateColumns="False" runat="server" ID="GridView1" CssClass="Grid table table-condensed table-hover" AllowPaging="True" PageSize="11" OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="FirstName" HeaderText="Name" />
                                <asp:TemplateField HeaderText=".">
                                    <ItemTemplate>
                                        <asp:LinkButton CssClass="btn m-0 p-0" ID="btnView" runat="server" OnClick="btnView_Click" CommandArgument='<%#Eval("Nric") %>'><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>
                                        <%--<asp:LinkButton CssClass="btn m-0 p-0" ID="btnContract" runat="server" OnClick="btnContract_Click" CommandArgument='<%#Eval("Nric") %>'><i class="fa fa-file" aria-hidden="true"></i></asp:LinkButton>--%>                        
                                        <%--<i class="fa fa-money" aria-hidden="true"></i>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="col-lg-10">
                <div class="row">
                    <div class="col">
                        <div class="card shadow mb-3">
                            <div class="card-body">
                                <form>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label2" runat="server" Text="Name" Font-Bold="True"></asp:Label>
                                                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#CC3300"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbName" runat="server" placeholder="" ReadOnly="True">Pierre Gasly</asp:TextBox>
                                            </div>
                                        </div>
                                        <%--<div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label2" runat="server" Text="Date" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbDate" runat="server" placeholder="">24/11/2020</asp:TextBox>
                                            </div>
                                        </div>--%>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label3" runat="server" Text="Status" Font-Bold="True"></asp:Label>
                                                <asp:DropDownList ID="ddlStatus" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                    <asp:ListItem>Coming To Work</asp:ListItem>
                                                    <asp:ListItem>Came To Work</asp:ListItem>
                                                    <asp:ListItem>Non-Work Day</asp:ListItem>
                                                    <asp:ListItem>Did Not Come</asp:ListItem>
                                                    <asp:ListItem>Taken Leave</asp:ListItem>
                                                    <asp:ListItem>Vacation</asp:ListItem>
                                                    <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label4" runat="server" Text="Reason" Font-Bold="True"></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="tbReason" runat="server" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group shadow rounded-corners">
                                        <asp:Calendar CssClass="Grid" Width="100%" ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged">
                                            <TodayDayStyle BackColor="#6666FF" />
                                        </asp:Calendar>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button Style="float: right;" CssClass="btn btn-primary btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
