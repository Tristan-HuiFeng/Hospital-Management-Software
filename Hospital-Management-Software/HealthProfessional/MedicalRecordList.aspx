<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/HealthProfessional.Master" AutoEventWireup="true" CodeBehind="MedicalRecordList.aspx.cs" Inherits="Hospital_Management_Software.HealthProfessional.MedicalRecordList" %>

<asp:Content ID="MedicalRecordList_head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="MedicalRecordList_Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid" style="padding: 20px; margin-top: 40px;">
        <h1>Medical Record List</h1>
        <hr />
        <!--
        <div class="form-row align-items-center my-4">

            <div class="col-sm-3 my-1">
                <asp:Label class="sr-only" ID="lb_patientSearch" runat="server" Text="Patient Search:"></asp:Label>
                <asp:TextBox ID="tb_patientSearch" class="form-control" runat="server" placeholder="Patient's NRIC / ID"></asp:TextBox>
            </div>


            <div class="col-auto my-1">
                <asp:Button ID="btn_searchPatient" class="btn btn-secondary" runat="server" Text="Search" UseSubmitBehavior="False" />
            </div>
        </div>-->

        <div class="row" style="margin-bottom: 40px">
            <div class="col">
                <asp:Button ID="btn_createMedicalRecord" class="btn btn-primary" runat="server" Text="Create Medical Record" OnClick="btn_createMedicalRecord_Click" />
            </div>
        </div>

        <div class="grid-container">
            <asp:GridView ID="gv_MedicalRecordList" CssClass="myGrid table" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="4" OnSelectedIndexChanged="gv_MedicalRecordList_SelectedIndexChanged" OnPageIndexChanging="gv_MedicalRecordList_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="date" HeaderText="Date" ReadOnly="True" />
                    <asp:BoundField DataField="Medical_Record_ID" HeaderText="Medical Record ID" ReadOnly="True" />
                    <asp:BoundField DataField="patientFullName" HeaderText="Patient's Name" ReadOnly="True" />
                    <asp:BoundField DataField="doctorFullName" HeaderText="Doctor's Name" ReadOnly="True" />
                    <asp:BoundField DataField="diagnosis" HeaderText="Diagnosis" ReadOnly="True" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <PagerStyle HorizontalAlign="Right" CssClass="myPager" />
            </asp:GridView>
            <!--<p>showing 4 out of 12 entries</p>-->
        </div>

    </div>
</asp:Content>
