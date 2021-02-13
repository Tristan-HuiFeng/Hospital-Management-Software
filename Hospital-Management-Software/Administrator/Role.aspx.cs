using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hospital_Management_Software.Administrator
{
    public partial class Role : System.Web.UI.Page
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

                updateRoleTable();
            }

        }

        private void updateRoleTable()
        {

            var roleStore = new RoleStore<IdentityRole>();
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roles = roleManager.Roles.ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Role_Name");
            dt.Columns.Add("Role_ID");
            //dt.Columns.Add("num_user");
            //dt.Columns.Add("status");

            foreach (var role in roles)
            {
                var dr = dt.NewRow();
                dr["Role_Name"] = role.Name;
                dr["Role_ID"] = role.Id;
                //dr["num_user"] = "N/A";
                // dr["status"] = "Active";
                dt.Rows.Add(dr);
            }

            gv_role.DataSource = dt;
            gv_role.DataBind();

        }

        protected void btn_createRole_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {

                lb_debugger.Visible = false;
                lb_message.Visible = false;

                var roleStore = new RoleStore<IdentityRole>();
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var roles = roleManager.Roles.ToList();


                try
                {


                    IdentityResult IdRoleResult = roleManager.Create(new IdentityRole { Name = HttpUtility.HtmlEncode(tb_newRoleName.Text) });

                    if (IdRoleResult.Succeeded)
                    {
                        lb_message.Visible = true;
                        lb_message.Text = string.Format("Role '{0}' has been created!", HttpUtility.HtmlEncode(tb_newRoleName.Text));
                        tb_newRoleName.Text = "";
                        updateRoleTable();
                    }
                    else
                    {
                        lb_debugger.Text = "";

                        lb_debugger.Visible = true;
                        foreach (var error in IdRoleResult.Errors)
                        {
                            lb_debugger.Text += error;
                            lb_debugger.Text += "\n";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lb_debugger.Visible = true;
                    lb_debugger.Text = ex.ToString();
                }

            }
        }

        protected void gv_role_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = gv_role.SelectedRow;
            //Session["Role_ID"] = row.Cells[1].Text;
            //Response.Redirect("UserRoleList.aspx");
            Response.Redirect("UserRoleList.aspx?RoleName=" + row.Cells[0].Text);

        }

        protected void CustomersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "DeleteRole")
            {
                var roleStore = new RoleStore<IdentityRole>();
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gv_role.Rows[index];

                var myRole = roleManager.FindById(row.Cells[1].Text);

                IdentityResult deleteRoleResult = roleManager.Delete(myRole);

                if (deleteRoleResult.Succeeded)
                {
                    lb_message.Visible = true;
                    lb_message.Text = string.Format("Role '{0}' has been deleted!", row.Cells[0].Text);
                }
                else
                {
                    lb_debugger.Text = "";

                    lb_debugger.Visible = true;
                    foreach (var error in deleteRoleResult.Errors)
                    {
                        lb_debugger.Text += error;
                        lb_debugger.Text += "\n";
                    }
                }

                updateRoleTable();

            }

            /*
            if (e.CommandName == "ToggleRole")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gv_role.Rows[index];
                lb_message.Visible = true;
                lb_message.Text = row.Cells[1].Text + row.Cells[2].Text;

                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();

                if (row.Cells[2].Text == "Active")
                {
                    client.updateRoleStatus(row.Cells[1].Text, true);
                }
                else
                {
                    client.updateRoleStatus(row.Cells[1].Text, false);
                }

                updateRoleTable();

            }*/

        }


    }
}