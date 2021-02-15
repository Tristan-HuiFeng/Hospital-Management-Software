using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Hospital_Management_Software.Customer
{
    public partial class allFeedbackAdmin : System.Web.UI.Page
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
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            string message = "Are you sure you resolved these feedback?";
            string title = "Resolved feedback";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                // if yes, delete record and refresh the page
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            //else
            //{
            //    // Do something  
            //}

            //foreach (GridViewRow gvrow in GridView1.Rows)
            //{

            //    CheckBox chck = gvrow.FindControl("CheckBox1") as CheckBox;
            //    if (chck.Checked)
            //    {

            //    }
            //}
        }
    }
}