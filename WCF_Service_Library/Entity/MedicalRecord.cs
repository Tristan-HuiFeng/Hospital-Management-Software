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
    public class MedicalRecord
    {
        public int medicalRecordID { get; set; }
        public string bloodPressure { get; set; }
        public string respirationRate { get; set; }
        public string bodyTemperature { get; set; }
        public string pulseRate { get; set; }
        public string diagnosis { get; set; }
        public string treatment { get; set; }
        public DateTime consultationDate { get; set; }
        public string prescriptions { get; set; }
        public string remarks { get; set; }
        public int patientID { get; set; }
        public int doctorID { get; set; }

        public MedicalRecord() { }
        public MedicalRecord(int medicalRecordID, string bloodPressure, string respirationRate, string bodyTemperature, string pulseRate, string diagnosis,
            string treatment, DateTime consultationDate, string prescriptions, string remarks, int patientID, int doctorID)
        {
            this.medicalRecordID = medicalRecordID;
            this.bloodPressure = bloodPressure;
            this.respirationRate = respirationRate;
            this.bodyTemperature = bodyTemperature;
            this.pulseRate = pulseRate;
            this.diagnosis = diagnosis;
            this.treatment = treatment;
            this.consultationDate = consultationDate;
            this.prescriptions = prescriptions;
            this.remarks = remarks;
            this.patientID = patientID;
            this.doctorID = doctorID;

        }

        public List<MedicalRecord> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from MEDICAL_RECORD";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<MedicalRecord> medicalRecordList = new List<MedicalRecord>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int obj_medicalRecordID = Convert.ToInt32(row["Medical_Record_ID"]);
                string obj_bloodPressure = row["Blood_Pressure"].ToString();
                string obj_respirationDate = row["Respiration_Rate"].ToString();
                string obj_bodyTemperature = row["Body_Temperature"].ToString();
                string obj_pulseRate = row["Pulse_Rate"].ToString();
                string obj_diagnosis = row["Diagnosis"].ToString();
                string obj_treatment = row["Treatment"].ToString();
                DateTime obj_consultationDate = Convert.ToDateTime(row["Date"].ToString());
                string obj_presccriptions = row["Prescriptions"].ToString();
                string obj_remarks = row["Remarks"].ToString();
                int obj_patientID = Convert.ToInt32(row["Patient_ID"]);
                int obj_doctorID = Convert.ToInt32(row["Employee_ID"]);

                MedicalRecord obj = new MedicalRecord(obj_medicalRecordID, obj_bloodPressure, obj_respirationDate, obj_bodyTemperature, obj_pulseRate,
                    obj_diagnosis, obj_treatment, obj_consultationDate, obj_presccriptions, obj_remarks, obj_patientID, obj_doctorID);
                medicalRecordList.Add(obj);
            }
            return medicalRecordList;
        }

        public List<MedicalRecord> SelectByEmployeeID(int employeeID)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from MEDICAL_RECORD where Employee_ID = @paraEmpID";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmpID", employeeID);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<MedicalRecord> medicalRecordList = new List<MedicalRecord>();
            int rec_cnt = ds.Tables[0].Rows.Count;

            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int obj_medicalRecordID = Convert.ToInt32(row["Medical_Record_ID"]);
                string obj_bloodPressure = row["Blood_Pressure"].ToString();
                string obj_respirationDate = row["Respiration_Rate"].ToString();
                string obj_bodyTemperature = row["Body_Temperature"].ToString();
                string obj_pulseRate = row["Pulse_Rate"].ToString();
                string obj_diagnosis = row["Diagnosis"].ToString();
                string obj_treatment = row["Treatment"].ToString();
                DateTime obj_consultationDate = Convert.ToDateTime(row["Date"].ToString());
                string obj_presccriptions = row["Prescriptions"].ToString();
                string obj_remarks = row["Remarks"].ToString();
                int obj_patientID = Convert.ToInt32(row["Patient_ID"]);
                int obj_doctorID = Convert.ToInt32(row["Employee_ID"]);

                MedicalRecord obj = new MedicalRecord(obj_medicalRecordID, obj_bloodPressure, obj_respirationDate, obj_bodyTemperature, obj_pulseRate,
                    obj_diagnosis, obj_treatment, obj_consultationDate, obj_presccriptions, obj_remarks, obj_patientID, obj_doctorID);
                medicalRecordList.Add(obj);
            }
            return medicalRecordList;
        }

        //public DataTable SelectAllTableView()
        //{


        //}
    }
}