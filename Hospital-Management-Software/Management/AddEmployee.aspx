<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="Hospital_Management_Software.AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <h3 class="text-dark mb-4">New Employee</h3>
        <div class="row mb-3">
            <div class="col-lg-4">
                <div class="card mb-3">
                    <div class="card-body text-center shadow">
                        <asp:Image CssClass="rounded-circle mb-3 mt-4" width="160" height="160" ID="imgEmployee" runat="server" BorderStyle="Solid"/>
                        <div class="mb-3">
                            <asp:FileUpload  ID="FileUpload1" runat="server" Style="overflow: hidden;" Width="70%"/>
                            <br />
                            <asp:Button UseSubmitBehavior="false" CausesValidation="false" CssClass="btn btn-primary btn-sm" ID="btnAddPhoto" runat="server" Text="Add Photo" OnClick="btnAddPhoto_Click" Width="70%"/>
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
                                                <asp:CustomValidator ID="validateNRIC" runat="server" ErrorMessage="CustomValidator" ControlToValidate="tbNric" OnServerValidate="validateNRIC_ServerValidate">Invalid NRIC!</asp:CustomValidator>
                                                <asp:TextBox class="form-control" ID="tbNric" runat="server" placeholder="S0000000D" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label2" runat="server" Text="E-Mail" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbEmail" runat="server" placeholder="new@test.com" TextMode="Email" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label3" runat="server" Text="First Name" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbFname" runat="server" placeholder="John" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label4" runat="server" Text="Last Name" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbLname" runat="server" placeholder="Smith" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label6" runat="server" Text="Date of Birth" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbDOB" runat="server" placeholder="01/01/1989 (DD/MM/YYYY)" required="required" TextMode="Date"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label7" runat="server" Text="Gender" Font-Bold="True"></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="ddlGender" runat="server">
                                                    <asp:ListItem Value="M">Male</asp:ListItem>
                                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="py-3">
                                        <p class="text-primary m-0 font-weight-bold">Company Needed Information</p>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label5" runat="server" Text="Address" Font-Bold="True"></asp:Label>
                                        <asp:TextBox class="form-control" ID="tbAddress" runat="server" placeholder="Jurong East, Singapore" required="required"></asp:TextBox>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label8" runat="server" Text="Department" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbDepartment" runat="server" placeholder="Finance" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label9" runat="server" Text="Position" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbPosition" runat="server" placeholder="Accountant" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label10" runat="server" Text="Nationality" Font-Bold="True"></asp:Label>
                                                <asp:TextBox class="form-control" ID="tbNationality" runat="server" placeholder="Singaporean" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Label ID="Label11" runat="server" Text="Medical Records" Font-Bold="True"></asp:Label>
                                                <asp:FileUpload  ID="uploadMedical" runat="server" Style="overflow: hidden;" Width="70%"/>
                                                <%--<asp:Button CssClass="btn btn-secondary btn-sm form-control" ID="Button3" runat="server" Text="Attach" />--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button style="float:right;" CssClass="btn btn-primary btn-sm mr-1" ID="btnAddEmployee" runat="server" Text="Add Employee" OnClick="btnAddEmployee_Click" />
                                        <asp:Button CausesValidation="false" UseSubmitBehavior="false" Style="float:right;" CssClass="btn btn-secondary btn-sm mr-1" ID="btnBack" runat="server" Text="Cancel" OnClick="btnBack_Click"/>                                    
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
