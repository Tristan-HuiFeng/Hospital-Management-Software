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

        /* Start of Health Professional's stuffs */
        /* Start of Hui Feng's code */

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
        DataTable GetMedicalRecordTableView();
        /* Health Professional's stuffs */
        /* End of Hui Feng's code */

        // Management
        [OperationContract]
        List<Employee> GetAllEmployee();

        [OperationContract]
        List<Employee> GetEmployeeByName(string name);

        [OperationContract]
        List<Employee> GetEmployeeSortedByDOB(int order);

        [OperationContract]
        List<Employee> GetEmployeeSortedByGender(int order);

        [OperationContract]
        List<Employee> GetEmployeeByNRIC(string nric);

        [OperationContract]
        int CreateEmployee(string nric, string firstname, string lastname, string email,
            DateTime dob, char gender, string address, string department,
            string position, string nationality, string healthdeclaration,
            string loginid, string password, string jobfunction, string image);

        [OperationContract]
        int UpdateEmployee(string nric, string firstname, string lastname, string email,
            DateTime dob, char gender, string address, string department,
            string position, string nationality, string healthdeclaration,
            string loginid, string password, string jobfunction, string image);

        [OperationContract]
        string GetEmployeeID(string nric);

        [OperationContract]
        int CreateContract(string salary, string benefits, string workingHours, string holidays, string vacation, DateTime create_date, string employeeID);

        [OperationContract]
        List<ContractRecord> GetContractByEmployeeID(string id);

        

     


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
