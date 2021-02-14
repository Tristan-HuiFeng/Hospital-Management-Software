using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Data;

namespace Hospital_Management_Software.Controller
{
    public class SendGrid
    {
        public static async Task Send_Email(string emailSubject, string emailBody, string target)
        {
            MyDBServiceReference.Service1Client dbClient = new MyDBServiceReference.Service1Client();

            var apiKey = "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";
            var client = new SendGridClient(apiKey);

            List<EmailAddress> myEmailList = new List<EmailAddress>();

            DataTable getListFromDB = dbClient.GetEmailList(target);

            foreach (DataRow row in getListFromDB.Rows)
            {
                myEmailList.Add(new EmailAddress(row["Email"].ToString(), row["Name"].ToString()));
            }

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
                       Tos = myEmailList
                    }
                }
            };

            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);


        }
    }
}