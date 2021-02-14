﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCF_Service_Library.Entity;

namespace Hospital_Management_Software.Views.EPR
{
    public partial class Dashboard : System.Web.UI.Page
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
            else if (!System.Web.HttpContext.Current.User.IsInRole("Receptionist"))
            {
                Response.Redirect("~/ErrorPage/UnauthorisedAccess.aspx");
            }
            else
            {
                if (Session["SuccessPatientMsg"] != null)
                {
                    lb_genMsg.Visible = true;
                    lb_genMsg.Text = Session["SuccessPatientMsg"].ToString();
                }
                GridViewDisplayAll();
            }
        }

        private void GridViewDisplayAll()
        {
            List<PatientRecord> patientList = new List<PatientRecord>();
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            patientList = client.GetAllPatientRecords().ToList<PatientRecord>();


            // using gridview to bind to the list of employee objects
            GV_patients.Visible = true;
            GV_patients.DataSource = patientList;
            GV_patients.DataBind();
        }

        private void GridViewDisplayNoDisabled()
        {
            List<PatientRecord> patientList = new List<PatientRecord>();
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            patientList = client.GetAllPatientRecords().ToList<PatientRecord>();
            List<PatientRecord> patientListDisplay = new List<PatientRecord>();
            foreach (PatientRecord i in patientList)
            {
                if (i.recordDisabled != "true")
                {
                    patientListDisplay.Add(i);
                }
            }


            // using gridview to bind to the list of employee objects
            GV_patients.Visible = true;
            GV_patients.DataSource = patientListDisplay;
            GV_patients.DataBind();
        }

        protected void btn_RegisterPatient_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPatient");
        }

        protected void GV_patients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Disable")
            {
                GridViewRow row = GV_patients.Rows[Convert.ToInt32(e.CommandArgument)]; //Get selected row
                int patientID = Convert.ToInt32(row.Cells[0].Text); //Get patientID
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();//Init DB Client
                client.DisablePatientByID(patientID);
            }
            if (e.CommandName == "EditRecord")
            {
                GridViewRow row = GV_patients.Rows[Convert.ToInt32(e.CommandArgument)]; //Get selected row
                int patientID = Convert.ToInt32(row.Cells[0].Text); //Get patientID
                Session["patientID"] = patientID;
                Response.Redirect("UpdateEPR", false);
            }

        }

        protected void cb_disabeVisible_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}