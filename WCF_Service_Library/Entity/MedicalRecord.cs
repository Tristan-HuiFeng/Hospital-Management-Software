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
        public string patientName { get; set; }
        public string patientContact { get; set; }
        public string doctorName { get; set; }
        public string doctorEmail { get; set; }

        public MedicalRecord() { }
        public MedicalRecord(int medicalRecordID, string bloodPressure, string respirationRate, string bodyTemperature, string pulseRate, string diagnosis,
            string treatment, DateTime consultationDate, int patientID, int doctorID, string prescriptions, string remarks, string patientName = null,
            string patientContact = null, string doctorName = null, string doctorEmail = null)
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
            this.patientName = patientName;
            this.patientContact = patientContact;
            this.doctorEmail = doctorEmail;
            this.doctorName = doctorName;

        }

        public MedicalRecord SelectByMedicalRecordID(int id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            
            string sqlStmt = "Select MR.Medical_Record_ID, MR.Blood_Pressure, MR.Respiration_Rate, MR.Body_Temperature, MR.Pulse_Rate, " +
                "MR.Diagnosis, MR.Treatment, Convert(varchar, MR.Date, 103) Date, MR.Prescriptions, MR.Remarks, MR.Patient_ID, MR.Employee_ID, " +
                "Concat(P.First_Name, ' ', P.Last_Name) Patient_Name, P.Phone_Number AS Patient_Contact, " +
                "Concat(E.First_Name, ' ', E.Last_Name) Doctor_Name, E.Email AS Doctor_Email " +
                "from MEDICAL_RECORD AS MR " +
                "Inner join PATIENT AS P on MR.Patient_ID = P.Patient_ID " +
                "Inner join EMPLOYEE AS E on MR.Employee_ID = E.Employee_ID " +
                "where Medical_Record_ID = @paraId";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            DataSet ds = new DataSet();
            da.Fill(ds);

            MedicalRecord medicalRecord = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int obj_medicalRecordID = Convert.ToInt32(row["Medical_Record_ID"]);
                string obj_bloodPressure = row["Blood_Pressure"].ToString();
                string obj_respirationDate = row["Respiration_Rate"].ToString();
                string obj_bodyTemperature = row["Body_Temperature"].ToString();
                string obj_pulseRate = row["Pulse_Rate"].ToString();
                string obj_diagnosis = row["Diagnosis"].ToString();
                string obj_treatment = row["Treatment"].ToString();
                DateTime obj_consultationDate = Convert.ToDateTime(row["Date"].ToString());
                string obj_prescriptions = row["Prescriptions"].ToString();
                string obj_remarks = row["Remarks"].ToString();
                int obj_patientID = Convert.ToInt32(row["Patient_ID"]);
                int obj_doctorID = Convert.ToInt32(row["Employee_ID"]);
                string obj_patientName = row["Patient_Name"].ToString();
                string obj_patientContact = row["Patient_Contact"].ToString();
                string obj_doctorName = row["Doctor_Name"].ToString();
                string obj_doctorEmail = row["Doctor_Email"].ToString();

                medicalRecord = new MedicalRecord(obj_medicalRecordID, obj_bloodPressure, obj_respirationDate, obj_bodyTemperature, obj_pulseRate,
                    obj_diagnosis, obj_treatment, obj_consultationDate, obj_patientID, obj_doctorID, obj_prescriptions, obj_remarks, obj_patientName, obj_patientContact,
                    obj_doctorName, obj_doctorEmail);
               
            }
            
            return medicalRecord;
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
                string obj_prescriptions = row["Prescriptions"].ToString();
                string obj_remarks = row["Remarks"].ToString();
                int obj_patientID = Convert.ToInt32(row["Patient_ID"]);
                int obj_doctorID = Convert.ToInt32(row["Employee_ID"]);

                MedicalRecord obj = new MedicalRecord(obj_medicalRecordID, obj_bloodPressure, obj_respirationDate, obj_bodyTemperature, obj_pulseRate,
                    obj_diagnosis, obj_treatment, obj_consultationDate, obj_patientID, obj_doctorID, obj_prescriptions, obj_remarks);
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
                string obj_prescriptions = row["Prescriptions"].ToString();
                string obj_remarks = row["Remarks"].ToString();
                int obj_patientID = Convert.ToInt32(row["Patient_ID"]);
                int obj_doctorID = Convert.ToInt32(row["Employee_ID"]);

                MedicalRecord obj = new MedicalRecord(obj_medicalRecordID, obj_bloodPressure, obj_respirationDate, obj_bodyTemperature, obj_pulseRate,
                    obj_diagnosis, obj_treatment, obj_consultationDate, obj_patientID, obj_doctorID, obj_prescriptions, obj_remarks);
                medicalRecordList.Add(obj);
            }
            return medicalRecordList;
        }

        public DataTable SelectAllTableView()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select Convert(varchar, MR.Date, 100) date, Medical_Record_ID, Concat(P.First_Name, ' ', P.Last_Name) patientFullName, Concat(E.First_Name, ' ',E.Last_Name) doctorFullName, MR.Diagnosis " +
                "from MEDICAL_RECORD AS MR " +
                "Inner join PATIENT AS P on MR.Patient_ID = P.Patient_ID " +
                "Inner join EMPLOYEE AS E on MR.Employee_ID = E.Employee_ID " +
                "Order by MR.Date DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            DataTable dt = new DataTable();
            dt.TableName = "MedicalRecord";
            da.Fill(dt);

            return dt;
        }

        public int Insert()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO MEDICAL_RECORD (Blood_Pressure, Respiration_Rate, Body_Temperature, Pulse_Rate, Diagnosis, Treatment, Date, Prescriptions, Remarks, Patient_ID, Employee_ID) " +
               "VALUES (@paraBloodPressure, @paraRespirationRate, @paraBodyTemperature, @paraPulseRate, @paraDiagnosis, @paraTreatment, @paraDate, @paraPrescription, @paraRemarks, @paraPatientID, @paraEmployeeID)";


            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
            
            sqlCmd.Parameters.AddWithValue("@paraBloodPressure", bloodPressure);
            sqlCmd.Parameters.AddWithValue("@paraRespirationRate", respirationRate);
            sqlCmd.Parameters.AddWithValue("@paraBodyTemperature", bodyTemperature);
            sqlCmd.Parameters.AddWithValue("@paraPulseRate", pulseRate);

            sqlCmd.Parameters.AddWithValue("@paraDiagnosis", diagnosis);
            sqlCmd.Parameters.AddWithValue("@paraTreatment", treatment);
            sqlCmd.Parameters.AddWithValue("@paraDate", consultationDate);
            sqlCmd.Parameters.AddWithValue("@paraPrescription", prescriptions != "" ? prescriptions : Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@paraRemarks", remarks != "" ? remarks : Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@paraPatientID", patientID);
            sqlCmd.Parameters.AddWithValue("@paraEmployeeID", doctorID);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}
