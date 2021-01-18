using Hospital_Management_Software.MyDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Hospital_Management_Software.HealthProfessional
{
    public partial class CreateMedicalRecord : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //tb_patientName.Attributes["disabled"] = "disabled";
            //tb_patientID.Attributes["disabled"] = "disabled";
            //tb_patientContact.Attributes["disabled"] = "disabled";
        }

        protected void btn_searchPatient_Click(object sender, EventArgs e)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            //tb_patientName.Text = "Alex Lim";
            tempPatient tp = client.GetPatientByID(tb_patientSearch.Text);
            if(tp != null)
            {
                tb_patientName.Text = tp.name;
                tb_patientID.Text = tp.id.ToString();
                tb_patientContact.Text = tp.contact;
            }
            else
            {
                var val = new CustomValidator()
                {
                    ErrorMessage = "User not found",
                    Display = ValidatorDisplay.None,
                    IsValid = false,
                    ValidationGroup = "TreatmentValidation"
                };
                val.ServerValidate += (object source, ServerValidateEventArgs args) =>
                { args.IsValid = false; };
                Page.Validators.Add(val);
            }

        }

        protected void btn_createRecord_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                

                int patient_id;
                int doctor_id = Convert.ToInt32(1);
                debugging.Text = tb_patientID.Text;
                bool success = int.TryParse(tb_patientID.Text, out patient_id);
                
                
                if(success == false)
                {
                    var val = new CustomValidator()
                    {
                        ErrorMessage = "Invalid patient detail",
                        Display = ValidatorDisplay.None,
                        IsValid = false,
                        ValidationGroup = "TreatmentValidation"
                    };
                    val.ServerValidate += (object source, ServerValidateEventArgs args) =>
                    { args.IsValid = false; };
                    Page.Validators.Add(val);
                }
                else
                {
                    int result = client.CreateMedicalRecord(tb_bloodPressure.Text, tb_respirationRate.Text, tb_temperature.Text, tb_pulseRate.Text, tb_diagnosis.Text,
                    tb_treatment.Text, DateTime.Now, doctor_id, patient_id, tb_presecription.Text, tb_remarks.Text);


                    if (result == 1)
                    {
                        Response.Redirect("MedicalRecordList.aspx");
                    }
                    else
                    {
                        var val = new CustomValidator()
                        {
                            ErrorMessage = "Database error. Please contact administrator",
                            Display = ValidatorDisplay.None,
                            IsValid = false,
                            ValidationGroup = "TreatmentValidation"
                        };
                        val.ServerValidate += (object source, ServerValidateEventArgs args) =>
                        { args.IsValid = false; };
                        Page.Validators.Add(val);

                    }
                }


            }
            
        }
    }
}