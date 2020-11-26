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
                        <asp:GridView AutoGenerateColumns="False" runat="server" ID="GridView1" CssClass="Grid table table-condensed table-hover" AllowPaging="True" PageSize="9">
                            <Columns>
                                <asp:BoundField DataField="Status" HeaderText="Employees" />
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
                                                <asp:Label ID="Label1" runat="server" Text="Name" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="" ReadOnly="True">Pierre Gasly</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label2" runat="server" Text="Date" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="">24/11/2020</asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label3" runat="server" Text="Status" Font-Bold="True"></asp:Label>
                                                <asp:DropDownList ID="DropDownList1" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
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
                                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Medical Leave" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label6" runat="server" Text="Placeholder" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="Placeholder Text"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label7" runat="server" Text="Placeholder" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Placeholder Text"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group shadow rounded-corners">
                                        <asp:Calendar CssClass="Grid" Width="100%" ID="Calendar1" runat="server">
                                            <TodayDayStyle BackColor="#6666FF" />
                                        </asp:Calendar>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button style="float:right;" CssClass="btn btn-primary btn-sm" ID="Button1" runat="server" Text="Save" />
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
