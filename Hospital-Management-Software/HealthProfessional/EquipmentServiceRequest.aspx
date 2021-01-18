<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/HealthProfessional.Master" AutoEventWireup="true" CodeBehind="EquipmentServiceRequest.aspx.cs" Inherits="Hospital_Management_Software.HealthProfessional.EquipmentServiceRequest" %>

<asp:Content ID="EquipmentService_head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="EquipmentService_content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 40px">
        <h1>Equipment Service Request</h1>
        <hr />
        <div>
            <div class="row">
                <!-- start of doctor info -->
                <div class="col form-group">
                    <asp:Label ID="lb_name" runat="server" Text="Name:"></asp:Label>
                    <asp:TextBox ID="tb_name" class="form-control" runat="server">Edward Jenner</asp:TextBox>
                </div>
                <div class="col form-group">
                    <asp:Label ID="lb_contact" runat="server" Text="Contact Number:"></asp:Label>
                    <asp:TextBox ID="tb_contact" class="form-control" runat="server">8123 4567</asp:TextBox>
                </div>

            </div>
            <!-- end of doctor info -->

            <div class="row">
                <div class="col form-group">
                    <asp:Label ID="lb_equipmentName" runat="server" Text="Equipment Name:"></asp:Label>
                    <asp:TextBox ID="tb_equipmentName" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_equipmentName" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tb_equipmentName"></asp:RequiredFieldValidator>
                </div>

                <div class="col form-group">
                    <asp:Label ID="lb_equipmentNumber" runat="server" Text="Equipment S/N Number:"></asp:Label>
                    <asp:TextBox ID="tb_equipmentNumber" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col form-group">
                    <asp:Label ID="lb_location" runat="server" Text="Location & Room No.:"></asp:Label>
                    <asp:TextBox ID="tb_location" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col form-group">
                    <asp:Label ID="lb_description" runat="server" Text="Description:"></asp:Label>
                    <asp:TextBox ID="tb_description" class="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                </div>
            </div>

            <asp:Button ID="btn_sbumit" class="btn btn-primary" runat="server" Text="Submit" />

        </div>
    </div>

</asp:Content>
