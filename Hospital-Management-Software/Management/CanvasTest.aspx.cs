using Hospital_Management_Software.MyDBServiceReference;
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

namespace Hospital_Management_Software.Management
{
    [ScriptService]
    public partial class CanvasTest : System.Web.UI.Page
    {
        static string path;
        static string _id = "";
        static string empNric = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                if (id != null)
                {
                    _id = id;
                    List<ContractRecord> crList = new List<ContractRecord>();
                    crList = client.GetContractByID(id).ToList<ContractRecord>();

                    // Set contract
                    lbDate.Text = crList[0].create_date.ToShortDateString();
                    lbWorkingHours.Text = crList[0].workingHours;
                    lbSalary.Text = crList[0].salary;
                    lbVacation.Text = crList[0].vacation;
                    lbHolidays.Text = crList[0].holidays;
                    if (crList[0].signature != "")
                    {
                        imgSignature.ImageUrl = crList[0].signature;
                    }

                    string benefits = crList[0].benefits;
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

                    // Set employee details
                    List<Employee> eList = new List<Employee>();
                    eList = client.GetEmployeeByID(crList[0].employeeID).ToList<Employee>();
                    lbEmployeeID.Text = crList[0].employeeID;
                    lbEmployeeName.Text = eList[0].FirstName + " " + eList[0].LastName;
                    lbEmail.Text = eList[0].Email;
                    lbDepartment.Text = eList[0].Department;
                    lbPosition.Text = eList[0].Position;
                    empNric = eList[0].Nric;
                }



            }
            path = Server.MapPath("~/Management/SignatureImages/");
        }

        [WebMethod()]
        public static void UploadImage(string imageData)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            // Get employee name/id form session and replace datetime?
            //string fileNameWitPath = path + DateTime.Now.ToString().Replace("/", "-").Replace(" ", "- ").Replace(":", "") + ".png";
            //string fileNameWitPath = path + "test.png";
            string _fileName = _id + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString() + ".png";
            string fileNameWitPath = path + _id + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString() + ".png";
            using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);

                    // Save to database
                    if (_id != "")
                    {
                        client.SetSignatureByID(_id, "~/Management/SignatureImages/" + _fileName);
                    }
                    bw.Write(data);
                    bw.Close();
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewContracts.aspx", false);
        }
    }
}