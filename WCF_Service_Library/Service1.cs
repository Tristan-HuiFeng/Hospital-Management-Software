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

        /* Start of Health Professional's stuffs */
        /* Start of Hui Feng's code */

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

        public List<MedicalRecord> GetAllMedicalRecordByEmployeeID(int empID)
        {
            MedicalRecord mr = new MedicalRecord();
            List<MedicalRecord> objList = mr.SelectByEmployeeID(empID);
            return objList;
        }

        public MedicalRecord GetMedicalRecordByID(int id)
        {
            MedicalRecord mr = new MedicalRecord();
            return mr.SelectByMedicalRecordID(id);
        }

        public List<MedicalRecord> GetAllMedicalRecord()
        {
            MedicalRecord mr = new MedicalRecord();
            return mr.SelectAll();
        }
        public DataTable GetMedicalRecordTableView()
        {
            MedicalRecord mr = new MedicalRecord();
            return mr.SelectAllTableView();
        }

        public string[] GetAccountInformation(string LoginID)
        {
            UserAccount ua = new UserAccount();
            return ua.getAccountInfromation(LoginID);
        }

        public DataTable GetRoleUserListTableView(string role_id)
        {

            UserAccount ua = new UserAccount();
            return ua.SelectAllRoleListTableView(role_id);

        }

        public List<Role> GetRoleList()
        {

            Role rl = new Role();
            return rl.SelectAll();

        }

        public List<Role> GetRoleList2()
        {

            Role rl = new Role();
            return rl.SelectAll();

        }


        public DataTable GetRoleList_TableView()
        {

            Role rl = new Role();
            return rl.SelectAllRoleTableView();

        }

        public Role GetRoleByID(string roleID)
        {
            Role rl = new Role();
            return rl.SelectRoleById(roleID);
        }

        public UserAccount GetUserAccountByID(string user_id)
        {
            UserAccount ua = new UserAccount();
            return ua.getAccountInfromationByID(user_id);
        }

        public void updateUserAccStatus(string userID, bool isDisabled)
        {
            UserAccount ua = new UserAccount();
            ua.updateUserAccountStatusById(userID, isDisabled);
        }

        public DataTable GetNoAccUserList_TableView()
        {
            UserAccount ua = new UserAccount();
            return ua.selectAllNoAccountUser();
        }

        public string[] creationDetailsByEmpID(string emp_id)
        {
            UserAccount ua = new UserAccount();
            return ua.getAccountCreationDetails(emp_id);
        }

        public void updateAccountCreationDetails(string asp_id, string emp_id)
        {
            UserAccount ua = new UserAccount();
            ua.updateAccountCreationDetails(asp_id, emp_id);
        }

        /* Health Professional's stuffs */

        /*
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
          public void updateRoleStatus(string roleID, bool isDisabled)
            {
                Role rl = new Role();
                rl.updateRoleStatusById(roleID, isDisabled);
            }
         */

        /* End of Hui Feng's code */

        // Management
        public List<Employee> GetAllEmployee()
        {
            Employee emp = new Employee();
            return emp.SelectAll();
        }

        public List<Employee> GetEmployeeByName(string name)
        {
            Employee emp = new Employee();
            return emp.SelectByName(name);
        }

        public List<Employee> GetEmployeeSortedByDOB(int order)
        {
            Employee emp = new Employee();
            return emp.SelectSortByDOB(order);
        }

        public List<Employee> GetEmployeeSortedByGender(int order)
        {
            Employee emp = new Employee();
            return emp.SelectSortByGender(order);
        }

        public tempPatient GetPatientByID(string id)
        {
            tempPatient tp = new tempPatient();
            return tp.SelectPatientById(id);
        }


        public int CreateMedicalRecord(string bloodPressure, string respirationRate, string bodyTemperature, string pulseRate, string diagnosis, string treatment,
            DateTime consultationDate, int doctorID, int patientID, string prescription, string remarks)
        {
            MedicalRecord mr = new MedicalRecord(-1, bloodPressure, respirationRate, bodyTemperature, pulseRate, diagnosis, treatment,
                consultationDate, patientID, doctorID, prescription, remarks);
            return mr.Insert();
        }

        public List<Employee> GetEmployeeByNRIC(string nric)
        {
            Employee emp = new Employee();
            return emp.SelectByNRIC(nric);
        }

        public int CreateEmployee(string nric, string firstname, string lastname, string email,
            DateTime dob, char gender, string address, string department,
            string position, string nationality, string healthdeclaration,
            string loginid, string password, string jobfunction, string image)
        {
            Employee emp = new Employee(nric, firstname, lastname, email, dob, gender,
                    address, department, position, nationality, healthdeclaration, loginid, password, jobfunction, image);
            return emp.Insert();
        }

        public int UpdateEmployee(string nric, string firstname, string lastname, string email,
            DateTime dob, char gender, string address, string department,
            string position, string nationality, string healthdeclaration,
            string loginid, string password, string jobfunction, string image)
        {
            Employee emp = new Employee(nric, firstname, lastname, email, dob, gender,
                    address, department, position, nationality, healthdeclaration, loginid, password, jobfunction, image);
            return emp.Update(nric);
        }

        public string GetEmployeeID(string nric)
        {
            Employee emp = new Employee();
            return emp.GetEmployeeID(nric);
        }

        public int CreateContract(string salary, string benefits, string workingHours, string holidays, string vacation, DateTime create_date, string employeeID)
        {
            string signature = "";
            ContractRecord cr = new ContractRecord(salary, benefits, workingHours, holidays, vacation, create_date, employeeID, signature);
            return cr.Insert();
        }

        public List<ContractRecord> GetContractByEmployeeID(string id)
        {
            ContractRecord cr = new ContractRecord();
            return cr.SelectByEmployeeID(id);
        }

        public int CreateBankRecord(string bankName, string bankAccountNumber, string bankHolderName, int employeeID)
        {
            BankRecord br = new BankRecord(bankName, bankAccountNumber, bankHolderName, employeeID);
            return br.Insert();
        }

        public List<BankRecord> GetBankRecordByEmployeeID(int employeeID)
        {
            BankRecord br = new BankRecord();
            return br.SelectByEmployeeID(employeeID);
        }

        public int CreatePayroll(decimal salary, decimal bonusAmount, string processedDate, DateTime createdDate, int employeeID, int bankDetailID, string processed, string overtimeDetails)
        {
            PayrollRecord pr = new PayrollRecord(salary, bonusAmount, processedDate, createdDate, employeeID, bankDetailID, processed, overtimeDetails);
            return pr.Insert();
        }

        public string GetBankDetailID(string id)
        {
            BankRecord br = new BankRecord();
            return br.GetBankDetailID(id);
        }

        public List<PayrollRecord> GetAllPayroll()
        {
            PayrollRecord pr = new PayrollRecord();
            return pr.SelectAll();
        }

        public List<PayrollRecord> GetPayrollByID(string id)
        {
            PayrollRecord pr = new PayrollRecord();
            return pr.SelectByID(id);
        }

        public int ProcessPayrollByID(string id, string process)
        {
            PayrollRecord pr = new PayrollRecord();
            return pr.ProcessPayrollByID(id, process);
        }

        public List<PayrollRecord> GetPayrollBetweenDate(string firstDate, string secondDate)
        {
            PayrollRecord pr = new PayrollRecord();
            return pr.SelectPayrollBetweenDate(firstDate, secondDate);
        }
    }
}
