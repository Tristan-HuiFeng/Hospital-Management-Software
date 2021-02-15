//using Hospital_Management_Software.MyDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using WCF_Service_Library.Entity;

namespace Hospital_Management_Software.Management
{
    public partial class Contract : System.Web.UI.Page
    {
        static string _nric = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nric = Request.QueryString["nric"];
                _nric = nric;
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

                    if (crList[index].signature != "")
                    {
                        imgSignature.ImageUrl = crList[index].signature;
                    } else
                    {
                        Label4.Text += " (NOT SIGNED YET)";
                    }

                    string benefits = crList[index].benefits;
                    string[] _benefits = benefits.Split(',');

                    foreach (string i in _benefits)
                    {
                        switch(i)
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
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employees");
        }

        protected void btnRenew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddContract?nric=" + _nric);
        }
    }
}