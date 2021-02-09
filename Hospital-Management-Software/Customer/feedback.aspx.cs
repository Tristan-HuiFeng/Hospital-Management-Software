using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if ((string.IsNullOrEmpty(tbFeedback.Text)) | (string.IsNullOrEmpty(tbEmail.Text)) | (string.IsNullOrEmpty(tbSubject.Text)))
            {
                errorMsg.Text = "Please fill in required fields!";
                errorMsg.ForeColor = System.Drawing.Color.Red;
                errorMsg.Visible = true;
                errorSubj.Text = "This is a required field.";
                errorSubj.ForeColor = System.Drawing.Color.Red;
                errorSubj.Visible = true;
                errorFeedback.Text = "This is a required field.";
                errorFeedback.ForeColor = System.Drawing.Color.Red;
                errorFeedback.Visible = true;
                errorEmail.Text = "This is a required field.";
                errorEmail.ForeColor = System.Drawing.Color.Red;
                errorEmail.Visible = true;
            }
            else
            {
                MyDBServiceReference.Service1Client client= new MyDBServiceReference.Service1Client();
                int result = client.CreateFeedback(tbName.Text, tbEmail.Text, tbSubject.Text, tbFeedback.Text);
                Response.Redirect("success.aspx");
            }
        }
    }
}