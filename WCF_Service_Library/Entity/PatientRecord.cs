﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace WCF_Service_Library.Entity
{
    public class PatientRecord
    {
        //No LoginId & pwd => login method == NRIC + 2FA via phone
        public int patientID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string NRIC { get; set; }
        public DateTime DOB { get; set; }
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
        public string recordDisabled { get; set; }

       public PatientRecord() { }

        public PatientRecord(
           int patientid,
           string firstname, string lastname, 
           string NRIC, DateTime DOB, string sex, 
           string nationality, string citizenship, 
           string postalcode, string address, 
           string allergies, string medicalhistory, string phonenumber, 
           string homenumber, string email,
           DateTime createdDate, DateTime updatedDate,
           string recordDisabled) 
        {
            //personal infos
            this.patientID = patientid;
            this.firstName = firstname;
            this.lastName = lastname;
            this.NRIC = NRIC;
            this.DOB = DOB;
            this.sex = sex;
            //contacts
            this.nationality = nationality;
            this.citizenship = citizenship;
            this.postalCode = postalcode;
            this.address = address;
            this.allergies = allergies;
            this.medicalHistory = medicalhistory;
            this.phoneNumber = phonenumber;
            this.homeNumber = homenumber;
            this.email = email;
            //date creation
            this.createdDate = createdDate;
            this.updatedDate = updatedDate;
            //disabled indicator
            this.recordDisabled = recordDisabled;
        }

        public int Insert()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "SET IDENTITY_INSERT PATIENT ON " +
                "INSERT INTO PATIENT (Patient_ID, First_Name, Last_Name, NRIC, DOB, Sex, Nationality, Citizenship, Postal_Code, Address, Allergies, Medical_History, Phone_Number, Home_Number, Email, Created_Date, Update_Date, Record_Disabled) " +
                "VALUES (@paraPatientID,@paraFirstName, @paraLastName, @paraNRIC, @paraDOB, @paraSex, @paraNationality, @paraCitizenship, @paraPostalcode, @paraAddress, @paraAllergies, @paraMedicalHistory, @paraPhoneNumber, @paraHomeNumber, @paraEmail, @paraCreatedDate, @paraUpdatedDate, @paraRecordDisabled)" +
                "SET IDENTITY_INSERT PATIENT OFF ";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraPatientID", patientID);
            sqlCmd.Parameters.AddWithValue("@paraFirstName", firstName);
            sqlCmd.Parameters.AddWithValue("@paraLastName", lastName);
            sqlCmd.Parameters.AddWithValue("@paraNRIC", NRIC);
            sqlCmd.Parameters.AddWithValue("@paraDOB", DOB);
            sqlCmd.Parameters.AddWithValue("@paraSex", sex);
            sqlCmd.Parameters.AddWithValue("@paraNationality", nationality);
            sqlCmd.Parameters.AddWithValue("@paraCitizenship", citizenship);
            sqlCmd.Parameters.AddWithValue("@paraPostalcode", postalCode);
            sqlCmd.Parameters.AddWithValue("@paraAddress", address);
            sqlCmd.Parameters.AddWithValue("@paraAllergies", allergies);
            sqlCmd.Parameters.AddWithValue("@paraMedicalHistory", postalCode);
            sqlCmd.Parameters.AddWithValue("@paraPhoneNumber", phoneNumber);
            sqlCmd.Parameters.AddWithValue("@paraHomeNumber", homeNumber);
            sqlCmd.Parameters.AddWithValue("@paraEmail", phoneNumber);
            sqlCmd.Parameters.AddWithValue("@paraCreatedDate", createdDate);
            sqlCmd.Parameters.AddWithValue("@paraUpdatedDate", updatedDate);
            sqlCmd.Parameters.AddWithValue("@paraRecordDisabled", recordDisabled);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();
            myConn.Close();


            return result;
        }

        public List<PatientRecord> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from PATIENT";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<PatientRecord> patientRecordList = new List<PatientRecord>();
            int rec_cnt = ds.Tables[0].Rows.Count;

            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int patientID = (int)row["Patient_ID"];
                string firstName = row["First_Name"].ToString();
                string lastName = row["Last_Name"].ToString();
                string NRIC = row["NRIC"].ToString();
                DateTime DOB = Convert.ToDateTime(row["DOB"].ToString());
                string sex = row["Sex"].ToString();
                string nationality = row["Nationality"].ToString();
                string citizenship = row["Citizenship"].ToString();
                string postalCode = row["Postal_Code"].ToString();
                string address = row["Address"].ToString();
                string allergies = row["Allergies"].ToString();
                string medicalHistory = row["Medical_History"].ToString();
                string phoneNumber = row["Phone_Number"].ToString();
                string homeNumber = row["Home_Number"].ToString();
                string email = row["Email"].ToString();
                DateTime createdDate = Convert.ToDateTime(row["Created_Date"].ToString());
                DateTime updatedDate = Convert.ToDateTime(row["Update_Date"].ToString());
                string recordDisabled = row["Record_Disabled"].ToString();

                PatientRecord patient = new PatientRecord(patientID, firstName, lastName,
                    NRIC, DOB, sex, nationality, citizenship,
                    postalCode, address,
                    allergies, medicalHistory,
                    phoneNumber, homeNumber, email,
                    createdDate, updatedDate,
                    recordDisabled
                    );
                patientRecordList.Add(patient);
            }
            return patientRecordList;
        }

        public PatientRecord SelectPatientByID(int patientID)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from PATIENT where Patient_ID = @paraPatientID";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraPatientID", patientID);

            DataSet ds = new DataSet();
            da.Fill(ds);

            PatientRecord patient = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string firstName = row["First_Name"].ToString();
                string lastName = row["Last_Name"].ToString();
                string NRIC = row["NRIC"].ToString();
                DateTime DOB = Convert.ToDateTime(row["DOB"].ToString());
                string sex = row["Sex"].ToString();
                string nationality = row["Nationality"].ToString();
                string citizenship = row["Citizenship"].ToString();
                string postalCode = row["Postal_Code"].ToString();
                string address = row["Address"].ToString();
                string allergies = row["Allergies"].ToString();
                string medicalHistory = row["Medical_History"].ToString();
                string phoneNumber = row["Phone_Number"].ToString();
                string homeNumber = row["Home_Number"].ToString();
                string email = row["Email"].ToString();
                DateTime createdDate = Convert.ToDateTime(row["Created_Date"].ToString());
                DateTime updatedDate = Convert.ToDateTime(row["Update_Date"].ToString());
                string recordDisabled = row["Record_Disabled"].ToString();


                patient = new PatientRecord(patientID, firstName, lastName,
                    NRIC, DOB,sex, nationality, citizenship,
                    postalCode, address,
                    allergies, medicalHistory,
                    phoneNumber, homeNumber, email,
                    createdDate, updatedDate,
                    recordDisabled
                    );
            }
            return patient;
        }


        //todo
        public int UpdatePatientByID(
            int patientID, string fname, string lname, 
            string nric, string sex, DateTime dob,
            string nationality, string citizenship, 
            string postalCode, string address, string allergies, 
            string medicalHistory, 
            string phoneNumber, string homeNumber, 
            string email, DateTime update_date)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "UPDATE PATIENT " +
                             "SET First_Name = @parafName," +
                             "Last_Name = @paralName," +
                             "NRIC = @paraNRIC," +
                             "Sex = @paraSex," +
                             "DOB = @paraDOB," +
                             "Nationality = @paraNationality," +
                             "Citizenship = @paraCitizenship," +
                             "Postal_Code = @paraPostalCode," +
                             "Address = @paraAddress," +
                             "Allergies = @paraAllergies," +
                             "Medical_History = @paraMedicalHistory," +
                             "Phone_Number = @paraPhoneNumber," +
                             "Home_Number = @paraHomeNumber," +
                             "Email = @paraEmail," +
                             "Update_Date = @paraUpdateDate " +
                             "WHERE Patient_ID = @paraPatientID;";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
            sqlCmd.Parameters.AddWithValue("@parafName", fname);
            sqlCmd.Parameters.AddWithValue("@paralName", lname);
            sqlCmd.Parameters.AddWithValue("@paraNRIC", nric); 
            sqlCmd.Parameters.AddWithValue("@paraDOB", dob);
            sqlCmd.Parameters.AddWithValue("@paraSex", sex);
            sqlCmd.Parameters.AddWithValue("@paraNationality", nationality);
            sqlCmd.Parameters.AddWithValue("@paraCitizenship", citizenship);
            sqlCmd.Parameters.AddWithValue("@paraPostalCode", postalCode);
            sqlCmd.Parameters.AddWithValue("@paraAddress", address);
            sqlCmd.Parameters.AddWithValue("@paraAllergies", allergies);
            sqlCmd.Parameters.AddWithValue("@paraMedicalHistory", medicalHistory);
            sqlCmd.Parameters.AddWithValue("@paraPhoneNumber", phoneNumber);
            sqlCmd.Parameters.AddWithValue("@paraHomeNumber", homeNumber);
            sqlCmd.Parameters.AddWithValue("@paraEmail", email);
            sqlCmd.Parameters.AddWithValue("@paraUpdateDate", update_date);
            sqlCmd.Parameters.AddWithValue("@paraPatientID", patientID);


            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }

        public int DisablePatientByID(int patientID)
        {
           string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
           SqlConnection myConn = new SqlConnection(DBConnect);
           string sqlStmt = "UPDATE PATIENT " +
                "SET Record_Disabled = 'true' " +
                "WHERE Patient_ID = @paraPatientID;";
           SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
           sqlCmd.Parameters.AddWithValue("@paraPatientID", patientID);

           myConn.Open();
           int result = sqlCmd.ExecuteNonQuery();
           myConn.Close();

           return result;
        }

    }
}
