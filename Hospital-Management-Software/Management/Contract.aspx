<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="Contract.aspx.cs" Inherits="Hospital_Management_Software.Management.Contract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <h3 class="text-dark mb-4">Contract Details</h3>
        <div class="row mb-3">
            <div class="col-lg-12">
                <div class="row">
                    <div class="col">
                        <div class="card shadow mb-3">
                            <div class="card-header py-3">
                                <p class="text-primary m-0 font-weight-bold">Contract</p>
                            </div>
                            <div class="card-body">
                                <form>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label1" runat="server" Text="Employee ID" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="Label2" runat="server" Text="A001"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label5" runat="server" Text="Date Join" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="Label10" runat="server" Text="01-05-2010"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label11" runat="server" Text="Employee Name" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="Label16" runat="server" Text="John Smith"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label17" runat="server" Text="Department" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="Label18" runat="server" Text="Finance"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label19" runat="server" Text="Email" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="Label20" runat="server" Text="existing@employee.com"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label21" runat="server" Text="Position" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="Label22" runat="server" Text="Accountant"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label3" runat="server" Text="Working Hours" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="Label4" runat="server" Text="10:00 to 18:00"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label6" runat="server" Text="Location" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="Label7" runat="server" Text="On-site(Office) or Remote"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label34" runat="server" Text="Base Salary" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="Label35" runat="server" Text="$2500"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label8" Font-Underline="true" runat="server" Text="Benefits" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label9" runat="server" Text="Medical" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="Label13" runat="server" Text="Yes"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label12" runat="server" Text="Insurance" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="Label14" runat="server" Text="Yes"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label15" runat="server" Text="Dental Care" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="Label36" runat="server" Text="No"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label23" Font-Underline="true" runat="server" Text="Holidays" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label24" runat="server" Text="June of every year" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label25" Font-Underline="true" runat="server" Text="Vacation" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label28" runat="server" Text="14 Days" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label26" Font-Underline="true" runat="server" Text="Termination" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Label ID="Label27" runat="server" Text="[Rules that cannot be broken if not the employer can choose to fire the employee at any given time.]" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="form-group">
                                        <asp:Button Style="float: right;" CssClass="btn btn-primary btn-sm mx-2" ID="Button2" runat="server" Text="Renew" />
                                        <asp:Button Style="float: right;" CssClass="btn btn-primary btn-sm mx-2" ID="Button3" runat="server" Text="Print" />
                                        <asp:Button Style="float: right;" CssClass="btn btn-danger btn-sm mx-2" ID="Button1" runat="server" Text="Terminate" />
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
