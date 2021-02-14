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
    public class ContractRecord
    {
        public string salary { get; set; }
        public string benefits { get; set; }
        public string workingHours { get; set; }
        public string holidays { get; set; }
        public string vacation { get; set; }
        public DateTime create_date { get; set; }
        public string employeeID { get; set; }
        public string signature { get; set; }

        public ContractRecord() { }

        public ContractRecord(string salary, string benefits, string workingHours, string holidays, string vacation, DateTime create_date, string employeeID, string signature)
        {
            this.salary = salary;
            this.benefits = benefits;
            this.workingHours = workingHours;
            this.holidays = holidays;
            this.vacation = vacation;
            this.create_date = create_date;
            this.employeeID = employeeID;
            this.signature = signature;
        }

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO Contract " +
                "VALUES (@paraSalary, @paraBenefits, @paraWorkingHours, @paraHolidays, @paraVacation, @paraCreateDate, @paraEmployeeID, @paraSignature)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraSalary", salary);
            sqlCmd.Parameters.AddWithValue("@paraBenefits", benefits);
            sqlCmd.Parameters.AddWithValue("@paraWorkingHours", workingHours);
            sqlCmd.Parameters.AddWithValue("@paraHolidays", holidays);
            sqlCmd.Parameters.AddWithValue("@paraVacation", vacation);
            sqlCmd.Parameters.AddWithValue("@paraCreateDate", create_date);
            sqlCmd.Parameters.AddWithValue("@paraEmployeeID", employeeID);
            sqlCmd.Parameters.AddWithValue("@paraSignature", DBNull.Value);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public List<ContractRecord> SelectByEmployeeID(string _employeeID)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "select * from contract where Employee_ID = @paraEmployeeID";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmployeeID", _employeeID);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<ContractRecord> conList = new List<ContractRecord>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string salary = row["Salary"].ToString();
                string benefits = row["Benefits"].ToString();
                string workingHours = row["Working_Hours"].ToString();
                string holidays = row["Holidays"].ToString();
                string vacation = row["vacation"].ToString();
                DateTime create_date = Convert.ToDateTime(row["Create_Date"]);
                string employeeID = row["Employee_ID"].ToString();
                string signature = row["Signature"].ToString();

                ContractRecord obj = new ContractRecord(salary, benefits, workingHours, holidays, vacation, create_date, employeeID, signature);
                conList.Add(obj);
            }
            return conList;
        }
    }
}
