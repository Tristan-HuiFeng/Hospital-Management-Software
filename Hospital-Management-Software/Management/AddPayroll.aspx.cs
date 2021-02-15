//using Hospital_Management_Software.MyDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCF_Service_Library.Entity;

namespace Hospital_Management_Software.Management
{
    public partial class AddPayroll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            List<BankRecord> brList = new List<BankRecord>();
            string empID = client.GetEmployeeID(tbNric.Text);
            if (empID != "")
            {
                brList = client.GetBankRecordByEmployeeID(Convert.ToInt32(empID)).ToList<BankRecord>();
            }

            if (brList.Count < 1 && empID != "")
            {
                // Bank record does not exist but employee exists

                // Create bank account
                string bankName = tbBankName.Text;
                string bankAccountNumber = tbAccountNumber.Text;
                string bankHolderName = tbAccountHolderName.Text;
                int employeeID = Convert.ToInt32(client.GetEmployeeID(tbNric.Text));
                client.CreateBankRecord(bankName, bankAccountNumber, bankHolderName, employeeID);

                // Create payroll (Ignore processedDate)
                decimal overtimePay = Convert.ToDecimal(tbOtHours.Text) * Convert.ToDecimal(tbOtMoneyAmount.Text);
                decimal salary = Convert.ToDecimal(tbSalary.Text) + overtimePay;

                decimal bonusAmount = Convert.ToDecimal(tbBonus.Text);
                DateTime createdDate = DateTime.Now;
                string bankDetailID = client.GetBankDetailID(empID);
                string processed = "No";
                string overtimeDetails = tbOtHours.Text + "," + tbOtMoneyAmount.Text;
                client.CreatePayroll(salary, bonusAmount, null/*(Processed Date)*/, createdDate, int.Parse(empID), int.Parse(bankDetailID), processed, overtimeDetails);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Payroll Created!'); window.location='" + Request.ApplicationPath + "Management/Payrolls.aspx';", true);

            }
            else if (brList.Count != 0 && empID != "")
            {
                if (cbNewBank.Checked)
                {
                    // Create bank account
                    string bankName = tbBankName.Text;
                    string bankAccountNumber = tbAccountNumber.Text;
                    string bankHolderName = tbAccountHolderName.Text;
                    int employeeID = Convert.ToInt32(client.GetEmployeeID(tbNric.Text));
                    client.CreateBankRecord(bankName, bankAccountNumber, bankHolderName, employeeID);
                }
                // Have bank record and employee exists
                // Create payroll (Ignore processedDate)
                decimal overtimePay = Convert.ToDecimal(tbOtHours.Text) * Convert.ToDecimal(tbOtMoneyAmount.Text);
                decimal salary = Convert.ToDecimal(tbSalary.Text) + overtimePay;
                decimal bonusAmount = Convert.ToDecimal(tbBonus.Text);
                DateTime createdDate = DateTime.Now;
                string bankDetailID = client.GetBankDetailID(empID);
                string processed = "No";
                string overtimeDetails = tbOtHours.Text + "," + tbOtMoneyAmount.Text;
                client.CreatePayroll(salary, bonusAmount, null/*(Processed Date)*/, createdDate, int.Parse(empID), int.Parse(bankDetailID), processed, overtimeDetails);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Payroll Created!'); window.location='" + Request.ApplicationPath + "Management/Payrolls.aspx';", true);
            }
            else
            {
                lbErrors.Text = "Employee does not exist";
            }

        }

        protected void btnAuto_Click(object sender, EventArgs e)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            string empID = client.GetEmployeeID(tbNric.Text);
            if (empID != "")
            {
                List<BankRecord> brList = new List<BankRecord>();
                brList = client.GetBankRecordByEmployeeID(Convert.ToInt32(empID)).ToList<BankRecord>();
                if (brList.Count < 1)
                {
                    lbAutoMsg.Text = "Retrieve Failed. (Employee does not have Bank Details)";
                    return;
                }
                tbBankName.Text = brList[brList.Count - 1].bankName;
                tbAccountNumber.Text = brList[brList.Count - 1].bankAccountNumber;
                tbAccountHolderName.Text = brList[brList.Count - 1].bankHolderName;

                List<ContractRecord> crList = new List<ContractRecord>();
                crList = client.GetContractByEmployeeID(empID).ToList<ContractRecord>();
                if (crList.Count > 0)
                {
                    int index = crList.Count - 1;
                    tbSalary.Text = crList[index].salary;
                    lbAutoMsg.Text = "Retrieve Success!";
                }
                else
                {
                    lbAutoMsg.Text = "Retrieve Success! (But no contract found)";
                }



            }
            else
            {
                lbAutoMsg.Text = "Retrieve Failed. (May be due to invalid NRIC)";
            }
        }
    }
}