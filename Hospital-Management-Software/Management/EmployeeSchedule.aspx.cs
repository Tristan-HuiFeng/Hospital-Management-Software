using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_Software.Management
{
    public partial class EmployeeSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("Status", typeof(String)));

            for (int i = 0; i < 15; i++)
            {
                dr = dt.NewRow();
                dr[0] = "Pierre Gasly";
                dt.Rows.Add(dr);
            }

            //Show the DataTable values in the GridView

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 3 || DropDownList1.SelectedIndex == 6)
            {
                TextBox4.Enabled = true;
            } else
            {
                TextBox4.Enabled = false;
            }
        }
    }
}