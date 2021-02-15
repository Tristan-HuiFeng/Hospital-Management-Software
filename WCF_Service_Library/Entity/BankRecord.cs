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
    public class BankRecord
    {
        public string bankName { get; set; }
        public string bankAccountNumber { get; set; }
        public string bankHolderName { get; set; }
        public int employeeID { get; set; }

        public BankRecord() { }

        public BankRecord(string bankName, string bankAccountNumber, string bankHolderName, int employeeID)
        {
            this.bankName = bankName;
            this.bankAccountNumber = bankAccountNumber;
            this.bankHolderName = bankHolderName;
            this.employeeID = employeeID;
        }

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO Bank_Detail " +
                "VALUES (@paraBankName, @paraBankAccountNumber, @paraBankHolderName, @paraEmployeeID)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraBankName", bankName);
            sqlCmd.Parameters.AddWithValue("@paraBankAccountNumber", bankAccountNumber);
            sqlCmd.Parameters.AddWithValue("@paraBankHolderName", bankHolderName);
            sqlCmd.Parameters.AddWithValue("@paraEmployeeID", employeeID);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public List<BankRecord> SelectByEmployeeID(int id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "select * from Bank_Detail where Employee_ID = @paraID";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraID", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<BankRecord> brList = new List<BankRecord>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string bankName = row["Bank_Name"].ToString();
                string bankAccountNumber = row["Bank_Account_Number"].ToString();
                string bankHolderName = row["Bank_Holder_Name"].ToString();
                int employeeID = int.Parse(row["Employee_ID"].ToString());
                BankRecord obj = new BankRecord(bankName, bankAccountNumber, bankHolderName, employeeID);
                brList.Add(obj);
            }
            return brList;
        }

        public string GetBankDetailID(string _id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "select * from BANK_DETAIL where EMPLOYEE_ID = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", _id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            string id = "";
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                id = row["Bank_Detail_ID"].ToString();
            }

            return id;
        }

        public List<BankRecord> SelectByBankID(int id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "select * from Bank_Detail where Bank_Detail_ID = @paraID";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraID", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<BankRecord> brList = new List<BankRecord>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string bankName = row["Bank_Name"].ToString();
                string bankAccountNumber = row["Bank_Account_Number"].ToString();
                string bankHolderName = row["Bank_Holder_Name"].ToString();
                int employeeID = int.Parse(row["Employee_ID"].ToString());
                BankRecord obj = new BankRecord(bankName, bankAccountNumber, bankHolderName, employeeID);
                brList.Add(obj);
            }
            return brList;
        }
    }
}
