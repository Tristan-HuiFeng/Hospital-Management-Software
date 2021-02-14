<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="CanvasTest.aspx.cs" Inherits="Hospital_Management_Software.Management.CanvasTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/signature_pad@2.3.2/dist/signature_pad.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

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
                                                <asp:Label ID="lbEmployeeID" runat="server" Text="A001"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label5" runat="server" Text="Contract Date" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbDate" runat="server" Text="01-05-2010"></asp:Label>
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
                                                <asp:Label ID="lbEmployeeName" runat="server" Text="John Smith"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label17" runat="server" Text="Department" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbDepartment" runat="server" Text="Finance"></asp:Label>
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
                                                <asp:Label ID="lbEmail" runat="server" Text="existing@employee.com"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label21" runat="server" Text="Position" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbPosition" runat="server" Text="Accountanat"></asp:Label>
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
                                                <asp:Label ID="lbWorkingHours" runat="server" Text="10:00 to 18:00"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label6" runat="server" Text="Location" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbLocation" runat="server" Text="On-site(Office) or Remote"></asp:Label>
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
                                                <asp:Label ID="lbSalary" runat="server" Text="$2500"></asp:Label>
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
                                                <asp:Label ID="Label9" runat="server" Text="Child care" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbChildCare" runat="server" Text="No"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label12" runat="server" Text="Dental Insurance" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbDentalInsurance" runat="server" Text="No"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label36" runat="server" Text="Health Insurance" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbHealthInsurance" runat="server" Text="No"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="auto-style1">
                                            <div class="form-group">
                                                <asp:Label ID="Label2" runat="server" Text="Pension" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbPension" runat="server" Text="No"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="Label7" runat="server" Text="Vision Care" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbVisionCare" runat="server" Text="No"></asp:Label>
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
                                                <asp:Label ID="lbHolidays" runat="server" Text="June of every year" Font-Bold="True"></asp:Label>
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
                                                <asp:Label ID="lbVacation" runat="server" Text="14 Days" Font-Bold="True"></asp:Label>
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
                                    <div class="form-row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Label ID="Label4" runat="server" Text="Signature" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Image ID="imgSignature" runat="server" Height="100px" Width="200px" />
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="form-group">
                                        <asp:Button Style="float: right;" CssClass="btn btn-primary btn-sm mx-2" ID="btnRenew" runat="server" Text="Renew" OnClick="btnRenew_Click" />
                                        <asp:Button Style="float: right;" OnClientClick="javascript:window.print();" CssClass="btn btn-primary btn-sm mx-2" ID="Button3" runat="server" Text="Print" OnClick="Button3_Click" />
                                        <%--<asp:Button Style="float: right;" CssClass="btn btn-danger btn-sm mx-2" ID="Button1" runat="server" Text="Terminate" />--%>
                                        <asp:Button CausesValidation="false" UseSubmitBehavior="false" Style="float:right;" CssClass="btn btn-secondary btn-sm mx-2" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"/>                                    
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <%-- Signature here --%>
    <canvas id="myCanvas" width="400" height="200" style="border:2px solid;"></canvas>
    <script>
        var canvas = document.querySelector("canvas");
        var signaturePad = new SignaturePad(canvas);
    </script>

    <input type="button" id="btnSave" name="btnSave" value="Save the canvas to server" />
    <script type="text/javascript">
        // Send the canvas image to the server.
        $(function () {
            $("#btnSave").click(function () {
                var image = document.getElementById("myCanvas").toDataURL("image/png");
                image = image.replace('data:image/png;base64,', '');
                $.ajax({
                    type: 'POST',
                    url: 'CanvasTest.aspx/UploadImage',
                    data: '{ "imageData" : "' + image + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (msg) {
                        window.location.href = window.location.href
                    }
                });
            });
        });
    </script>
</asp:Content>
