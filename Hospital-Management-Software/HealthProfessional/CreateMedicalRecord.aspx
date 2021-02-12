<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/HealthProfessional.Master" AutoEventWireup="true" CodeBehind="CreateMedicalRecord.aspx.cs" Inherits="Hospital_Management_Software.HealthProfessional.CreateMedicalRecord" %>

<asp:Content ID="MedicalRecordCreate_head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="MedicalRecordCreate_content" ContentPlaceHolderID="MainContent" runat="server">

    
    <div class="container" style="margin-top: 40px; margin-bottom: 40px;">

        <asp:ValidationSummary CssClass="alert alert-danger" ValidationGroup="PatientValidation" ID="ValidationSummary_medicalRecord" runat="server" />
        <asp:ValidationSummary CssClass="alert alert-danger" ValidationGroup="TreatmentValidation" ID="ValidationSummary_medicalRecord2" runat="server" />
        <!--<asp:Label ID="debugging" runat="server" Text="Label" ForeColor="Green"></asp:Label>-->

        <h1>Create New Medical Record</h1>
        <hr />
        <div>
            <!-- start of input container -->

            <!-- start of doctor info 
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
            end of doctor info -->

            <h3 style="margin-top: 20px">Patient</h3>
            <hr />
            
            <!-- search for patient -->

            <div class="form-row align-items-center my-4">
                <div class="row">
                    <div class="col-sm-3 my-1">
                        <asp:Label class="sr-only" ID="lb_patientSearch" runat="server" Text="Patient Search:"></asp:Label>
                        <asp:TextBox ID="tb_patientSearch" class="form-control" runat="server" placeholder="Patient's NRIC / ID"></asp:TextBox>
                    </div>
                    <div class="col-auto my-1">
                        <asp:Button ID="btn_searchPatient" class="btn btn-secondary" runat="server" Text="Search" Enabled="True" OnClick="btn_searchPatient_Click" UseSubmitBehavior="False" />
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                       <asp:RequiredFieldValidator CssClass="text-danger" ID="RequiredFieldValidator_Patient" ValidationGroup="PatientValidation" runat="server" ErrorMessage="Please search for your patient" ControlToValidate="tb_patientID"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            

            <!-- start of patient info -->
            <div class="row">

                <div class="col form-group">
                    <asp:Label ID="lb_patientID" runat="server" Text="Patient's ID:"></asp:Label>
                    <asp:TextBox ID="tb_patientID" class="form-control" runat="server" Disabled="True" ReadOnly="True"></asp:TextBox>
                </div>

                <div class="col form-group">
                    <asp:Label ID="lb_patientName" runat="server" Text="Patient's Name:"></asp:Label>
                    <asp:TextBox ID="tb_patientName" class="form-control" runat="server" Disabled="True" ReadOnly="True"></asp:TextBox>
                </div>

                <div class="col form-group">
                    <asp:Label ID="lb_patientContact" runat="server" Text="Patient's Contact:"></asp:Label>
                    <asp:TextBox ID="tb_patientContact" class="form-control" runat="server" Disabled="True" ReadOnly="True"></asp:TextBox>
                </div>
                

            </div>
            <!-- end of patient info -->

            <h3 style="margin-top: 20px">New Medical Record</h3>
            <hr />
            
            <!-- start of vital signs -->
            <div class="row">

                <div class="col form-group">
                    <asp:Label ID="lb_bloodPressure" runat="server" Text="Blood Pressure:"></asp:Label>
                    <asp:TextBox ID="tb_bloodPressure" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ID="rfv_bloodPressure" runat="server" ErrorMessage="Blood pressure must not empty" ValidationGroup="TreatmentValidation" ControlToValidate="tb_bloodPressure" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col form-group">
                    <asp:Label ID="lb_respirationRate" runat="server" Text="Respiration Rate:"></asp:Label>
                    <asp:TextBox ID="tb_respirationRate" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ID="rfv_respirationRate" runat="server" ErrorMessage="Respiration Rate must not be empty" ValidationGroup="TreatmentValidation" ControlToValidate="tb_respirationRate" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rfv_respirationRate2" CssClass="text-danger" runat="server" ErrorMessage="Invalid Respiration Rate" ValidationGroup="TreatmentValidation" ControlToValidate="tb_respirationRate" MaximumValue="100" MinimumValue="0" Display="Dynamic" Type="Integer"></asp:RangeValidator>
                </div>
                <div class="col form-group">
                    <asp:Label ID="lb_temperature" runat="server" Text="Body Tempreture:"></asp:Label>
                    <asp:TextBox ID="tb_temperature" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ID="rfv_temperature" runat="server" ErrorMessage="Temperature must not be empty" ValidationGroup="TreatmentValidation" ControlToValidate="tb_temperature" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rfv_temperature2" CssClass="text-danger" runat="server" ErrorMessage="Invalid Temperature" ValidationGroup="TreatmentValidation" ControlToValidate="tb_temperature" MaximumValue="100" MinimumValue="0" Display="Dynamic" Type="Double"></asp:RangeValidator>
                </div>
                <div class="col form-group">
                    <asp:Label ID="lb_pulseRate" runat="server" Text="Pulse Rate:"></asp:Label>
                    <asp:TextBox ID="tb_pulseRate" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ID="rfv_pulseRate" runat="server" ErrorMessage="Pulse rate must not be empty" ValidationGroup="TreatmentValidation" ControlToValidate="tb_pulseRate" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rfv_pulseRate2" CssClass="text-danger" runat="server" ErrorMessage="Invalid Pulse" ValidationGroup="TreatmentValidation" ControlToValidate="tb_pulseRate" MaximumValue="300" MinimumValue="0" Display="Dynamic" Type="Integer"></asp:RangeValidator>
                </div>

            </div>
            <!-- end of vital signs -->

            <!-- start of treatment -->
            <div class="row">
                <div class="col form-group">
                    <asp:Label ID="lb_diagnosis" runat="server" Text="Diagnosis:"></asp:Label>
                    <asp:TextBox ID="tb_diagnosis" class="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ID="rfv_diagnosis" runat="server" ErrorMessage="Diagnosis must not be empty" ValidationGroup="TreatmentValidation" ControlToValidate="tb_diagnosis" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="col form-group">
                    <asp:Label ID="lb_treatment" runat="server" Text="Treatment:"></asp:Label>
                    <asp:TextBox ID="tb_treatment" class="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ID="rfv_treatment" runat="server" ErrorMessage="Treatment must not be empty" ValidationGroup="TreatmentValidation" ControlToValidate="tb_treatment" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="col form-group">
                    <asp:Label ID="lb_presecription" runat="server" Text="Prescriptions:"></asp:Label>
                    <asp:TextBox ID="tb_presecription" class="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col form-group">
                    <asp:Label ID="lb_remarks" runat="server" Text="Remarks:"></asp:Label>
                    <asp:TextBox ID="tb_remarks" class="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                </div>
            </div>
            <!-- end of treatment -->

            <asp:Button ID="btn_createRecord" class="btn btn-primary" runat="server" Text="Create Record" OnClick="btn_createRecord_Click" OnClientClick="validate_patient()" />
        </div>
        <!-- end of input container -->
    </div>
    <!-- end of all -->

    <script>
        function validate_patient() {
            var t1 = Page_ClientValidate("PatientValidation");

            if (t1) {
                Page_ClientValidate("TreatmentValidation");
            }
            //var t2 = Page_ClientValidate("child");

            //if (!t1 || !t2) return false;

            //return true;
        }
    </script>
</asp:Content>

