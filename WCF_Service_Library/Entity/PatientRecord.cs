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
    class PatientRecord
    {
        //No LoginId & pwd => login method == NRIC + 2FA via phone
        public int patientID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string NRIC { get; set; }
        public DateTime DOB { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
        public string nationality { get; set; }
        public string citizenship { get; set; }
        public string postalCode { get; set; }
        public string address { get; set; }
        public string allergies { get; set; }
        public string medicalHistory { get; set; }
        public string phoneNumber { get; set; }
        public string homeNumber { get; set; }
        public string email { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

       public PatientRecord() { }

        public PatientRecord(
           string patientid,
           string firstname, string lastname, 
           string NRIC, DateTime DOB, int age, string sex, 
           string nationality, string citizenship, 
           string postalcode, string address, 
           string allergies, string medicalhistory, string phonenumber, 
           string homenumber, string email) 
        {
            //Init code
            this.firstName = firstname;
            this.lastName = lastname;
            this.NRIC = NRIC;
            this.DOB = DOB;
            this.age = age;
            this.sex = sex;
            this.nationality = nationality;
            this.citizenship = citizenship;
            this.postalCode = postalcode;
            this.address = address;
            this.allergies = allergies;
            this.medicalHistory = medicalhistory;
            this.phoneNumber = phonenumber;
            this.homeNumber = homenumber;
            this.email = email;
            this.createdDate = DateTime.Now;
        }

        public List<PatientRecord> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from PATIENT";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<PatientRecord> medicalRecordList = new List<PatientRecord>();
            int rec_cnt = ds.Tables[0].Rows.Count;

            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                string patientID = row["Patient_ID"].ToString();
                string firstName = row["First_Name"].ToString();
                string lastName = row["Last_Name"].ToString();
                string NRIC = row["NRIC"].ToString();
                DateTime DOB = Convert.ToDateTime(row["DOB"].ToString());
                int age = Convert.ToInt32(row["Age"]);
                string sex = row["Sex"].ToString();


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
    }
}
