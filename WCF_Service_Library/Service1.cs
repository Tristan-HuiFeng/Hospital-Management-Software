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
        /* Health Professional's stuffs */
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
            ContractRecord cr = new ContractRecord(salary, benefits, workingHours, holidays, vacation, create_date, employeeID);
            return cr.Insert();
        }

        public List<ContractRecord> GetContractByEmployeeID(string id)
        {
            ContractRecord cr = new ContractRecord();
            return cr.SelectByEmployeeID(id);
        }

        /* Matt */
        public List<FeedbackList> GetAllFeedback()
        {
            FeedbackList emp = new FeedbackList();
            return emp.GetAllFeedback();
        }

        public int CreateFeedback(string name, string email, string subject, string feedback)
        {
            FeedbackList emp = new FeedbackList(name, email, subject, feedback);
            return emp.Insert();
        }
        /* Matt */
    }
}
