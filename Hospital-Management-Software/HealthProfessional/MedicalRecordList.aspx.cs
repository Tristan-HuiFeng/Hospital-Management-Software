﻿using Hospital_Management_Software.MyDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Hospital_Management_Software.HealthProfessional
{
    public partial class MedicalRecordList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            DataTable dt = new DataTable();

            dt.Columns.Add("date", typeof(string));
            dt.Columns.Add("patientFullName", typeof(string));
            dt.Columns.Add("doctorFullName", typeof(string));
            dt.Columns.Add("diagnosis", typeof(string));


            for (int i = 0; i<12; i++)
            {
                DataRow NewRow = dt.NewRow();
                NewRow[0] = "12/12/2000";
                NewRow[1] = "Alex Lim";
                NewRow[2] = "Edward Jenner";
                NewRow[3] = "Farby Disease";
                dt.Rows.Add(NewRow);
            }*/


            GetMedicalData();
        }

        private void GetMedicalData()
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();

            DataTable dt = client.GetMedicalRecordTableView();

            gv_MedicalRecordList.DataSource = dt;
            gv_MedicalRecordList.DataBind();
        }

        protected void btn_createMedicalRecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateMedicalRecord.aspx");
        }

        protected void gv_MedicalRecordList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_MedicalRecordList.SelectedRow;
            Session["Medical_Record_ID"] = row.Cells[1].Text;
            Response.Redirect("ViewMedicalRecord.aspx");
        }

        protected void gv_MedicalRecordList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();

            gv_MedicalRecordList.DataSource = client.GetMedicalRecordTableView();
            gv_MedicalRecordList.PageIndex = e.NewPageIndex;
            gv_MedicalRecordList.DataBind();
        }
    }
}