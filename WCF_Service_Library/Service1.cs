using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_Service_Library.Entity;

namespace WCF_Service_Library
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public EquipmentServiceRecord GetEquipmentServiceRecordById(int id)
        {
            EquipmentServiceRecord esr = new EquipmentServiceRecord();
            return esr.SelectByID(id);
        }

        public List<EquipmentServiceRecord> GetEquipmentServiceRecordByEmployeeID(int empID)
        {
            EquipmentServiceRecord esr = new EquipmentServiceRecord();
            List<EquipmentServiceRecord> objList = esr.SelectByEmployeeID(empID);
            return objList;
        }

        public LabServiceRecord GetLabServiceRecordById(int id)
        {
            LabServiceRecord lsr = new LabServiceRecord();
            return lsr.SelectByID(id);
        }

        public List<LabServiceRecord> GetLabServiceRecordByEmployeeID(int empID)
        {
            LabServiceRecord lsr = new LabServiceRecord();
            List<LabServiceRecord> objList = lsr.SelectByEmployeeID(empID);
            return objList;
        }

        public List<Resource> GetAllResource()
        {
            Resource resource = new Resource();
            List<Resource> objList = resource.SelectAll();
            return objList;
        }

        public List<RolePermission> GetAllRolePermission()
        {
            RolePermission rp = new RolePermission();
            List<RolePermission> objList = rp.SelectAll();
            return objList;
        }

        public List<MedicalRecord> GetAllMedicalRecord()
        {
            MedicalRecord mr = new MedicalRecord();
            List<MedicalRecord> objList = mr.SelectAll();
            return objList;
        }

        public List<MedicalRecord> GetAllMedicalRecordByEmployeeID(int empID)
        {
            MedicalRecord mr = new MedicalRecord();
            List<MedicalRecord> objList = mr.SelectByEmployeeID(empID);
            return objList;
        }

        public List<PatientRecord> GetAllPatientRecords()
        {
            PatientRecord patients = new PatientRecord();
            return patients.SelectAll();
        }

        public PatientRecord GetPatientRecordByID(string patientID)
        {
            PatientRecord patient = new PatientRecord();
            return patient.SelectPatientByID(patientID);
        }

        public int CreatePatientRecord(
           string patientid,
           string firstname, string lastname,
           string NRIC, DateTime DOB, int age, string sex,
           string nationality, string citizenship,
           string postalcode, string address,
           string allergies, string medicalhistory, string phonenumber,
           string homenumber, string email,
           DateTime createdDate, DateTime updateDate)
        {
            PatientRecord patient = new PatientRecord(
                patientid, firstname, lastname, 
                NRIC, DOB, age, sex, 
                nationality, citizenship, 
                postalcode, address, 
                allergies, medicalhistory, 
                phonenumber, homenumber, email, 
                createdDate, updateDate);
            return patient.Insert();
        }


    }
}
