using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Hospital_Management_Software.HealthProfessional
{
    public partial class PatientRecord : System.Web.UI.Page
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
            else if (!System.Web.HttpContext.Current.User.IsInRole("Doctor"))
            {
                Response.Redirect("~/ErrorPage/UnauthorisedAccess.aspx");
            }
            else
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("patientFullName", typeof(string));
                dt.Columns.Add("nric", typeof(string));
                dt.Columns.Add("dob", typeof(string));
                dt.Columns.Add("sex", typeof(string));
                dt.Columns.Add("allergies", typeof(string));

                for (int i = 0; i < 12; i++)
                {
                    DataRow NewRow = dt.NewRow();
                    NewRow[0] = "Alex Lim";
                    NewRow[1] = "S1234567D";
                    NewRow[2] = "24/11/1986";
                    NewRow[3] = "male";
                    NewRow[4] = "NA";
                    dt.Rows.Add(NewRow);
                }

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }



        }
    }
}