using Hospital_Management_Software.MyDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace Hospital_Management_Software.Views.EPR
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["SuccessPatientMsg"] != null)
            {
                lb_genMsg.Visible = true;
                lb_genMsg.Text = Session["SuccessPatientMsg"].ToString();
            }
            RefreshGridView();
        }

        private void RefreshGridView()
        {
            List<PatientRecord> patientList = new List<PatientRecord>();
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            patientList = client.GetAllPatientRecords().ToList<PatientRecord>();

            // using gridview to bind to the list of employee objects
            GV_patients.Visible = true;
            GV_patients.DataSource = patientList;
            GV_patients.DataBind();
        }

        protected void btn_RegisterPatient_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Reached - Registering Patient");
            Response.Redirect("RegisterPatient");
        }

        protected void GV_patients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Disable") 
            {
                Debug.WriteLine("Reached - Disabling Patient");
                GridViewRow row = GV_patients.Rows[Convert.ToInt32(e.CommandArgument)]; //Get selected row
                int patientID = Convert.ToInt32(row.Cells[0].Text); //Get patientID
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();//Init DB Client
                client.DisablePatientByID(patientID);

            }
            if (e.CommandName == "EditRecord")
            {
                Debug.WriteLine("Reached - Editing Patient");
                GridViewRow row = GV_patients.Rows[Convert.ToInt32(e.CommandArgument)]; //Get selected row
                int patientID = Convert.ToInt32(row.Cells[0].Text); //Get patientID
                Session["patientID"] = patientID;
                Response.Redirect("UpdateEPR", false);
            }

        }
    }
}