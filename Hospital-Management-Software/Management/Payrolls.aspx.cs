using Hospital_Management_Software.MyDBServiceReference;
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

            //DataTable dt = new DataTable();
            //DataRow dr;
            //dt.Columns.Add(new System.Data.DataColumn("Date", typeof(String)));
            //dt.Columns.Add(new System.Data.DataColumn("Status", typeof(String)));
            //dt.Columns.Add(new System.Data.DataColumn("Name", typeof(String)));
            //dt.Columns.Add(new System.Data.DataColumn("Bank", typeof(String)));
            //dt.Columns.Add(new System.Data.DataColumn("Email/Printed", typeof(String)));
            //for (int i = 0; i < 15; i++)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "25/11/2020";
            //    dr[1] = "Processed";
            //    dr[2] = "Pierre Gasly";
            //    dr[3] = "POSB";
            //    dr[4] = "Email";
            //    dt.Rows.Add(dr);
            //}

            ////Show the DataTable values in the GridView

            //GridView1.DataSource = dt;
            //GridView1.DataBind();

            if (!IsPostBack)
            {
                List<PayrollRecord> eList = new List<PayrollRecord>();
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                eList = client.GetAllPayroll().ToList<PayrollRecord>();
                GridView1.Visible = true;
                GridView1.DataSource = eList;
                GridView1.DataBind();
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            Response.Redirect("ProcessPayroll?id=" + btn.CommandArgument);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            List<PayrollRecord> eList = new List<PayrollRecord>();
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            eList = client.GetAllPayroll().ToList<PayrollRecord>();
            GridView1.Visible = true;
            GridView1.DataSource = eList;
            GridView1.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbFirstDate.Text) && !string.IsNullOrEmpty(tbSecondDate.Text))
            {
                List<PayrollRecord> prList = new List<PayrollRecord>();
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                prList = client.GetPayrollBetweenDate(tbFirstDate.Text, tbSecondDate.Text).ToList<PayrollRecord>();
                GridView1.Visible = true;
                GridView1.DataSource = prList;
                GridView1.DataBind();
            }
        }
    }
}