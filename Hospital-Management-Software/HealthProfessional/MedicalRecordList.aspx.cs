//using Hospital_Management_Software.MyDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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
                GetMedicalData();
            }

        }

        private void GetMedicalData()
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();

            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            int doctor_id = client.GetEmpIDByAccID(userManager.FindByName(System.Web.HttpContext.Current.User.Identity.Name).Id);
            DataTable dt = client.GetMedicalRecordTableView(doctor_id);

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
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            int doctor_id = client.GetEmpIDByAccID(userManager.FindByName(System.Web.HttpContext.Current.User.Identity.Name).Id);

            gv_MedicalRecordList.DataSource = client.GetMedicalRecordTableView(doctor_id);
            gv_MedicalRecordList.PageIndex = e.NewPageIndex;
            gv_MedicalRecordList.DataBind();
        }
    }
}