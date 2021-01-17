using Hospital_Management_Software.MyDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_Software.Management
{
    public partial class AddContract : System.Web.UI.Page
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
                    MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                    eList = client.GetEmployeeByNRIC(nric).ToList<Employee>();

                    tbEmployee.Text = eList[0].FirstName + " " + eList[0].LastName;
                    tbDepartment.Text = eList[0].Department;
                    tbPosition.Text = eList[0].Position;
                }
            }
        }

        protected void btnCreateContract_Click(object sender, EventArgs e)
        {
            string salary = tbSalary.Text;
            string holidays = tbHolidays.Text;
            string workingHours = tbWorkingHours.Text;
            string vacation = tbVacation.Text;
            DateTime create_date = DateTime.Now;
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            string employeeID = client.GetEmployeeID(_nric);

            string benefits = "";

            List<ListItem> selected = cblBenefits.Items.Cast<ListItem>().Where(li => li.Selected).ToList();
            foreach (ListItem i in selected)
            {
                benefits += i + ",";
                
            }
            if (benefits.Length > 0)
            {
                benefits = benefits.Substring(0, benefits.Length - 1);
            }
            //System.Diagnostics.Debug.WriteLine(employeeID);

            client.CreateContract(salary, benefits, workingHours, holidays, vacation, create_date, employeeID);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Contract Created!'); window.location='" + Request.ApplicationPath + "Management/Employees.aspx';", true);


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employees");
        }
    }
}