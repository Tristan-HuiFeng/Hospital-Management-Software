using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Service_Library.Entity
{
    public class Employee
    {
        public string Nric { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
        public string HealthDeclaration { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string JobFunction { get; set; }
        public string Image { get; set; }

        public Employee()
        {

        }

        public Employee(string nric, string firstname, string lastname, string email, 
            DateTime dob, char gender, string address, string department, 
            string position, string nationality, string healthdeclaration, 
            string loginid, string password, string jobfunction, string image)
        {
            Nric = nric;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            DOB = dob;
            Gender = gender;
            Address = address;
            Department = department;
            Position = position;
            Nationality = nationality;
            HealthDeclaration = healthdeclaration;
            LoginID = loginid;
            Password = password;
            JobFunction = jobfunction;
            Image = image;
        }

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO Employee " +
                "VALUES (@paraNric, @paraFname, @paraLname, @paraEmail, @paraDOB, @paraGender, @paraAddress, @paraDepartment, " +
                "@paraPosition, @paraNationality, @paraHealth, @paraLoginID, @paraPassword, @paraJobFunc, @paraImage)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraNric", Nric);
            sqlCmd.Parameters.AddWithValue("@paraFname", FirstName);
            sqlCmd.Parameters.AddWithValue("@paraLname", LastName);
            sqlCmd.Parameters.AddWithValue("@paraEmail", Email);
            sqlCmd.Parameters.AddWithValue("@paraDOB", DOB);
            sqlCmd.Parameters.AddWithValue("@paraGender", Gender);
            sqlCmd.Parameters.AddWithValue("@paraAddress", Address);
            sqlCmd.Parameters.AddWithValue("@paraDepartment", Department);
            sqlCmd.Parameters.AddWithValue("@paraPosition", Position);
            sqlCmd.Parameters.AddWithValue("@paraNationality", Nationality);
            sqlCmd.Parameters.AddWithValue("@paraHealth", HealthDeclaration);
            sqlCmd.Parameters.AddWithValue("@paraLoginID", LoginID);
            sqlCmd.Parameters.AddWithValue("@paraPassword", Password);
            sqlCmd.Parameters.AddWithValue("@paraJobFunc", JobFunction);
            sqlCmd.Parameters.AddWithValue("@paraImage", Image);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public string GetEmployeeID(string _nric)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "select * from Employee where NRIC = @paraNric";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraNric", _nric);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            string id = "";
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                id = row["Employee_ID"].ToString();
            }
            return id;
        }

        public int Update(string nric)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "update employee " +
                "set NRIC = @paraNric, First_Name = @paraFname, Last_Name = @paraLname, Email = @paraEmail, DOB = @paraDOB, Sex = @paraGender, " +
                "Address = @paraAddress, Department = @paraDepartment, Position = @paraPosition, Nationality = @paraNationality, " +
                "Health_Declaration = @paraHealth, Login_ID = @paraLoginID, Password = @paraPassword, Job_Function = @paraJobFunc, Profile_Image = @paraImage " +
                "where NRIC = @paraNric";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraNric", nric);
            sqlCmd.Parameters.AddWithValue("@paraFname", FirstName);
            sqlCmd.Parameters.AddWithValue("@paraLname", LastName);
            sqlCmd.Parameters.AddWithValue("@paraEmail", Email);
            sqlCmd.Parameters.AddWithValue("@paraDOB", DOB);
            sqlCmd.Parameters.AddWithValue("@paraGender", Gender);
            sqlCmd.Parameters.AddWithValue("@paraAddress", Address);
            sqlCmd.Parameters.AddWithValue("@paraDepartment", Department);
            sqlCmd.Parameters.AddWithValue("@paraPosition", Position);
            sqlCmd.Parameters.AddWithValue("@paraNationality", Nationality);
            sqlCmd.Parameters.AddWithValue("@paraHealth", HealthDeclaration);
            sqlCmd.Parameters.AddWithValue("@paraLoginID", LoginID);
            sqlCmd.Parameters.AddWithValue("@paraPassword", Password);
            sqlCmd.Parameters.AddWithValue("@paraJobFunc", JobFunction);
            sqlCmd.Parameters.AddWithValue("@paraImage", Image);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public List<Employee> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Employee";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Employee> empList = new List<Employee>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string nric = row["NRIC"].ToString();
                string firstname = row["First_Name"].ToString();
                string lastname = row["Last_Name"].ToString();
                string email = row["Email"].ToString();
                DateTime dob = Convert.ToDateTime(row["DOB"]);
                char gender = Convert.ToChar(row["Sex"].ToString());
                string address = row["Address"].ToString();
                string department = row["Department"].ToString();
                string position = row["Position"].ToString();
                string nationality = row["Nationality"].ToString();
                string healthdeclaration = row["Health_Declaration"].ToString();
                string loginid = row["Login_ID"].ToString();
                string password = row["Password"].ToString();
                string jobfunction = row["Job_Function"].ToString();
                string image = row["Profile_Image"].ToString();
                Employee obj = new Employee(nric, firstname, lastname, email, dob, gender,
                    address, department, position, nationality, healthdeclaration, loginid, password, jobfunction, image);
                empList.Add(obj);
            }
            return empList;
        }

        public List<Employee> SelectByName(string name)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "select * from Employee where concat(first_name, ' ', last_name) like '%' + @paraName + '%'";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraName", name);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Employee> empList = new List<Employee>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string nric = row["NRIC"].ToString();
                string firstname = row["First_Name"].ToString();
                string lastname = row["Last_Name"].ToString();
                string email = row["Email"].ToString();
                DateTime dob = Convert.ToDateTime(row["DOB"]);
                char gender = Convert.ToChar(row["Sex"].ToString());
                string address = row["Address"].ToString();
                string department = row["Department"].ToString();
                string position = row["Position"].ToString();
                string nationality = row["Nationality"].ToString();
                string healthdeclaration = row["Health_Declaration"].ToString();
                string loginid = row["Login_ID"].ToString();
                string password = row["Password"].ToString();
                string jobfunction = row["Job_Function"].ToString();
                string image = row["Profile_Image"].ToString();
                Employee obj = new Employee(nric, firstname, lastname, email, dob, gender,
                    address, department, position, nationality, healthdeclaration, loginid, password, jobfunction, image);
                empList.Add(obj);
            }
            return empList;
        }

        public List<Employee> SelectByNRIC(string _nric)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "select * from Employee where nric = @paraNRIC";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraNRIC", _nric);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Employee> empList = new List<Employee>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string nric = row["NRIC"].ToString();
                string firstname = row["First_Name"].ToString();
                string lastname = row["Last_Name"].ToString();
                string email = row["Email"].ToString();
                DateTime dob = Convert.ToDateTime(row["DOB"]);
                char gender = Convert.ToChar(row["Sex"].ToString());
                string address = row["Address"].ToString();
                string department = row["Department"].ToString();
                string position = row["Position"].ToString();
                string nationality = row["Nationality"].ToString();
                string healthdeclaration = row["Health_Declaration"].ToString();
                string loginid = row["Login_ID"].ToString();
                string password = row["Password"].ToString();
                string jobfunction = row["Job_Function"].ToString();
                string image = row["Profile_Image"].ToString();
                Employee obj = new Employee(nric, firstname, lastname, email, dob, gender,
                    address, department, position, nationality, healthdeclaration, loginid, password, jobfunction, image);
                empList.Add(obj);
            }
            return empList;
        }

        public List<Employee> SelectSortByDOB(int order)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "";
            if (order == 1)
            {
                sqlStmt = "select * from employee order by dob desc";
            } else
            {
                sqlStmt = "select * from employee order by dob";

            }
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Employee> empList = new List<Employee>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string nric = row["NRIC"].ToString();
                string firstname = row["First_Name"].ToString();
                string lastname = row["Last_Name"].ToString();
                string email = row["Email"].ToString();
                DateTime dob = Convert.ToDateTime(row["DOB"]);
                char gender = Convert.ToChar(row["Sex"].ToString());
                string address = row["Address"].ToString();
                string department = row["Department"].ToString();
                string position = row["Position"].ToString();
                string nationality = row["Nationality"].ToString();
                string healthdeclaration = row["Health_Declaration"].ToString();
                string loginid = row["Login_ID"].ToString();
                string password = row["Password"].ToString();
                string jobfunction = row["Job_Function"].ToString();
                string image = row["Profile_Image"].ToString();
                Employee obj = new Employee(nric, firstname, lastname, email, dob, gender,
                    address, department, position, nationality, healthdeclaration, loginid, password, jobfunction, image);
                empList.Add(obj);
            }
            return empList;
        }

        public List<Employee> SelectSortByGender(int order)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "";
            if (order == 1)
            {
                sqlStmt = "select * from employee order by sex desc";
            }
            else
            {
                sqlStmt = "select * from employee order by sex";

            }
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Employee> empList = new List<Employee>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string nric = row["NRIC"].ToString();
                string firstname = row["First_Name"].ToString();
                string lastname = row["Last_Name"].ToString();
                string email = row["Email"].ToString();
                DateTime dob = Convert.ToDateTime(row["DOB"]);
                char gender = Convert.ToChar(row["Sex"].ToString());
                string address = row["Address"].ToString();
                string department = row["Department"].ToString();
                string position = row["Position"].ToString();
                string nationality = row["Nationality"].ToString();
                string healthdeclaration = row["Health_Declaration"].ToString();
                string loginid = row["Login_ID"].ToString();
                string password = row["Password"].ToString();
                string jobfunction = row["Job_Function"].ToString();
                string image = row["Profile_Image"].ToString();
                Employee obj = new Employee(nric, firstname, lastname, email, dob, gender,
                    address, department, position, nationality, healthdeclaration, loginid, password, jobfunction, image);
                empList.Add(obj);
            }
            return empList;
        }
    }
}
