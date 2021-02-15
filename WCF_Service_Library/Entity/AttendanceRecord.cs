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
    public class AttendanceRecord
    {
        public string empID { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string reason { get; set; }

        public AttendanceRecord() { }

        public AttendanceRecord(string empID, string date, string status, string reason)
        {
            this.empID = empID;
            this.date = date;
            this.status = status;
            this.reason = reason;
        }

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO Attendance " +
                "VALUES (@paraEmpID, @paraDate, @paraStatus, @paraReason)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraEmpID", empID);
            sqlCmd.Parameters.AddWithValue("@paraDate", Convert.ToDateTime(date));
            sqlCmd.Parameters.AddWithValue("@paraStatus", status);
            sqlCmd.Parameters.AddWithValue("@paraReason", reason);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public List<AttendanceRecord> SelectByIDWithDate(string id, DateTime _date)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "select * from Attendance where Employee_ID = @paraID and Date = @paraDate";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraID", id);
            da.SelectCommand.Parameters.AddWithValue("@paraDate", _date);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<AttendanceRecord> arList = new List<AttendanceRecord>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string empID = row["Employee_ID"].ToString();
                string date = row["Date"].ToString();
                string status = row["Status"].ToString();
                string reason = row["Reason"].ToString();
                AttendanceRecord obj = new AttendanceRecord(empID, date, status, reason);
                arList.Add(obj);
            }
            return arList;
        }

        public int UpdateByIDWithDate(string id, DateTime _date, string status, string reason)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "update attendance " +
                "set Status = @paraStatus, Reason = @paraReason " +
                "where Employee_ID = @paraID and Date = @paraDate";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraStatus", status);
            sqlCmd.Parameters.AddWithValue("@paraReason", reason);
            sqlCmd.Parameters.AddWithValue("@paraID", id);
            sqlCmd.Parameters.AddWithValue("@paraDate", _date);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }
    }
}
