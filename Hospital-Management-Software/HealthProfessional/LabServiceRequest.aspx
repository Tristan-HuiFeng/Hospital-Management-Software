<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/HealthProfessional.Master" AutoEventWireup="true" CodeBehind="LabServiceRequest.aspx.cs" Inherits="Hospital_Management_Software.HealthProfessional.LabServiceRequest" %>

<asp:Content ID="LabService_head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="LabService_content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Laboratory Service Request</h1>
        <div>
            <!-- start of doctor info -->
            <div class="row">

                <div class="col form-group">
                    <asp:Label ID="lb_doctorName" runat="server" Text="Name:"></asp:Label>
                    <asp:TextBox ID="tb_doctorName" class="form-control" runat="server">Edward Jenner</asp:TextBox>
                </div>
                <div class="col form-group">
                    <asp:Label ID="lb_doctorContact" runat="server" Text="Contact Number:"></asp:Label>
                    <asp:TextBox ID="tb_doctorContact" class="form-control" runat="server">8123 4567</asp:TextBox>
                </div>

            </div>
            <!-- end of doctor info -->

            <div class="form-group">
                <label for="exampleFormControlSelect1">Priority:</label>
                <select class="form-control" id="exampleFormControlSelect1">
                    <option>STAT (within 2 hours)</option>
                    <option>Urgent (within 4 hours)</option>
                    <option>Normal (within 8 hours)</option>
                    <option>Routine (within 1 - 2 days)</option>
                    <option>Special Case (complex testing required, unknown duration)</option>
                </select>
            </div>


            <div class="row">
                <div class="col form-group">
                    <asp:Label ID="lb_test" runat="server" Text="Test Required / Test Codes:"></asp:Label>
                    <asp:TextBox ID="tb_test" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col form-group">
                    <asp:Label ID="lb_remarks" runat="server" Text="Remarks:"></asp:Label>
                    <asp:TextBox ID="tb_remarks" class="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                </div>
            </div>

            <asp:Button ID="btn_sbumit" class="btn btn-primary" runat="server" Text="Submit" />

        </div>
    </div>

</asp:Content>


