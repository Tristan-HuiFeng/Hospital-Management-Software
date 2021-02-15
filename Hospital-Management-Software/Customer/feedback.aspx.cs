using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_Software.Customer
{
    public partial class feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(tbFeedback.Text)) | (string.IsNullOrEmpty(tbEmail.Text)) | (string.IsNullOrEmpty(tbSubject.Text)) | chkPublic.Checked == false)
            {
                errorMsg.Text = "Please fill in fields indicated with a * and agree to the terms and conditions!";
                errorMsg.ForeColor = System.Drawing.Color.Red;
                errorMsg.Visible = true;
            }
            else
            {
                if (ValidateCaptcha())
                {
                    MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                    int result = client.CreateFeedback(tbName.Text, tbEmail.Text, tbSubject.Text, tbFeedback.Text);
                    Response.Redirect("success.aspx");
                }
                else
                {
                    errorMsg.Text = "Please try again later!";
                    errorMsg.ForeColor = System.Drawing.Color.Red;
                    errorMsg.Visible = true;
                }
            }
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
    }
}