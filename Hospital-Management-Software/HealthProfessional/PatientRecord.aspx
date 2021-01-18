<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/HealthProfessional.Master" AutoEventWireup="true" CodeBehind="PatientRecord.aspx.cs" Inherits="Hospital_Management_Software.HealthProfessional.PatientRecord" %>

<asp:Content ID="PatientRecord_head" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="PatientRecord_content" ContentPlaceHolderID="MainContent" runat="server">
    <!-- start of container -->
    <div class="containter-fluid" style="margin-top: 40px">

        <div class="container-fluid" style="padding: 20px;">
            <h1>Patient's Records</h1>
            <hr />
            <div class="form-row align-items-center my-4">
                <div class="col-sm-3 my-1">
                    <asp:Label class="sr-only" ID="lb_patientSearch" runat="server" Text="Patient Search:"></asp:Label>
                    <asp:TextBox ID="tb_patientSearch" class="form-control" runat="server" placeholder="Patient's NRIC / ID"></asp:TextBox>
                </div>


                <div class="col-auto my-1">
                    <asp:Button ID="btn_searchPatient" class="btn btn-secondary" runat="server" Text="Search" />
                </div>
            </div>

        </div>

        
        <asp:GridView ID="GridView1" CssClass="myGrid table" runat="server" AllowPaging="True" PageSize="6" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="patientFullName" HeaderText="Patient's Name" ReadOnly="True" />
                <asp:BoundField DataField="nric" HeaderText="NRIC" ReadOnly="True" />
                <asp:BoundField DataField="dob" HeaderText="DOB" ReadOnly="True" />
                <asp:BoundField DataField="sex" HeaderText="Sex" ReadOnly="True" />
                <asp:BoundField DataField="allergies" HeaderText="Allergies" ReadOnly="True" />
                <asp:ButtonField Text="View Details" />
            </Columns>
            <PagerStyle HorizontalAlign="Right" CssClass="myPager" />
        </asp:GridView>

    </div>

</asp:Content>
