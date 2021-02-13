using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Hospital_Management_Software.Administrator
{
    public partial class CreateAcount : System.Web.UI.Page
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
                lb_message.Visible = false;
                getNoAccountUser();

                if (Session["msg"] != null)
                {
                    lb_message.Visible = true;
                    lb_message.Text = Session["msg"].ToString();
                    Session["msg"] = null;
                    Session.Remove("msg");

                }

            }

        }

        private void getNoAccountUser()
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();

            DataTable dt = client.GetNoAccUserList_TableView();
            gv_userNoAccList.DataSource = dt;
            gv_userNoAccList.DataBind();
        }

        protected void gv_userNoAccList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_userNoAccList.SelectedRow;
            Response.Redirect("CreateAccount.aspx?EmpID=" + row.Cells[1].Text);

        }
    }
}