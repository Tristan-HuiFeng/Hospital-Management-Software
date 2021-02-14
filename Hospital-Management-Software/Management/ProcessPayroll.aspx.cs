using Hospital_Management_Software.MyDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCF_Service_Library.Entity;

namespace Hospital_Management_Software.Management
{
    public partial class ProcessPayroll : System.Web.UI.Page
    {
        static string _id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                _id = id;
                if (id != null)
                {
                    List<PayrollRecord> prList = new List<PayrollRecord>();
                    MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                    prList = client.GetPayrollByID(id).ToList<PayrollRecord>();
                    lbName.Text = prList[0].employeeName;
                    lbPosition.Text = prList[0].employeePosition;
                    lbCreatedDate.Text = prList[0].createdDate.ToString();
                    if (prList[0].processedDate != null) { lbProcessedDate.Text = prList[0].processedDate; }
                    lbStatus.Text = prList[0].processed;
                    string[] otDetails = prList[0].overtimeDetails.Split(',');
                    decimal baseSalary = Convert.ToDecimal(prList[0].salary) - (Convert.ToDecimal(otDetails[0]) * Convert.ToDecimal(otDetails[1]));
                    lbMonthSalary.Text = baseSalary.ToString();
                    lbBonus.Text = prList[0].bonusAmount.ToString();
                    lbEmployerCPF.Text = (Convert.ToDouble(prList[0].salary) * 0.83).ToString();
                    lbOvertimeDetails.Text = $"OT({otDetails[0]} Hrs x ${otDetails[1]})";
                    lbOvertimePay.Text = (Convert.ToDecimal(otDetails[0]) * Convert.ToDecimal(otDetails[1])).ToString();
                    lbTotalWages.Text = (prList[0].salary + prList[0].bonusAmount).ToString();
                }
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            if (_id != "") { client.ProcessPayrollByID(_id, "Completed"); }
            Response.Redirect("Payrolls", false);
        }
    }
}