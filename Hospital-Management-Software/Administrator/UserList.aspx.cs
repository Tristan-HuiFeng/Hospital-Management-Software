using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Hospital_Management_Software.Administrator
{
    public partial class UserList : System.Web.UI.Page
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
            else if (!System.Web.HttpContext.Current.User.IsInRole("Administrator"))
            {
                Response.Redirect("~/ErrorPage/UnauthorisedAccess.aspx");
            }
            else
            {
                lb_debugger.Visible = false;
                getUserList();

              
            }
        }

        private void getUserList()
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();

            DataTable dt = client.getAccountList();
            gv_userList.DataSource = dt;
            gv_userList.DataBind();
        }

        [WebMethod]
        public static string populateTable()
        {

            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();

            DataTable dt = client.getAccountList();
            /*
            dt.Columns.Add("AccountID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Role", typeof(string));
            dt.Columns.Add("Department", typeof(string));

            for (int i = 0; i < 2; i++)
            {
                DataRow NewRow = dt.NewRow();
                NewRow[0] = "MINH HIEU";
                NewRow[1] = "S1234567D";
                NewRow[2] = "HEHEHEH";
                NewRow[3] = "HOOHOHO";
                dt.Rows.Add(NewRow);
            }*/

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);
            Debug.Write(JSONString);
            return JSONString;
        }
    }
}