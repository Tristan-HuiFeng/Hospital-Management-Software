using Hospital_Management_Software.MyDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCF_Service_Library.Entity;

namespace Hospital_Management_Software.HealthProfessional
{
    public partial class ViewMedicalRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0"); // Proxies.

            bool auth = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if (!auth)
            {
                Response.Redirect("~/Login/StaffLogin.aspx");
            }
            else if (!System.Web.HttpContext.Current.User.IsInRole("Doctor"))
            {
                Response.Redirect("~/ErrorPage/UnauthorisedAccess.aspx");
            }
            else
            {



                if (Session["Medical_Record_ID"] != null)
                {
                    int medical_record_id;
                    bool success = int.TryParse(Session["Medical_Record_ID"].ToString(), out medical_record_id);
                    Session["Medical_Record_ID"] = null;
                    Session.Remove("Medical_Record_ID");
                    if (success)
                    {
                        MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                        MedicalRecord medicalRecord = client.GetMedicalRecordByID(medical_record_id);

                        lb_medicalRecordID.Text = medicalRecord.medicalRecordID.ToString();
                        lb_date.Text = medicalRecord.consultationDate.ToString();
                        lb_patientContact.Text = medicalRecord.patientContact.ToString();
                        lb_patientName.Text = medicalRecord.patientName.ToString();
                        lb_doctorName.Text = medicalRecord.doctorName.ToString();
                        lb_doctorEmail.Text = medicalRecord.doctorEmail.ToString();
                        lb_bloodPressure.Text = medicalRecord.bloodPressure.ToString();
                        lb_respirationRate.Text = medicalRecord.respirationRate.ToString();
                        lb_temperature.Text = medicalRecord.bodyTemperature.ToString();
                        lb_pulseRate.Text = medicalRecord.pulseRate.ToString();

                        lb_diagnosis.Text = medicalRecord.diagnosis.ToString();
                        lb_treatment.Text = medicalRecord.treatment.ToString();
                        lb_prescription.Text = medicalRecord.prescriptions.ToString() != "" ? medicalRecord.prescriptions.ToString() : "N/A";
                        lb_remarks.Text = medicalRecord.remarks.ToString() != "" ? medicalRecord.remarks.ToString() : "N/A";


                    }
                    else
                    {
                        Response.Redirect("MedicalRecordList.aspx");
                    }



                    /*
                    // Assign session variables for customer id, name and account labels
                    lbCustId.Text = Session["SScustId"].ToString();
                    lbCustname.Text = Session["SScustName"].ToString();
                    lbAcc.Text = Session["SSTDAcNo"].ToString();

                    // Retrieve TDMaster records by account
                    MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                    TDMaster td = client.GetTDMasterByAccId(lbAcc.Text);

                    // Show TDMaster info on form
                    lbPrincipal.Text = td.Principal.ToString();
                    lbMaturedAmt.Text = td.MaturedAmt.ToString();
                    lbMaturedDte.Text = td.MaturityDate.ToString();
                    ddlRenew.SelectedItem.Text = td.RenewMode;*/

                }
                else
                {
                    Response.Redirect("MedicalRecordList.aspx");
                }
            }

        }
    }
}