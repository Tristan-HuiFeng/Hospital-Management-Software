<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="ModifyEmployee.aspx.cs" Inherits="Hospital_Management_Software.ModifyEmployee" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <h3 class="text-dark mb-4">Edit Employee</h3>
        <div class="row mb-3">
            <div class="col-lg-4">
                <div class="card mb-3">
                    <div class="card-body text-center shadow">
                        <asp:Image CssClass="rounded-circle mb-3 mt-4" ID="Image1" runat="server" />
                        <img class="rounded-circle mb-3 mt-4" src="dogs/image2.jpeg" width="160" height="160" />
                        <div class="mb-3">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="Button2" runat="server" Text="Change Photo" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-8">
                <div class="row">
                    <div class="col">
                        <div class="card shadow mb-3">
                            <div class="card-header py-3">
                                <p class="text-primary m-0 font-weight-bold">User Settings</p>
                            </div>
                            <div class="card-body">
                                <form>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label1" runat="server" Text="NRIC" Font-Bold="True"></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="S0000000D" ReadOnly="True">S1234567D</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label2" runat="server" Text="E-Mail" Font-Bold="True"></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="new@test.com">existing@employee.com</asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label3" runat="server" Text="First Name" Font-Bold="True"></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="John">Pierre</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label4" runat="server" Text="Last Name" Font-Bold="True"></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Smith">Gasly</asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label6" runat="server" Text="Date of Birth" Font-Bold="True"></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="01/01/1989 (DD/MM/YYYY)" ReadOnly="True">07/02/1996</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label7" runat="server" Text="Gender" Font-Bold="True"></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Male or Female" ReadOnly="True">Male</asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="py-3">
                                        <p class="text-primary m-0 font-weight-bold">Company Needed Information</p>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label5" runat="server" Text="Address" Font-Bold="True"></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Jurong East, Singapore">Rouen, France</asp:TextBox>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label8" runat="server" Text="Department" Font-Bold="True"></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Finance">Race</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label9" runat="server" Text="Position" Font-Bold="True"></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Accountant">Driver</asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label10" runat="server" Text="Nationality" Font-Bold="True"></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Singaporean">French</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label11" runat="server" Text="Medical Records" Font-Bold="True"></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Attach"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button Style="float: right;" CssClass="btn btn-primary btn-sm" ID="Button1" runat="server" Text="Save Employee" />
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
