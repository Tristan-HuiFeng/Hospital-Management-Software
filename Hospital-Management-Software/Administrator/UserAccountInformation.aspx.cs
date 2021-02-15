using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCF_Service_Library.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Drawing;

namespace Hospital_Management_Software.Administrator
{
    public partial class UserAccountInformation : System.Web.UI.Page
    {
        //private string role_id;

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

                if (!IsPostBack)
                {
                    /*
                    if (Session["User_ID"] != null)
                    {
                        lb_debugger.Visible = false;
                        lb_message.Visible = false;
                        role_id = Session["User_ID"].ToString();

                        getUserDetail(role_id);

                        Session["User_ID"] = null;
                        Session.Remove("User_ID");
                        //GetTableData(role_id);
                        setDropdownRoleList();

                    }
                    else
                    {
                        Response.Redirect("Role.aspx");
                    }*/

                    lb_debugger.Visible = false;
                    lb_message.Visible = false;
                    lb_passwordResult.Visible = false;
                    string user_id = Request.QueryString["UserId"];
                    if (user_id != null)
                    {

                        getUserDetail(user_id);
                        setDropdownRoleList();
                    }
                    else
                    {
                        /*
                        lb_debugger.Visible = true;
                        lb_debugger.Text = "Error, no user selected";*/
                        Response.Redirect("Role.aspx");
                    }
                }
            }

        }

        private void setDropdownRoleList()
        {

            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            List<Role> myRoleList = new List<Role>();
            myRoleList = client.GetRoleList2().ToList<Role>();

            foreach (var tempRole in myRoleList)
            {
                ddl_roleList.Items.Add(new ListItem(tempRole.name, tempRole.ID));
            }


        }

        private void getUserDetail(string user_id)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            UserAccount myUserAccount = client.GetUserAccountByID(user_id);

            lb_roleID.Text = myUserAccount.role_id;
            lb_roleName.Text = myUserAccount.role_name;

            lb_userID.Text = myUserAccount.user_id;
            lb_userName.Text = myUserAccount.name;

            lb_position.Text = myUserAccount.position;
            lb_department.Text = myUserAccount.department;

            lb_status.Text = myUserAccount.status;

            if (myUserAccount.status == "Active")
            {
                btn_toggleStatus.Text = "Disable User";
            }
            else
            {
                btn_toggleStatus.Text = "Enable User";
            }


        }

        protected void btn_changeRole_Click(object sender, EventArgs e)
        {
            /*
            lb_message.Text = ddl_roleList.SelectedValue + ddl_roleList.SelectedIndex;
            lb_message.Visible = true;

            lb_debugger.Text = ddl_roleList.SelectedValue + "\n" + lb_roleID.Text;
            lb_debugger.Visible = true;*/

            if (ddl_roleList.SelectedValue == lb_roleID.Text)
            {
                lb_message.Text = string.Format("User has already been assigned to {0}", lb_roleName.Text);
                lb_message.Visible = true;
            }
            else
            {

                lb_debugger.Text = "";

                var roleStore = new RoleStore<IdentityRole>();
                var roleMgr = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<IdentityUser>();
                var manager = new UserManager<IdentityUser>(userStore);


                IdentityResult removeRoleResult = manager.RemoveFromRole(lb_userID.Text, roleMgr.FindById(lb_roleID.Text).Name);

                if (!removeRoleResult.Succeeded)
                {
                    foreach (var error in removeRoleResult.Errors)
                    {
                        lb_debugger.Text += error;
                        lb_debugger.Text += "\n";
                    }
                }

                IdentityResult IdRoleResult = manager.AddToRole(lb_userID.Text, roleMgr.FindById(ddl_roleList.SelectedValue).Name);


                if (IdRoleResult.Succeeded)
                {
                    lb_message.Text = string.Format("Role has been changed from {0} to {1}", lb_roleName.Text, roleMgr.FindById(ddl_roleList.SelectedValue).Name);
                    lb_message.Visible = true;
                }
                else
                {

                    lb_debugger.Visible = true;
                    foreach (var error in IdRoleResult.Errors)
                    {
                        lb_debugger.Text += error;
                        lb_debugger.Text += "\n";
                    }
                }

                getUserDetail(lb_userID.Text);
            }

        }

        protected void btn_toggleStatus_Click(object sender, EventArgs e)
        {

            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            bool status = false;

            if (lb_status.Text == "Active")
            {
                status = true;
            }
            //lb_message.Visible = true;
            //lb_message.Text = string.Format("Account status will now become {0}", status);
            client.updateUserAccStatus(lb_userID.Text, status);


            getUserDetail(lb_userID.Text);

        }

        protected void btn_changePassword_Click(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            var currentUser = manager.FindById(lb_userID.Text);
            manager.RemovePassword(lb_userID.Text);
            IdentityResult changePasswordResult = manager.AddPassword(lb_userID.Text, HttpUtility.HtmlEncode(tb_password.Text));

            if (changePasswordResult.Succeeded)
            {
                lb_passwordResult.Visible = true;
                lb_passwordResult.Text = "Password has been changed";
                lb_passwordResult.ForeColor = Color.Green;
            }
            else
            {
                lb_passwordResult.Visible = true;
                lb_passwordResult.Text = "";

                foreach (string error in changePasswordResult.Errors)
                {
                    lb_passwordResult.Text += error + "\n";
                }
                lb_passwordResult.ForeColor = Color.Red;
            }
        }
    }
}
