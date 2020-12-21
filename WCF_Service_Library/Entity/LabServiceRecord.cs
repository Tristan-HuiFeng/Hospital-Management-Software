using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WCF_Service_Library.Entity
{
    public class LabServiceRecord
    {
        public int ID { get; set; }
        public int priority { get; set; }
        public string testRequired { get; set; }
        public string remarks { get; set; }
        public int employeeID { get; set; }

        public LabServiceRecord() { }
        public LabServiceRecord(int id, int priority, string testRequired, string remarks, int employeeID)
        {
            this.ID = id;
            this.priority = priority;
            this.testRequired = testRequired;
            this.remarks = remarks;
            this.employeeID = employeeID;

        }
        public LabServiceRecord SelectByID(int id)
        {
            string DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from LAB_SERVICE_RECORD where Lab_Service_ID = @paraID";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraID", id);

            DataSet ds = new DataSet();
            da.Fill(ds);

            int rec_cnt = ds.Tables[0].Rows.Count;
            LabServiceRecord obj = null;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int obj_ID = Convert.ToInt32(row["Lab_Service_ID"]);
                int obj_priority = Convert.ToInt32(row["Priority"]);
                string obj_testRequired = row["Test_Required"].ToString();
                string obj_remarks = row["Remarks"].ToString();
                int obj_employeeID = Convert.ToInt32(row["Employee_ID"]);
                obj = new LabServiceRecord(obj_ID, obj_priority, obj_testRequired, obj_remarks, obj_employeeID);
            }
            return obj;
        }
        public List<LabServiceRecord> SelectByEmployeeID(int employeeID)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from LAB_SERVICE_RECORD where Employee_ID = @paraEmpID";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmpID", employeeID);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<LabServiceRecord> LSRList = new List<LabServiceRecord>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i]; 
                int obj_ID = Convert.ToInt32(row["Lab_Service_ID"]);
                int obj_priority = Convert.ToInt32(row["Priority"]);
                string obj_testRequired = row["Test_Required"].ToString();
                string obj_remarks = row["Remarks"].ToString();
                int obj_employeeID = Convert.ToInt32(row["Employee_ID"]);
                LabServiceRecord obj = new LabServiceRecord(obj_ID, obj_priority, obj_testRequired, obj_remarks, obj_employeeID);
                LSRList.Add(obj);
            }
            return LSRList;
        }
    }
}

