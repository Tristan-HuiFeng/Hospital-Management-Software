using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using WCF_Service_Library.Entity;

namespace Hospital_Management_Software.Login
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lb_loginError.Visible = false;
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

           
            if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Doctor"))
                {
                    Response.Redirect("~/HealthProfessional/MedicalRecordList.aspx");
                }
                else if (User.IsInRole("HR"))
                {
                    Response.Redirect("~/Management/Employees.aspx");
                }
                else if (User.IsInRole("Administrator"))
                {
                    Response.Redirect("~/Administrator/Role.aspx");
                }
                else
                {
                    Response.Redirect("~/HealthProfessional/Dashboard.aspx");
                }
               
            }

        }

        protected void btn_SignIn_Click(object sender, EventArgs e)
        {
            //validate_user();


            string username = HttpUtility.HtmlEncode(tb_loginID.Text);
            string password = HttpUtility.HtmlEncode(tb_password.Text);

           
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.Find(username, password);
            if (user != null)
            {
                if (userDisabled(user.Id))
                {
                    lb_loginError.Text = "Account is disabled, contact administrator";
                    lb_loginError.Visible = true;
                }
                else
                {
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                    if (User.IsInRole("Doctor"))
                    {
                        Response.Redirect("~/HealthProfessional/MedicalRecordList.aspx");
                    }
                    else if (User.IsInRole("HR"))
                    {
                        Response.Redirect("~/Management/Employees.aspx");
                    }
                    else if (User.IsInRole("Administrator"))
                    {
                        Response.Redirect("~/Administrator/Role.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/HealthProfessional/Dashboard.aspx");
                    }
                }
              
                /*
                string role = userManager.GetRoles(user.Id).FirstOrDefault();

                tb_loginID.Text = role;

                if (role == "Doctor")
                {
                    Response.Redirect("~/HealthProfessional/Dashboard.aspx");
                }
                else if (role == "HR")
                {
                    Response.Redirect("~/Management/Employees.aspx");
                }
                else if (role == "Administrator")
                {
                    Response.Redirect("~/Administrator/Role.aspx");
                }
                else if (role == "")
                {
                    //Response.Redirect("~/Administrator/Role.aspx");
                }*/


            }
            else
            {
                lb_loginError.Text = "Invalid username or password.";
                lb_loginError.Visible = true;
            }
        }

        private bool userDisabled(string user_id)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            Hospital_Management_Software.MyDBServiceReference.UserAccount myUserAccount = client.GetUserAccountByID(user_id);


            if (myUserAccount.status == "Active")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /*
        private bool validate_user()
        {
            string username = HttpUtility.HtmlEncode(tb_loginID.Text);
            string password = HttpUtility.HtmlEncode(tb_password.Text);
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();

            string[] accountInformation = new string[2];
            accountInformation = client.GetAccountInformation(username);

            
            if(accountInformation[0] != username || accountInformation[1] != password)
            {
                lb_loginError.Text = "Invalid Login Credentials. Pleae try again";
                lb_loginError.Visible = true;
            }

            return false;

        }*/
    }
}