using Hospital_Management_Software.MyDBServiceReference;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_Software.Management
{
    public partial class ViewContracts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string aspnetid = "";
            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0"); // Proxies.
            bool auth = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if (!auth)
            {
                Response.Redirect("~/Login/StaffLogin.aspx");
            }
            //else if (!System.Web.HttpContext.Current.User.IsInRole("HR"))
            //{
            //    Response.Redirect("~/ErrorPage/UnauthorisedAccess.aspx");
            //}
            else
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);

                aspnetid = userManager.FindByName(System.Web.HttpContext.Current.User.Identity.Name).Id;
            }

            if (!IsPostBack)
            {
                List<ContractRecord> crList = new List<ContractRecord>();
                List<Employee> eList = new List<Employee>();
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                eList = client.SelectByASPNETID(aspnetid).ToList<Employee>();
                crList = client.GetContractByEmployeeID(client.GetEmployeeID(eList[0].Nric)).ToList<ContractRecord>();
                GridView1.Visible = true;
                GridView1.DataSource = crList;
                GridView1.DataBind();
            }
        }

        protected void btnContract_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            Response.Redirect("CanvasTest?id=" + btn.CommandArgument);
        }
    }
}