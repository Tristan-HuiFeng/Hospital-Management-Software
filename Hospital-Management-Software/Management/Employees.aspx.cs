//using Hospital_Management_Software.MyDBServiceReference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCF_Service_Library.Entity;

namespace Hospital_Management_Software
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //DataRow dr;
            //dt.Columns.Add(new System.Data.DataColumn("Status", typeof(String)));
            //dt.Columns.Add(new System.Data.DataColumn("First Name", typeof(String)));
            //dt.Columns.Add(new System.Data.DataColumn("Last Name", typeof(String)));
            //dt.Columns.Add(new System.Data.DataColumn("E-mail", typeof(String)));
            //dt.Columns.Add(new System.Data.DataColumn("Gender", typeof(String)));
            //dt.Columns.Add(new System.Data.DataColumn("Location", typeof(String)));
            //dt.Columns.Add(new System.Data.DataColumn("Date of Birth", typeof(String)));

            //for (int i = 0; i < 15; i++)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "Available";
            //    dr[1] = "Pierre";
            //    dr[2] = "Gasly";
            //    dr[3] = "pierregasly@alphatauri.com";
            //    dr[4] = "Male";
            //    dr[5] = "France";
            //    dr[6] = "7 February 1996";
            //    dt.Rows.Add(dr);
            //}

            //Show the DataTable values in the GridView
            if (!IsPostBack)
            {
                List<Employee> eList = new List<Employee>();
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                eList = client.GetAllEmployee().ToList<Employee>();
                GridView1.Visible = true;
                GridView1.DataSource = eList;
                GridView1.DataBind();
            }

            //System.Diagnostics.Debug.WriteLine(eList[0].FirstName);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<Employee> eList = new List<Employee>();
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            eList = client.GetEmployeeByName(tbSearch.Text).ToList<Employee>();
            GridView1.Visible = true;
            GridView1.DataSource = eList;
            GridView1.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            List<Employee> eList = new List<Employee>();
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            switch (ddlFilter.SelectedIndex)
            {
                case 1:
                    eList = client.GetEmployeeSortedByGender(ddlOrder.SelectedIndex).ToList<Employee>();
                    break;
                case 2:
                    eList = client.GetEmployeeSortedByDOB(ddlOrder.SelectedIndex).ToList<Employee>();
                    break;
            }
            GridView1.Visible = true;
            GridView1.DataSource = eList;
            GridView1.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            Response.Redirect("ModifyEmployee?nric=" + btn.CommandArgument);
        }

        protected void btnContract_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            List<Employee> eList = new List<Employee>();
            List<ContractRecord> crList = new List<ContractRecord>();
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            crList = client.GetContractByEmployeeID(client.GetEmployeeID(btn.CommandArgument)).ToList<ContractRecord>();

            if (crList.Count < 1)
            {
                Response.Redirect("AddContract?nric=" + btn.CommandArgument);
            } else
            {
                Response.Redirect("Contract?nric=" + btn.CommandArgument);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            List<Employee> eList = new List<Employee>();
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            eList = client.GetAllEmployee().ToList<Employee>();
            GridView1.Visible = true;
            GridView1.DataSource = eList;
            GridView1.DataBind();
        }

        protected void btnResetFilter_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            ddlFilter.SelectedIndex = 0;
            ddlOrder.SelectedIndex = 0;

            List<Employee> eList = new List<Employee>();
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            eList = client.GetAllEmployee().ToList<Employee>();
            GridView1.Visible = true;
            GridView1.DataSource = eList;
            GridView1.DataBind();
        }
    }
}