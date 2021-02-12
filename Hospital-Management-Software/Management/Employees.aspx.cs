using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_Software
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("Status", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("First Name", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Last Name", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("E-mail", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Gender", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Location", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Date of Birth", typeof(String)));

            for (int i = 0; i < 15; i++)
            {
                dr = dt.NewRow();
                dr[0] = "Available";
                dr[1] = "Pierre";
                dr[2] = "Gasly";
                dr[3] = "pierregasly@alphatauri.com";
                dr[4] = "Male";
                dr[5] = "France";
                dr[6] = "7 February 1996";
                dt.Rows.Add(dr);
            }

            //Show the DataTable values in the GridView

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}