using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Service_Library.Entity
{
    public class PayrollRecord
    {
        public string id { get; set; }
        public decimal salary { get; set; }
        public decimal bonusAmount { get; set; }
        public string processedDate { get; set; }
        public DateTime createdDate { get; set; }
        public int employeeID { get; set; }
        public int bankDetailID { get; set; }
        public string processed { get; set; }
        public string overtimeDetails { get; set; }
        public string employeeName { get; set; }
        public string employeePosition { get; set; }

        public PayrollRecord(){}

        public PayrollRecord(decimal salary, decimal bonusAmount, string processedDate, DateTime createdDate, int employeeID, int bankDetailID, string processed, string overtimeDetails)
        {
            this.salary = salary;
            this.bonusAmount = bonusAmount;
            this.processedDate = processedDate;
            this.createdDate = createdDate;
            this.employeeID = employeeID;
            this.bankDetailID = bankDetailID;
            this.processed = processed;
            this.overtimeDetails = overtimeDetails;
        }

        // Retrieve with ID
        public PayrollRecord(string id, decimal salary, decimal bonusAmount, string processedDate, DateTime createdDate, int employeeID, int bankDetailID, string processed, string overtimeDetails, string employeeName, string employeePosition)
        {
            this.id = id;
            this.salary = salary;
            this.bonusAmount = bonusAmount;
            this.processedDate = processedDate;
            this.createdDate = createdDate;
            this.employeeID = employeeID;
            this.bankDetailID = bankDetailID;
            this.processed = processed;
            this.overtimeDetails = overtimeDetails;
            this.employeeName = employeeName;
            this.employeePosition = employeePosition;
        }

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO PAYROLL " +
                "VALUES (@paraSalary, @paraBonusAmount, @paraProcessedDate, @paraCreatedDate, @paraEmployeeID, @paraBankDetailID, @paraProcessed, @paraOvertimeDetails)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraSalary", salary);
            sqlCmd.Parameters.AddWithValue("@paraBonusAmount", bonusAmount);
            sqlCmd.Parameters.AddWithValue("@paraProcessedDate", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@paraCreatedDate", createdDate);
            sqlCmd.Parameters.AddWithValue("@paraEmployeeID", employeeID);
            sqlCmd.Parameters.AddWithValue("@paraBankDetailID", bankDetailID);
            sqlCmd.Parameters.AddWithValue("@paraProcessed", processed);
            sqlCmd.Parameters.AddWithValue("@paraOvertimeDetails", overtimeDetails);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public List<PayrollRecord> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            //string sqlStmt = "Select * from PAYROLL";
            string sqlStmt = "select pr.*, employee.First_Name, employee.Last_Name, employee.Position from payroll as pr inner join employee on pr.Employee_ID = employee.Employee_ID order by Created_Date desc;";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<PayrollRecord> prList = new List<PayrollRecord>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string id = row["Payroll_ID"].ToString();
                decimal salary = Convert.ToDecimal(row["Salary"]);
                decimal bonusAmount = Convert.ToDecimal(row["Bonus_Amount"]);
                string processedDate = row["Processed_Date"].ToString();
                DateTime createdDate= Convert.ToDateTime(row["Created_Date"]);
                int employeeID = Convert.ToInt32(row["Employee_ID"]);
                int bankDetailID = Convert.ToInt32(row["Bank_Detail_ID"]);
                string processed = row["Processed"].ToString();
                string overtimeDetails = row["Overtime_Details"].ToString();
                string employeeName = row["First_Name"].ToString() + " " + row["Last_Name"].ToString();
                string employeePosition = row["Position"].ToString();
                PayrollRecord obj = new PayrollRecord(id, salary, bonusAmount, processedDate, createdDate, employeeID, bankDetailID, processed, overtimeDetails, employeeName, employeePosition);
                prList.Add(obj);
            }
            return prList;
        }

        public List<PayrollRecord> SelectByID(string _id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "select pr.*, employee.First_Name, employee.Last_Name, employee.Position from payroll as pr inner join employee on pr.Employee_ID = employee.Employee_ID where pr.Payroll_ID = @paraID;";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraID", _id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<PayrollRecord> prList = new List<PayrollRecord>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string id = row["Payroll_ID"].ToString();
                decimal salary = Convert.ToDecimal(row["Salary"]);
                decimal bonusAmount = Convert.ToDecimal(row["Bonus_Amount"]);
                string processedDate = row["Processed_Date"].ToString();
                DateTime createdDate = Convert.ToDateTime(row["Created_Date"]);
                int employeeID = Convert.ToInt32(row["Employee_ID"]);
                int bankDetailID = Convert.ToInt32(row["Bank_Detail_ID"]);
                string processed = row["Processed"].ToString();
                string overtimeDetails = row["Overtime_Details"].ToString();
                string employeeName = row["First_Name"].ToString() + " " + row["Last_Name"].ToString();
                string employeePosition = row["Position"].ToString();
                PayrollRecord obj = new PayrollRecord(id, salary, bonusAmount, processedDate, createdDate, employeeID, bankDetailID, processed, overtimeDetails, employeeName, employeePosition);
                prList.Add(obj);
            }
            return prList;
        }

        public int ProcessPayrollByID(string id, string process)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "update Payroll " +
                "set Processed_Date = @paraDate, Processed = @paraProcessed " +
                "where Payroll_ID = @paraID";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraDate", DateTime.Now);
            sqlCmd.Parameters.AddWithValue("@paraProcessed", process);
            sqlCmd.Parameters.AddWithValue("@paraID", id);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public List<PayrollRecord> SelectPayrollBetweenDate(string firstDate, string secondDate)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "select pr.*, employee.First_Name, employee.Last_Name, employee.Position from payroll as pr inner join employee on pr.Employee_ID = employee.Employee_ID where pr.Created_Date between @paraFirstDate and @paraSecondDate;";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraFirstDate", firstDate);
            da.SelectCommand.Parameters.AddWithValue("@paraSecondDate", secondDate);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<PayrollRecord> prList = new List<PayrollRecord>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string id = row["Payroll_ID"].ToString();
                decimal salary = Convert.ToDecimal(row["Salary"]);
                decimal bonusAmount = Convert.ToDecimal(row["Bonus_Amount"]);
                string processedDate = row["Processed_Date"].ToString();
                DateTime createdDate = Convert.ToDateTime(row["Created_Date"]);
                int employeeID = Convert.ToInt32(row["Employee_ID"]);
                int bankDetailID = Convert.ToInt32(row["Bank_Detail_ID"]);
                string processed = row["Processed"].ToString();
                string overtimeDetails = row["Overtime_Details"].ToString();
                string employeeName = row["First_Name"].ToString() + " " + row["Last_Name"].ToString();
                string employeePosition = row["Position"].ToString();
                PayrollRecord obj = new PayrollRecord(id, salary, bonusAmount, processedDate, createdDate, employeeID, bankDetailID, processed, overtimeDetails, employeeName, employeePosition);
                prList.Add(obj);
            }
            return prList;
        }

        //public List<PayrollRecord> SelectByID(string _id)
        //{
        //    //Step 1 -  Define a connection to the database by getting
        //    //          the connection string from App.config
        //    string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        //    SqlConnection myConn = new SqlConnection(DBConnect);

        //    //Step 2 -  Create a DataAdapter object to retrieve data from the database table
        //    string sqlStmt = "select pr.*, employee.First_Name, employee.Last_Name, employee.Position from payroll as pr inner join employee on pr.Employee_ID = employee.Employee_ID where pr.Payroll_ID = @paraID;";
        //    SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
        //    da.SelectCommand.Parameters.AddWithValue("@paraID", _id);

        //    //Step 3 -  Create a DataSet to store the data to be retrieved
        //    DataSet ds = new DataSet();

        //    //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
        //    da.Fill(ds);

        //    //Step 5 -  Read data from DataSet to List
        //    List<PayrollRecord> prList = new List<PayrollRecord>();
        //    int rec_cnt = ds.Tables[0].Rows.Count;
        //    for (int i = 0; i < rec_cnt; i++)
        //    {
        //        DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
        //        string id = row["Payroll_ID"].ToString();
        //        decimal salary = Convert.ToDecimal(row["Salary"]);
        //        decimal bonusAmount = Convert.ToDecimal(row["Bonus_Amount"]);
        //        string processedDate = row["Processed_Date"].ToString();
        //        DateTime createdDate = Convert.ToDateTime(row["Created_Date"]);
        //        int employeeID = Convert.ToInt32(row["Employee_ID"]);
        //        int bankDetailID = Convert.ToInt32(row["Bank_Detail_ID"]);
        //        string processed = row["Processed"].ToString();
        //        string overtimeDetails = row["Overtime_Details"].ToString();
        //        string employeeName = row["First_Name"].ToString() + " " + row["Last_Name"].ToString();
        //        string employeePosition = row["Position"].ToString();
        //        PayrollRecord obj = new PayrollRecord(id, salary, bonusAmount, processedDate, createdDate, employeeID, bankDetailID, processed, overtimeDetails, employeeName, employeePosition);
        //        prList.Add(obj);
        //    }
        //    return prList;
        //}
    }
}
