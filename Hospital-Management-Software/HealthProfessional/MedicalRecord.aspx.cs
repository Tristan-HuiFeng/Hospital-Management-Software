﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Hospital_Management_Software.HealthProfessional
{
    public partial class MedicalRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            }
            
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

    }
}