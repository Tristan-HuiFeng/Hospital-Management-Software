using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_Service_Library.Entity;
using System.Data;

namespace WCF_Service_Library
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations heres

        [OperationContract]
        EquipmentServiceRecord GetEquipmentServiceRecordById(int id);

        [OperationContract]
        List<EquipmentServiceRecord> GetEquipmentServiceRecordByEmployeeID(int empID);

        [OperationContract]
        LabServiceRecord GetLabServiceRecordById(int id);

        [OperationContract]
        List<LabServiceRecord> GetLabServiceRecordByEmployeeID(int empID);

        [OperationContract]
        List<Resource> GetAllResource();

        [OperationContract]
        List<RolePermission> GetAllRolePermission();

        [OperationContract]
        List<MedicalRecord> GetAllMedicalRecordByEmployeeID(int empID);

        [OperationContract]
        List<MedicalRecord> GetAllMedicalRecord();

        [OperationContract]
        List<PatientRecord> GetAllPatientRecords();

        [OperationContract]
        PatientRecord GetPatientRecordByID(int patientID);

        [OperationContract]
        int CreatePatientRecord(
           int patientid, string firstname, string lastname,
           string NRIC, DateTime DOB, int age, string sex,
           string nationality, string citizenship,
           string postalcode, string address,
           string allergies, string medicalhistory, string phonenumber,
           string homenumber, string email,
           DateTime createdDate, DateTime updateDate,
           string recordDisabled);

        [OperationContract]
        int DisablePatientByID(int patientID);

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WCF_Service_Library.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
