<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="AddContract.aspx.cs" Inherits="Hospital_Management_Software.Management.AddContract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <h3 class="text-dark mb-4">Renew / New Contract</h3> 
        <div class="row mb-3">
            <div class="col-lg-12">
                <div class="row">
                    <div class="col">
                        <div class="card shadow mb-3">
                            <div class="card-header py-3">
                                <p class="text-primary m-0 font-weight-bold">John's Contract</p>
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
                                                <asp:Label ID="Label4" runat="server" Text="Working Hours" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox4" runat="server" placeholder="10:00 to 17:00"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="py-3">
                                        <p class="text-primary m-0 font-weight-bold">Main Section</p>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label6" runat="server" Text="Salary" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="View"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label7" runat="server" Text="Location" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="On-site"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label12" runat="server" Text="Vacation" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox11" runat="server" placeholder="555-555"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label13" runat="server" Text="Holidays" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="TextBox12" runat="server" placeholder="John Smith's Dad"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Label ID="Label14" runat="server" Text="Benefits" Font-Bold="True"></asp:Label>
                                                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                                                    <asp:ListItem>Child care</asp:ListItem>
                                                    <asp:ListItem>Dental Insurance</asp:ListItem>
                                                    <asp:ListItem>Health Insurance</asp:ListItem>
                                                    <asp:ListItem>Pension</asp:ListItem>
                                                    <asp:ListItem>Vision Care</asp:ListItem>
                                                </asp:CheckBoxList>
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
