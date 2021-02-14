using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_Software.Customer
{
    public partial class homepage : System.Web.UI.Page
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
                else
                {
                    string userid = Session["LoggedIn"].ToString();
                    if (checkApptTime(userid) != null)
                    {
                        lbl_Appt.Visible = true;
                        lbl_noAppt.Visible = false;
                        string apptTime = checkApptTime(userid).ToString();
                        string apptReason = checkApptReason(userid).ToString();
                        lblAppointments.Text = "You have an appointment at " + apptTime + " for a " + apptReason;
                        lblAppointments.Visible = true;
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void MakeAppt(object sender, EventArgs e)
        {
            Response.Redirect("makeAppointment.aspx", false);
        }

        protected void logout(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            Response.Redirect("login.aspx", false);

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
            }

            if (Request.Cookies["AuthToken"] != null)
            {
                Response.Cookies["AuthToken"].Value = string.Empty;
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
            }
        }

        protected string checkApptTime(string userid)
        {
            string h = null;
            SqlConnection connection = new SqlConnection(MyDBConnectionString);
            string sql = "select Appt_Time from PATIENT where nric = @USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);

            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["Appt_Time"] != null)
                        {
                            if (reader["Appt_Time"] != DBNull.Value)
                            {
                                h = reader["Appt_Time"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { connection.Close(); }
            return h;
        }

        protected string checkApptReason(string userid)
        {
            string h = null;
            SqlConnection connection = new SqlConnection(MyDBConnectionString);
            string sql = "select Appt_Reason from PATIENT where nric = @USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);

            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["Appt_Reason"] != null)
                        {
                            if (reader["Appt_Reason"] != DBNull.Value)
                            {
                                h = reader["Appt_Reason"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { connection.Close(); }
            return h;
        }
    }
}