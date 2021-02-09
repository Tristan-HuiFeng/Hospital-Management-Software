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
                                <asp:Label CssClass="text-primary m-0 font-weight-bold" ID="lbContract" runat="server" Text="Contract"></asp:Label>
                            </div>
                            <div class="card-body">
                                <form>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label1" runat="server" Text="Employee" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbEmployee" runat="server" placeholder="John Smith" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label2" runat="server" Text="Department" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbDepartment" runat="server" placeholder="Finance" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label3" runat="server" Text="Position" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbPosition" runat="server" placeholder="Accountant" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label4" runat="server" Text="Working Hours" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbWorkingHours" runat="server" placeholder="10:00 to 17:00" required="required"></asp:TextBox>
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
                                                <asp:TextBox class="form-control" ID="tbSalary" runat="server" placeholder="3000" required="required" TextMode="Number"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%--<div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label7" runat="server" Text="Location" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbLocation" runat="server" placeholder="On-site"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label12" runat="server" Text="Vacation" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbVacation" runat="server" placeholder="Every 1st Jan" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label13" runat="server" Text="Holidays" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbHolidays" runat="server" placeholder="Allowed 2 days per year" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Label ID="Label14" runat="server" Text="Benefits" Font-Bold="True"></asp:Label>
                                                <asp:CheckBoxList ID="cblBenefits" runat="server">
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
                                        <asp:Button Style="float: right;" CssClass="btn btn-primary btn-sm" ID="btnCreateContract" runat="server" Text="Create" OnClick="btnCreateContract_Click" />
                                        <asp:Button CausesValidation="false" UseSubmitBehavior="false" Style="float:right;" CssClass="btn btn-secondary btn-sm mr-1" ID="btnBack" runat="server" Text="Cancel" OnClick="btnBack_Click"/>                                                                        
                                        <asp:Label ID="Label5" runat="server" Font-Bold="True"></asp:Label>                                        
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
