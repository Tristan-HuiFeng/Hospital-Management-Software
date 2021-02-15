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
        List<MedicalRecord> GetAllMedicalRecordByEmployeeID(int empID);

        [OperationContract]
        MedicalRecord GetMedicalRecordByID(int id);

        [OperationContract]
        List<MedicalRecord> GetAllMedicalRecord();
        
        [OperationContract]
        DataTable GetMedicalRecordTableView(int acc_id);

        [OperationContract]
        string[] GetAccountInformation(string LoginID);

        [OperationContract]
        DataTable GetRoleUserListTableView(string role_id);

        [OperationContract]
        List<RoleEntity> GetRoleList();

        [OperationContract]
        List<RoleEntity> GetRoleList2();

        [OperationContract]
        DataTable GetRoleList_TableView();

        [OperationContract]
        RoleEntity GetRoleByID(string roleID);

        [OperationContract]
        UserAccount GetUserAccountByID(string user_id);

        [OperationContract]
        void updateUserAccStatus(string userID, bool isDisabled);

        [OperationContract]
        DataTable GetNoAccUserList_TableView();

        [OperationContract]
        string[] creationDetailsByEmpID(string emp_id);

        [OperationContract]
        void updateAccountCreationDetails(string asp_id, string emp_id);

        [OperationContract]
        DataTable getAccountList();

        [OperationContract]
        int GetEmpIDByAccID(string accID);

        [OperationContract]
        DataTable GetEmailList(string target);

        /* Health Professional's stuffs */

        /*
        [OperationContract]
        List<Resource> GetAllResource();

        [OperationContract]
        List<RolePermission> GetAllRolePermission();
        
        [OperationContract]
        void updateRoleStatus(string roleID, bool isDisabled);*/

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
            /*string loginid, string password, */string jobfunction, string image);

        [OperationContract]
        int UpdateEmployee(string nric, string firstname, string lastname, string email,
            DateTime dob, char gender, string address, string department,
            string position, string nationality, string healthdeclaration,
            /*string loginid, string password, */string jobfunction, string image);

        [OperationContract]
        string GetEmployeeID(string nric);

        [OperationContract]
        int CreateContract(string salary, string benefits, string workingHours, string holidays, string vacation, DateTime create_date, string employeeID);

        [OperationContract]
        List<ContractRecord> GetContractByEmployeeID(string id);



        [OperationContract]
        tempPatient GetPatientByID(string id);

        [OperationContract]
        int CreateMedicalRecord(string bloodPressure, string respirationRate, string bodyTemperature, string pulseRate, string diagnosis, 
            string treatment, DateTime consultationDate, int doctorID, int patientID, string prescription, string remarks);

        //PatientRecord start
        [OperationContract]
        List<PatientRecord> GetAllPatientRecords();

        [OperationContract]
        PatientRecord GetPatientRecordByID(int patientID);

        [OperationContract]
        int CreatePatientRecord(
           int patientid, string firstname, string lastname,
           string NRIC, DateTime DOB, string sex,
           string nationality, string citizenship,
           string postalcode, string address,
           string allergies, string medicalhistory, string phonenumber,
           string homenumber, string email,
           DateTime createdDate, DateTime updateDate,
           string recordDisabled);

        [OperationContract]
        int DisablePatientByID(int patientID);

        [OperationContract]
        int UpdatePatientByID(
            int patientID, string fname, string lname,
            string nric, string sex, DateTime dob,
            string nationality, string citizenship,
            string postalCode, string address, string allergies,
            string medicalHistory,
            string phoneNumber, string homeNumber,
            string email, DateTime update_date);
        //PR ends
        [OperationContract]
        int CreateBankRecord(string bankName, string bankAccountNumber, string bankHolderName, int employeeID);

        [OperationContract]
        List<BankRecord> GetBankRecordByEmployeeID(int id);

        [OperationContract]
        int CreatePayroll(decimal salary, decimal bonusAmount, string processedDate, DateTime createdDate, int employeeID, int bankDetailID, string processed, string overtimeDetails);

        //[OperationContract]
        //List<PayrollRecord> GetPayrollByEmployeeID(int id);

        [OperationContract]
        string GetBankDetailID(string id);

        [OperationContract]
        List<PayrollRecord> GetAllPayroll();

        [OperationContract]
        List<PayrollRecord> GetPayrollByID(string id);

        [OperationContract]
        int ProcessPayrollByID(string id, string process);

        [OperationContract]
        List<PayrollRecord> GetPayrollBetweenDate(string firstDate, string secondDate);

        [OperationContract]
        List<BankRecord> GetBankRecordByBankID(int id);

        [OperationContract]
        int SetSignatureByID(string id, string signature);

        [OperationContract]
        List<ContractRecord> GetContractByID(string _id);

        [OperationContract]
        List<Employee> GetEmployeeByID(string id);

        [OperationContract]
        int CreateAttendance(string id, string date, string status, string reason);

        [OperationContract]
        List<AttendanceRecord> GetAttendanceByIDWithDate(string id, DateTime date);

        [OperationContract]
        int UpdateByIDWithDate(string id, DateTime _date, string status, string reason);

        [OperationContract]
        List<Employee> SelectByASPNETID(string id);
        /* Matt */
        [OperationContract]
        List<FeedbackList> GetAllFeedback();

        [OperationContract]
        int CreateFeedback(string name, string email, string subject, string feedback);
        /* Matt */
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
