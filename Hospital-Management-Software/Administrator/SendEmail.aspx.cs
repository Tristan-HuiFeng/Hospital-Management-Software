using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using WCF_Service_Library.Entity;
using System.Data;

namespace Hospital_Management_Software.Administrator
{
    public partial class SendEmail : System.Web.UI.Page
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
                lb_message.Visible = false;
                lb_debugger.Visible = false;
            }

            //Send_Email("FINAL", "this is bodffffy", "0").Wait();

        }
        /*
        static async Task Send_Email2(string emailSubject, string emailBody)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);

            //var from = new EmailAddress("user.ad.proj@gmail.com", "LGH - Admin");
            //var to = new EmailAddress("test@example.com", "Example User");

            //var subject = "Hello";
            //var plainTextContent = "what is this";
            //var htmlContent = "<strong>even with C#</strong>";

            //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("user.ad.proj@gmail.com", "LGH - Admin"),
                Subject = emailSubject,
                PlainTextContent = emailBody,
                HtmlContent = emailBody,
                Personalizations = new List<Personalization>
                {
                    new Personalization
                    {
                        Tos = new List<EmailAddress>
                        {
                            new EmailAddress("user.cust.proj@gmail.com", "Test User1"),
                            new EmailAddress("tristan.chf@gmail.com", "test user 2")
                        }
                    }
                }
            };
            msg.AddTo(new EmailAddress("user.cust.proj@gmail.com", "Test User1"));
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);

        }*/

        protected void btn_sendEmail_Click(object sender, EventArgs e)
        {
            
            Page.Validate();
            if (Page.IsValid)
            {
                lb_message.Text = "Email has been sent";
                lb_message.Visible = true;
                Controller.SendGrid.Send_Email(tb_emailSubject.Text,
                              tb_emailBody.Text,
                              ddl_emailTarget.SelectedValue).Wait();


                tb_emailSubject.Text = "";
                tb_emailBody.Text = "";
            }
            else
            {
                lb_debugger.Text = "All fields must be filled up";
                lb_debugger.Visible = true;
            }
            /*
            MyDBServiceReference.Service1Client dbClient = new MyDBServiceReference.Service1Client();
            lb_debugger.Visible = true;

            DataTable getListFromDB = dbClient.GetEmailList("0");
            lb_debugger.Text = "";
            foreach (DataRow row in getListFromDB.Rows)
            {

                lb_debugger.Text += row["Email"].ToString() + " " + row["Name"].ToString() + "\n";
            }*/


        }
    }
}