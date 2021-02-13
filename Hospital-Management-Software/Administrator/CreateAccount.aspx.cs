using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hospital_Management_Software.Administrator
{
    public partial class CreateAccount : System.Web.UI.Page
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



                string emp_id = Request.QueryString["EmpID"];
                if (emp_id != null)
                {
                    getUserDetail(emp_id);
                    setDropdownRoleList();
                }
                else
                {
                    //lb_debugger.Visible = true;
                    //lb_debugger.Text = "Error, no user selected";
                    Response.Redirect("NoAccountList.aspx");
                }
            }


        }

        private void setDropdownRoleList()
        {

            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            List<WCF_Service_Library.Entity.Role> myRoleList = new List<WCF_Service_Library.Entity.Role>();
            myRoleList = client.GetRoleList2().ToList<WCF_Service_Library.Entity.Role>();

            foreach (var tempRole in myRoleList)
            {
                ddl_roleList.Items.Add(new ListItem(tempRole.name, tempRole.ID));
            }


        }

        private void getUserDetail(string emp_id)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();

            string[] accountInfo = new string[4];

            accountInfo = client.creationDetailsByEmpID(emp_id);

            lb_name.Text = accountInfo[0];
            lb_empId.Text = accountInfo[1];
            lb_department.Text = accountInfo[2];
            lb_email.Text = accountInfo[3];

        }

        protected void btn_createAccount_Click(object sender, EventArgs e)
        {

            var roleStore = new RoleStore<IdentityRole>();
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser() { UserName = HttpUtility.HtmlEncode(tb_username.Text) };
            IdentityResult result = userManager.Create(user, HttpUtility.HtmlEncode(tb_password.Text));

            if (!result.Succeeded)
            {
                lb_message.Text = result.Errors.FirstOrDefault();
            }

            IdentityResult IdRoleResult = userManager.AddToRole(user.Id, roleMgr.FindById(ddl_roleList.SelectedValue).Name);

            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            client.updateAccountCreationDetails(user.Id, lb_empId.Text);

            if (!IdRoleResult.Succeeded)
            {
                lb_message.Text += "\n" + result.Errors.FirstOrDefault();
            }

            if (IdRoleResult.Succeeded && result.Succeeded)
            {
                Session["msg"] = string.Format("User '{0}' has been created and assigned to the role '{1}'", user.UserName, roleMgr.FindById(ddl_roleList.SelectedValue).Name);
                Response.Redirect("NoAccountList.aspx");
            }




        }


    }
}