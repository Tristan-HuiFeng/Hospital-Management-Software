//using Hospital_Management_Software.MyDBServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCF_Service_Library.Entity;

namespace Hospital_Management_Software.Management
{
    [ScriptService]
    public partial class CanvasTest : System.Web.UI.Page
    {
        static string path;
        protected void Page_Load(object sender, EventArgs e)
        {
            // CHANGE NRIC HERE
            string nric = "T0000000D";
            //_nric = nric;
            if (nric != null)
            {
                List<Employee> eList = new List<Employee>();
                List<ContractRecord> crList = new List<ContractRecord>();
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                eList = client.GetEmployeeByNRIC(nric).ToList<Employee>();
                lbEmployeeID.Text = client.GetEmployeeID(nric);
                lbEmployeeName.Text = eList[0].FirstName + " " + eList[0].LastName;
                lbEmail.Text = eList[0].Email;
                lbDepartment.Text = eList[0].Department;
                lbPosition.Text = eList[0].Position;

                crList = client.GetContractByEmployeeID(client.GetEmployeeID(nric)).ToList<ContractRecord>();
                int index = crList.Count - 1;
                lbDate.Text = crList[index].create_date.ToShortDateString();
                lbWorkingHours.Text = crList[index].workingHours;
                lbSalary.Text = crList[index].salary;
                lbVacation.Text = crList[index].vacation;
                lbHolidays.Text = crList[index].holidays;
                imgSignature.ImageUrl = @"~/Management/SignatureImages/test.png";

                string benefits = crList[index].benefits;
                string[] _benefits = benefits.Split(',');

                foreach (string i in _benefits)
                {
                    switch (i)
                    {
                        case "Child care":
                            lbChildCare.Text = "Yes";
                            break;
                        case "Dental Insurance":
                            lbDentalInsurance.Text = "Yes";
                            break;
                        case "Health Insurance":
                            lbHealthInsurance.Text = "Yes";
                            break;
                        case "Pension":
                            lbPension.Text = "Yes";
                            break;
                        case "Vision Care":
                            lbVisionCare.Text = "Yes";
                            break;
                    }
                }
            }


            path = Server.MapPath("~/Management/SignatureImages/");
        }

        [WebMethod()]
        public static void UploadImage(string imageData)
        {
            // Get employee name/id form session and replace datetime?
            //string fileNameWitPath = path + DateTime.Now.ToString().Replace("/", "-").Replace(" ", "- ").Replace(":", "") + ".png";
            string fileNameWitPath = path + "test.png";
            using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void btnRenew_Click(object sender, EventArgs e)
        {

        }
    }
}