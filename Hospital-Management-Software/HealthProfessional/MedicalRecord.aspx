<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/HealthProfessional.Master" AutoEventWireup="true" CodeBehind="MedicalRecord.aspx.cs" Inherits="Hospital_Management_Software.HealthProfessional.MedicalRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid" style="padding: 20px;">
        <h1>Medical Records</h1>
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

        <div class="row" style="margin-bottom: 40px">
            <div class="col">
                <asp:Button ID="btn_createMedicalRecord" class="btn btn-primary" runat="server" Text="Create Medical Record" />
            </div>
        </div>
        <!--
        <div class="table-responsive-xl">
            <table class="table">
                <thead>
                    <tr>
                        <th>Record Number</th>
                        <th>Case Type</th>
                        <th>Patient's name</th>
                        <th>Doctor's name</th>
                        <th>Status</th>
                    </tr>

                </thead>
                <tbody>
                    <tr>
                        <td>0001</td>
                        <td>Appointment</td>
                        <td>Ben Dover</td>
                        <td>Aliexpress</td>
                        <td>case closed</td>
                    </tr>
                </tbody>
            </table>
        </div> -->
        <div class="grid-container">
            <asp:GridView ID="GridView1" CssClass="myGrid table" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="4">
                <Columns>
                    <asp:BoundField DataField="patientFullName" HeaderText="Patient's Name" ReadOnly="True" />
                    <asp:BoundField DataField="doctorFullName" HeaderText="Doctor's Name" ReadOnly="True" />
                    <asp:BoundField DataField="diagnosis" HeaderText="Diagnosis" ReadOnly="True" />
                </Columns>
                <PagerStyle HorizontalAlign="Right" CssClass="myPager" />
            </asp:GridView>
            <p>showing 4 out of 12 enties</p>
        </div>

    </div>
</asp:Content>
