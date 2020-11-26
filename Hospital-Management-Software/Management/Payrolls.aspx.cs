using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_Software
{
    public partial class Payrolls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("Date", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Status", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Name", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Bank", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Email/Printed", typeof(String)));
            for (int i = 0; i < 15; i++)
            {
                dr = dt.NewRow();
                dr[0] = "25/11/2020";
                dr[1] = "Processed";
                dr[2] = "Pierre Gasly";
                dr[3] = "POSB";
                dr[4] = "Email";
                dt.Rows.Add(dr);
            }

            //Show the DataTable values in the GridView

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}