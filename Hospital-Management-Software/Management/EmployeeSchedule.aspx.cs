using Hospital_Management_Software.MyDBServiceReference;
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
        static DateTime _date;
        protected void Page_Load(object sender, EventArgs e)
        {

            //DataTable dt = new DataTable();
            //DataRow dr;
            //dt.Columns.Add(new System.Data.DataColumn("Status", typeof(String)));

            //for (int i = 0; i < 15; i++)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "Pierre Gasly";
            //    dt.Rows.Add(dr);
            //}

            ////Show the DataTable values in the GridView

            //GridView1.DataSource = dt;
            //GridView1.DataBind();

            if (!IsPostBack)
            {
                List<Employee> eList = new List<Employee>();
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                eList = client.GetAllEmployee().ToList<Employee>();
                GridView1.Visible = true;
                GridView1.DataSource = eList;
                GridView1.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedIndex == 3 || ddlStatus.SelectedIndex == 6)
            {
                tbReason.Enabled = true;
            } else
            {
                tbReason.Enabled = false;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Calendar1.SelectedDate);
            _date = Calendar1.SelectedDate;
            if (Session["SSnric"] == null)
            {
                Label1.Text = "Please choose person!";
            } else
            {
                System.Diagnostics.Debug.WriteLine(Session["SSnric"].ToString());
                loadSchedule(Calendar1.SelectedDate);
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            Session["SSnric"] = btn.CommandArgument;
            Response.Redirect(Page.Request.Url.ToString(), true);
            //Response.Redirect("ModifyEmployee?nric=" + btn.CommandArgument);
        }

        void loadSchedule(DateTime date)
        {
            tbReason.Text = "";
            if (Session["SSnric"].ToString().Length > 1)
            {
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                string empid = client.GetEmployeeID(Session["SSnric"].ToString());
                List<Employee> eList = new List<Employee>();
                eList = client.GetEmployeeByID(empid).ToList<Employee>();
                List<AttendanceRecord> arList = new List<AttendanceRecord>();
                arList = client.GetAttendanceByIDWithDate(empid, date).ToList<AttendanceRecord>();
                if (date < DateTime.Now)
                {
                    ddlStatus.SelectedIndex = 1;
                } else
                {
                    ddlStatus.SelectedIndex = 0;
                }
                if (arList.Count >= 1)
                {
                    //tbDate.Text = date.ToShortDateString();
                    tbReason.Text = arList[0].reason;

                    // Check with ddl
                    switch (arList[0].status.ToLower())
                    {
                        case "coming to work":
                            ddlStatus.SelectedIndex = 0;
                            break;
                        case "came to work":
                            ddlStatus.SelectedIndex = 1;
                            break;
                        case "non-work day":
                            ddlStatus.SelectedIndex = 2;
                            break;
                        case "did not come":
                            ddlStatus.SelectedIndex = 3;
                            break;
                        case "taken leave":
                            ddlStatus.SelectedIndex = 4;
                            break;
                        case "vacation":
                            ddlStatus.SelectedIndex = 5;
                            break;
                        case "other":
                            ddlStatus.SelectedIndex = 6;
                            break;
                    }
                }
                tbName.Text = eList[0].FirstName + " " + eList[0].LastName;

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["SSnric"] != null || _date != null)
            {
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                string empID = client.GetEmployeeID(Session["SSnric"].ToString());

                List<AttendanceRecord> arList = new List<AttendanceRecord>();
                arList = client.GetAttendanceByIDWithDate(empID, _date).ToList<AttendanceRecord>();
                if (arList.Count >= 1)
                {
                    client.UpdateByIDWithDate(empID, _date, ddlStatus.SelectedItem.Text, tbReason.Text);
                } else
                {
                    client.CreateAttendance(empID, _date.ToShortDateString(), ddlStatus.SelectedItem.Text, tbReason.Text);
                }
            }
        }
    }
}