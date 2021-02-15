using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_Software.Customer
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool ValidateCaptcha()
        {
            bool result = true;

            // when user submits form, user gets a POST parameter
            // captchaResponse consists of the user click pattern
            string captchaResponse = Request.Form["g-recaptcha-response"];

            // to send a GET request to Google along with response and secret key
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.google.com/recaptcha/api/siteverify?secret=6LceN0caAAAAAP3gku-OUjJGHd2uySsq6PSrXq-u &response= " + captchaResponse);

            try
            {
                // codes to receive response in JSON format from Google server
                using (WebResponse wResponse = req.GetResponse())
                {
                    using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                    {
                        // response in JSON format
                        string jsonResponse = readStream.ReadToEnd();

                        JavaScriptSerializer js = new JavaScriptSerializer();

                        // create jsonObject to handle response
                        // deserialize json
                        MyObject jsonObject = js.Deserialize<MyObject>(jsonResponse);

                        // convert string "false" to bool false or "true" to bool true
                        result = Convert.ToBoolean(jsonObject.success);
                    }
                }
                result = true;
                return result;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        public class MyObject
        {
            public string success { get; set; }
            public List<string> ErrorMessage { get; set; }
        }

        protected void btn_Submit(object sender, EventArgs e)
        {
            if (tb_dob.Text == String.Empty || tb_nric.Text == String.Empty || chkPublic.Checked == false)
            {
                lblVerification.Visible = true;
                lblVerification.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (ValidateCaptcha())
                {            
                    string userid = tb_nric.Text.ToString().Trim();
                    string verify = getDOB(userid);
                    string dateofbirth = tb_dob.Text.ToString() + " 12:00:00 AM";

                    if (verify == null)
                    {
                        lblVerification.Text = "Your login information is wrong! Please try again!";
                        lblVerification.Visible = true;
                        lblVerification.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (verify.Equals(dateofbirth))
                    {
                        Session["LoggedIn"] = tb_nric.Text.Trim();

                        // create a new GUID and save into session
                        string guid = Guid.NewGuid().ToString();
                        Session["AuthToken"] = guid;

                        // create a new cookie with guid value
                        Response.Cookies.Add(new HttpCookie("AuthToken", guid));

                        Response.Redirect("homepage.aspx", false);
                    } else
                    {
                        lblVerification.Text = "Your login information is wrong! Please try again!";
                        lblVerification.Visible = true;
                        lblVerification.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected string getDOB(string userid)
        {
            if (userid == null)
            {
                lblVerification.Text = "Your login information is wrong! Please try again!";
                lblVerification.Visible = true;
                lblVerification.ForeColor = System.Drawing.Color.Red;
            }

            string h = null;
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\roygo\source\repos\Hospital-Management-Software\Hospital-Management-Software\App_Data\EDP_DB.mdf;Initial Catalog=MyDB;Integrated Security=True");
            string sql = "select dob FROM patient WHERE nric=@USERID";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);

            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["dob"] != null)
                        {
                            if (reader["dob"] != DBNull.Value) 
                            {
                                h = reader["dob"].ToString();
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