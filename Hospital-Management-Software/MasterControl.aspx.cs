using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Hospital_Management_Software
{
    public partial class MasterControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            var roleStore = new RoleStore<IdentityRole>();
            var roleMgr = new RoleManager<IdentityRole>(roleStore);
            IdentityResult IdRoleResult = roleMgr.Create(new IdentityRole { Name = "Doctor" });*/

            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            IdentityResult IdUserResult = manager.AddToRole(manager.FindByName("federickbt").Id, "Doctor");


            if (IdUserResult.Succeeded)
            {
                lb_message.Text = string.Format("User doctor has been given the role doctor!");
                lb_debugger.Text = IdUserResult.Succeeded.ToString();
            }
            else
            {
                lb_message.Text = string.Format("error");
                lb_debugger.Text = IdUserResult.Errors.ToString();
            }

        }

        protected void btn_addAdminUser_Click(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            try
            {

                var user = new IdentityUser() { UserName = "admin" };
                IdentityResult result = manager.Create(user, "123456");

                if (result.Succeeded)
                {
                    lb_message.Text = string.Format("User {0} was created successfully!", user.UserName);
                }
                else
                {
                    lb_message.Text = result.Errors.FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                lb_message.Text = ex.ToString();
            }
        }

        protected void btn_addDoctorUser_Click(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser() { UserName = "doctor" };
            IdentityResult result = manager.Create(user, "123456");

            if (result.Succeeded)
            {
                lb_message.Text = string.Format("User {0} was created successfully!", user.UserName);
            }
            else
            {
                lb_message.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}