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
    public class tempPatient
    {
        public string name { get; set; }
        public int id { get; set; }
        public string contact { get; set; }

        public tempPatient()
        {

        }

        public tempPatient(string name, string contact, int id)
        {
            this.name = name;
            this.contact = contact;
            this.id = id;

        }


        public tempPatient SelectPatientById(string patientID)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            tempPatient temp = null;

            int n;
            bool isNumeric = int.TryParse(patientID, out n);

            if (isNumeric)
            {
                string sqlStmt = "Select Patient_ID, Concat(First_Name, ' ',Last_name) name, Phone_Number from PATIENT where Patient_ID = @paraEmpID";
                SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
                da.SelectCommand.Parameters.AddWithValue("@paraEmpID", patientID);

                DataSet ds = new DataSet();
                da.Fill(ds);

                int rec_cnt = ds.Tables[0].Rows.Count;
                if (rec_cnt == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    int obj_patientID = Convert.ToInt32(row["Patient_ID"]);
                    string contact = row["Phone_Number"].ToString();
                    string name = row["name"].ToString();


                    temp = new tempPatient(name, contact, obj_patientID);
                }

            }
            else
            {

                string sqlStmt2 = "Select Patient_ID, Concat(First_Name, ' ',Last_name) name, Phone_Number from PATIENT where @paraEmpID IN (NRIC, Email, Phone_Number)";
                SqlDataAdapter da2 = new SqlDataAdapter(sqlStmt2, myConn);
                da2.SelectCommand.Parameters.AddWithValue("@paraEmpID", patientID);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                int rec_cnt2 = ds2.Tables[0].Rows.Count;

                if (rec_cnt2 >= 1)
                {
                    DataRow row = ds2.Tables[0].Rows[0];
                    int obj_patientID = Convert.ToInt32(row["Patient_ID"]);
                    string contact = row["Phone_Number"].ToString();
                    string name = row["name"].ToString();
                    temp = new tempPatient(name, contact, obj_patientID);
                }
            }

            /*
            string sqlStmt = "Select Patient_ID, Concat(First_Name, ' ',Last_name) name, Phone_Number from PATIENT where Patient_ID = @paraEmpID";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmpID", patientID);

            DataSet ds = new DataSet();
            da.Fill(ds);

            
            int rec_cnt = ds.Tables[0].Rows.Count;

            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int obj_patientID = Convert.ToInt32(row["Patient_ID"]);
                string contact = row["Phone_Number"].ToString();
                string name = row["name"].ToString();


                temp = new tempPatient(name, contact, obj_patientID);
            }
            else
            {
                string sqlStmt2 = "Select Patient_ID, Concat(First_Name, ' ',Last_name) name, Phone_Number from PATIENT where @paraEmpID IN (NRIC, Email, Phone_Number)";
                SqlDataAdapter da2 = new SqlDataAdapter(sqlStmt2, myConn);
                da2.SelectCommand.Parameters.AddWithValue("@paraEmpID", patientID);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                int rec_cnt2 = ds2.Tables[0].Rows.Count;
                
                if(rec_cnt2 >= 1)
                {
                    DataRow row = ds2.Tables[0].Rows[0];
                    int obj_patientID = Convert.ToInt32(row["Patient_ID"]);
                    string contact = row["Phone_Number"].ToString();
                    string name = row["name"].ToString();
                    temp = new tempPatient(name, contact, obj_patientID);
                }
            }*/

            return temp;
        }

    }
}
