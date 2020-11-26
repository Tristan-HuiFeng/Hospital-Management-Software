<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="AddPayroll.aspx.cs" Inherits="Hospital_Management_Software.Management.AddPayroll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <h3 class="text-dark mb-4">New Payroll</h3>
        <div class="row mb-3">
            <div class="col-lg-12">
                <div class="row">
                    <div class="col">
                        <div class="card shadow mb-3">
                            <div class="card-header py-3">
                                <p class="text-primary m-0 font-weight-bold">Payroll Details</p>
                            </div>
                            <div class="card-body">
                                <form>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label1" runat="server" Text="Employee" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="John Smith"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label2" runat="server" Text="Department" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Finance"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label3" runat="server" Text="Position" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder="Accountant"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label4" runat="server" Text="Mode of Payment" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox4" runat="server" placeholder="Bank/POSB"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="py-3">
                                        <p class="text-primary m-0 font-weight-bold">Bank Details</p>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label6" runat="server" Text="Bank Name" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="POSB"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label7" runat="server" Text="Branch No." Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="55"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label12" runat="server" Text="Acc No." Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox11" runat="server" placeholder="555-555"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label13" runat="server" Text="Acc. Holder Name" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox12" runat="server" placeholder="John Smith's Dad"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label14" runat="server" Text="Salary" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox13" runat="server" placeholder="$3420"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label15" runat="server" Text="Bonus" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox14" runat="server" placeholder="$300"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="py-3">
                                        <p class="text-primary m-0 font-weight-bold">Overtime</p>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label8" runat="server" Text="Hours" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="3"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label9" runat="server" Text="Amount ($)" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="$18"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button Style="float: right;" CssClass="btn btn-primary btn-sm" ID="Button1" runat="server" Text="Create" />
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
