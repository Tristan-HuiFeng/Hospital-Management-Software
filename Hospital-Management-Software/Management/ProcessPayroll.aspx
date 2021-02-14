<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="ProcessPayroll.aspx.cs" Inherits="Hospital_Management_Software.Management.ProcessPayroll" %>
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
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label11" runat="server" Text="Employee Name" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbName" runat="server" Text="John Smith"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label17" runat="server" Text="Position" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbPosition" runat="server" Text="Finance"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label19" runat="server" Text="Created Date" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbCreatedDate" runat="server" Text="01/01/2020"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label21" runat="server" Text="Processed Date" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbProcessedDate" runat="server" Text="-"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label1" runat="server" Text="Processed Status" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbStatus" runat="server" Text="-"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label3" runat="server" Text="Basic Month" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbMonthSalary" runat="server" Text="2209.09"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label2" runat="server" Text="Bonus" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbBonus" runat="server" Text="-"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label30" runat="server" Text="Employer CPF" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbEmployerCPF" runat="server" Text="531.00"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label23" Font-Underline="true" runat="server" Text="Overtime" Font-Bold="True"></asp:Label>
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
                                                <asp:Label ID="lbOvertimeDetails" runat="server" Text="OT15(20.00 * 18.09)" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbOvertimePay" runat="server" Text="361.89"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    
                                    <hr />
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label32" runat="server" Text="Total Gross Wages" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbTotalWages" runat="server" Text="SGD 3270.33"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button Style="float: right;" CssClass="btn btn-primary btn-sm mx-2" ID="Button2" runat="server" Text="Decide Later" />
                                        <asp:Button Style="float: right;" CssClass="btn btn-primary btn-sm mx-2" ID="Button3" runat="server" Text="Email" />
                                        <asp:Button Style="float: right;" CssClass="btn btn-primary btn-sm mx-2" ID="btnProcess" runat="server" Text="Process" OnClick="btnProcess_Click" />
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
