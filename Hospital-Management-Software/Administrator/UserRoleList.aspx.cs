using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WCF_Service_Library.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hospital_Management_Software.Administrator
{
    public partial class RoleList : System.Web.UI.Page
    {
        private string role_id;
        private WCF_Service_Library.Entity.Role myRole = new WCF_Service_Library.Entity.Role();

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
                    if (Session["Role_ID"] != null)
                    {
                        lb_debugger.Visible = false;
                        lb_message.Visible = false;
                        role_id = Session["Role_ID"].ToString();

                        GetRoleDetails(role_id);

                        Session["Role_ID"] = null;
                        Session.Remove("Role_ID");
                        GetTableData(role_id);

                    }
                    else
                    {
                        Response.Redirect("Role.aspx");
                    }*/
                    lb_debugger.Visible = false;
                    lb_message.Visible = false;
                    string role_name = Request.QueryString["RoleName"];
                    if (role_name != null)
                    {
                        var roleStore = new RoleStore<IdentityRole>();
                        var roleMgr = new RoleManager<IdentityRole>(roleStore);

                        string role_id = roleMgr.FindByName(role_name).Id;
                        GetRoleDetails(role_id);
                        GetTableData(role_id);
                    }
                    else
                    {
                        //lb_debugger.Visible = true;
                        //lb_debugger.Text = "Error, no role selected";
                        Response.Redirect("Role.aspx");
                    }


                }

            }


        }

        private void GetRoleDetails(string role_id)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();

            myRole = client.GetRoleByID(role_id);

            lb_role_id.Text = myRole.ID;

        }


        private void GetTableData(string role_id)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();

            DataTable dt = client.GetRoleUserListTableView(role_id);

            gv_roleUserList.DataSource = dt;
            gv_roleUserList.DataBind();
        }

        protected void gv_roleUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_roleUserList.SelectedRow;
            //Session["User_ID"] = row.Cells[1].Text;
            //Response.Redirect("UserAccountInformation.aspx");

            Response.Redirect("UserAccountInformation.aspx?UserId=" + row.Cells[1].Text);

        }

        /*
        protected void btn_toggleStatus_Click(object sender, EventArgs e)
        {
            lb_debugger.Text = "HELLLO";
            lb_debugger.Visible = true;
            
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();

/

            GetRoleDetails(role_id);
            
        }*/
    }
}