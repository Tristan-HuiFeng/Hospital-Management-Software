<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/HealthProfessional.Master" AutoEventWireup="true" CodeBehind="ViewMedicalRecord.aspx.cs" Inherits="Hospital_Management_Software.HealthProfessional.ViewMedicalRecord" %>
<asp:Content ID="ViewMedicalRecord_head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ViewMedicalRecord_content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid" style="padding: 20px; margin-top: 20px;"> 

        <h1>Medical Record Detail</h1>
        <hr class="hr-style" />

        <div class="container-fluid" style="margin-bottom:40px">

            <div class="row">
                <asp:Label cssClass="record-label" ID="Label25" runat="server" Text="Medical Record ID:&nbsp"></asp:Label>
                <asp:Label cssClass="" ID="lb_medicalRecordID" runat="server" Text="Label"></asp:Label>
            </div>

            <div class="row">
                <asp:Label cssClass="record-label" ID="Label27" runat="server" Text="Date:&nbsp"></asp:Label>
                <asp:Label ID="lb_date" runat="server" Text="Label"></asp:Label>
            </div>

        </div>


        <h3>Patient's Information</h3>
        <hr class="hr-style" />
        <div class="container-fluid" style="margin-bottom:40px">

            <div class="row">
                <asp:Label cssClass="record-label" ID="Label1" runat="server" Text="Patient's Name:&nbsp"></asp:Label>
                <asp:Label ID="lb_patientName" runat="server" Text="Label"></asp:Label>
            </div>

            <div class="row">
                <asp:Label cssClass="record-label" ID="Label3" runat="server" Text="Patient's Contact:&nbsp"></asp:Label>
                <asp:Label ID="lb_patientContact" runat="server" Text="Label"></asp:Label>
            </div>

        </div>
        

        <h3>Doctor's Information</h3>
        <hr class="hr-style" />

        <div class="container-fluid" style="margin-bottom:40px">

            <div class="row">
                <asp:Label cssClass="record-label" ID="Label9" runat="server" Text="Doctor's Name:&nbsp"></asp:Label>
                <asp:Label ID="lb_doctorName" runat="server" Text="Label"></asp:Label>
            </div>

            <div class="row">
                <asp:Label cssClass="record-label" ID="Label11" runat="server" Text="Doctor's Email:&nbsp"></asp:Label>
                <asp:Label ID="lb_doctorEmail" runat="server" Text="Label"></asp:Label>
            </div>

        </div>

        <h3>Vital Sign</h3>
        <hr class="hr-style" />

        <div class="container-fluid" style="margin-bottom:40px">
            <div class="row">
                <div class="col">
                    <asp:Label cssClass="record-label" ID="Label13" runat="server" Text="Blood Pressure:&nbsp"></asp:Label>
                    <asp:Label ID="lb_bloodPressure" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col">
                    <asp:Label cssClass="record-label" ID="Label5" runat="server" Text="Respiration Rate:&nbsp"></asp:Label>
                    <asp:Label ID="lb_respirationRate" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col">
                    <asp:Label cssClass="record-label" ID="Label7" runat="server" Text= "Temperature:&nbsp"></asp:Label>
                    <asp:Label ID="lb_temperature" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col">
                    <asp:Label cssClass="record-label" ID="Label15" runat="server" Text= "Pulse Rate:&nbsp"></asp:Label>
                    <asp:Label ID="lb_pulseRate" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>
        

        <h3>Medical Treatment</h3>
        <hr class="hr-style" />
        <div class="container-fluid" style="margin-bottom:40px">

            <div class="row mb-2">
                <asp:Label cssClass="record-label" ID="Label17" runat="server" Text= "Diagnosis:&nbsp"></asp:Label>
                <asp:Label ID="lb_diagnosis" runat="server" Text="Label"></asp:Label>
            </div>

            <div class="row mb-2">
                <asp:Label cssClass="record-label" ID="Label19" runat="server" Text= "Treatment:&nbsp"></asp:Label>
                <asp:Label ID="lb_treatment" runat="server" Text=" Label"></asp:Label>
            </div>

            <div class="row mb-2">
                <asp:Label cssClass="record-label" ID="Label21" runat="server" Text= "Prescription:&nbsp"></asp:Label>
                <asp:Label ID="lb_prescription" runat="server" Text="Label"></asp:Label>
            </div>

            <div class="row mb-2">
                <asp:Label cssClass="record-label" ID="Label23" runat="server" Text= "Remarks:&nbsp"></asp:Label>
                <asp:Label ID="lb_remarks" runat="server" Text=" Label"></asp:Label>
            </div>

        </div>


    </div>
</asp:Content>
