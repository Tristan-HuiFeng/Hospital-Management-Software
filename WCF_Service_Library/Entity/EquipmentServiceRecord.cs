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
    public class EquipmentServiceRecord
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string serialNumber { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public int employeeID { get; set; }

        public EquipmentServiceRecord() { }
        public EquipmentServiceRecord(int id, string name, string serialNumber, string location, string description, int employeeID )
        {
            this.ID = id;
            this.name = name;
            this.serialNumber = serialNumber;
            this.location = location;
            this.description = description;
            this.employeeID = employeeID;

        }
        public EquipmentServiceRecord SelectByID(int id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from EQUIPMENT_SERVICE_RECORD where Equipment_Service_ID = @paraID";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraID", id);

            DataSet ds = new DataSet();
            da.Fill(ds);

            int rec_cnt = ds.Tables[0].Rows.Count;
            EquipmentServiceRecord obj = null;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int obj_ID = Convert.ToInt32(row["Equipment_Service_ID"]);
                string obj_name = row["Equipment_Name"].ToString();
                string obj_serialNumber = row["Equipment_Serial_Number"].ToString();
                string obj_location = row["Location"].ToString();
                string obj_description = row["Description"].ToString();
                int obj_employeeID = Convert.ToInt32(row["Employee_ID"]);
                obj = new EquipmentServiceRecord(obj_ID, obj_name, obj_serialNumber, obj_location, obj_description, obj_employeeID);
            }
            return obj;
        }
        public List<EquipmentServiceRecord> SelectByEmployeeID(int employeeID)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from EQUIPMENT_SERVICE_RECORD where Employee_ID = @paraEmpID";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmpID", employeeID);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<EquipmentServiceRecord> ESRList = new List<EquipmentServiceRecord>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  
                int obj_ID = Convert.ToInt32(row["Equipment_Service_ID"]);
                string obj_name = row["Equipment_Name"].ToString();
                string obj_serialNumber = row["Equipment_Serial_Number"].ToString();
                string obj_location = row["Location"].ToString();
                string obj_description = row["Description"].ToString();
                int obj_employeeID = Convert.ToInt32(row["Employee_ID"]);
                EquipmentServiceRecord obj = new EquipmentServiceRecord(obj_ID, obj_name, obj_serialNumber, obj_location, obj_description, obj_employeeID);
                ESRList.Add(obj);
            }
            return ESRList;
        }
    }
}
