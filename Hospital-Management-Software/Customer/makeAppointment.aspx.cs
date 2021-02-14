using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_Software.Customer
{
    public partial class makeAppointment : System.Web.UI.Page
    {
        string MyDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void btnSubmit(object sender, EventArgs e)
        {
            if (DDL_reason.SelectedValue == "Please select a reason!" | DDL_time.SelectedValue == "Please select a time!") 
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                string userid = Session["LoggedIn"].ToString();
                makeAppt(userid);
                Response.Redirect("homepage.aspx", false);
            }
        }

        protected void btnCancel(object sender, EventArgs e)
        {
            Response.Redirect("homepage.aspx", false);
        }

        public void makeAppt(string userid)
        {
            string s = null;
            SqlConnection connection = new SqlConnection(MyDBConnectionString);
            string sql = "UPDATE PATIENT SET Appt_Reason = @Appt_Reason, Appt_Time = @Appt_Time WHERE nric = @USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);
            command.Parameters.AddWithValue("@Appt_Reason", DDL_reason.SelectedValue.ToString());
            command.Parameters.AddWithValue("@Appt_Time", DDL_time.SelectedValue.ToString());
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}