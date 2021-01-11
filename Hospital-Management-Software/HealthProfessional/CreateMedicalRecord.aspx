﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/HealthProfessional.Master" AutoEventWireup="true" CodeBehind="CreateMedicalRecord.aspx.cs" Inherits="Hospital_Management_Software.HealthProfessional.CreateMedicalRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top: 40px">
        <h1>Create New Medical Record</h1>
        <hr />
        <div>
            <!-- start of input container -->

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

            <h3 style="margin-top: 20px">Patient</h3>
            <hr />

            <!-- search for patient -->



            <div class="form-row align-items-center my-4">
                <div class="col-sm-3 my-1">
                    <asp:Label class="sr-only" ID="lb_patientSearch" runat="server" Text="Patient Search:"></asp:Label>
                    <asp:TextBox ID="tb_patientSearch" class="form-control" runat="server" placeholder="Patient's NRIC / ID"></asp:TextBox>
                </div>

                
                <div class="col-auto my-1">
                    <asp:Button ID="btn_searchPatient" class="btn btn-secondary" runat="server" Text="Search" />
                </div>
            </div>

            <!-- start of patient info -->
            <div class="row">

                <div class="col form-group">
                    <asp:Label ID="lb_patientFirstName" runat="server" Text="Patient's First Name:"></asp:Label>
                    <asp:TextBox ID="tb_patientFirstName" class="form-control" runat="server">Alex</asp:TextBox>
                </div>
                <div class="col form-group">
                    <asp:Label ID="lb_patientLastName" runat="server" Text="Patient's Last Name:"></asp:Label>
                    <asp:TextBox ID="tb_patientLastName" class="form-control" runat="server">Lim</asp:TextBox>
                </div>

            </div>
            <!-- end of patient info -->

            <h3 style="margin-top: 20px">New Medical Record</h3>
            <hr />
            
            <div class="row">

                <div class="col form-group">
                    <asp:Label ID="Label1" runat="server" Text="Blood Pressure:"></asp:Label>
                    <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col form-group">
                    <asp:Label ID="Label2" runat="server" Text="Respiration Rate:"></asp:Label>
                    <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col form-group">
                    <asp:Label ID="Label3" runat="server" Text="Body Tempreture:"></asp:Label>
                    <asp:TextBox ID="TextBox3" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col form-group">
                    <asp:Label ID="Label4" runat="server" Text="Pulse Rate:"></asp:Label>
                    <asp:TextBox ID="TextBox4" class="form-control" runat="server"></asp:TextBox>
                </div>

            </div>

            <div class="row">
                <div class="col form-group">
                    <asp:Label ID="Label5" runat="server" Text="Diagnosis:"></asp:Label>
                    <asp:TextBox ID="TextBox5" class="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col form-group">
                    <asp:Label ID="Label6" runat="server" Text="Treatment:"></asp:Label>
                    <asp:TextBox ID="TextBox6" class="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col form-group">
                    <asp:Label ID="Label7" runat="server" Text="Prescriptions:"></asp:Label>
                    <asp:TextBox ID="TextBox7" class="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col form-group">
                    <asp:Label ID="lb_remarks" runat="server" Text="Remarks:"></asp:Label>
                    <asp:TextBox ID="tb_remarks" class="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                </div>
            </div>

            <asp:Button ID="btn_sbumit" class="btn btn-primary" runat="server" Text="Create Record" />
        </div>
        <!-- end of input container -->
    </div>
    <!-- end of all -->
</asp:Content>