using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WCF_Service_Library.Entity
{
    public class UserAccount
    {

        public string name { get; set; }

        public string department { get; set; }

        public string position { get; set; }

        public string user_id { get; set; }

        public string role_id { get; set; }

        public string role_name { get; set; }

        public string status { get; set; }


        public UserAccount()
        {

        }

        public UserAccount(string user_id, string role_id, string role_name, string name, string department, string position, string status)
        {
            this.user_id = user_id;
            this.role_id = role_id;
            this.role_name = role_name;
            this.name = name;
            this.department = department;
            this.position = position;
            this.status = status;

        }

        // HF start

        //old authentication
        public string[] getAccountInfromation(string loginID)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from EMPLOYEE where Login_ID = @paraLoginID";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraLoginID", loginID);

            DataSet ds = new DataSet();
            da.Fill(ds);

            int rec_cnt = ds.Tables[0].Rows.Count;
            string[] account = new string[2];


            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string obj_LoginName = row["Login_ID"].ToString();
                string obj_Password = row["Password"].ToString();
                account[0] = obj_LoginName;
                account[1] = obj_Password;

            }
            return account;
        }

        public UserAccount getAccountInfromationByID(string role_id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select ANU.Id AS user_id, ANR.Name AS role_name, ANUR.RoleId AS role_id, concat(EMP.First_Name, ' ', EMP.Last_Name) name, " +
                "EMP.Department AS department, EMP.Position AS position, ANU.isUserDisabled AS status " +
                "from AspNetUsers AS ANU " +
                "Inner join AspNetUserRoles AS ANUR on ANUR.UserId = ANU.Id " +
                "Inner join EMPLOYEE AS EMP on EMP.ASPNET_ID = ANU.Id " +
                "Inner join AspNetRoles AS ANR on ANR.Id = ANUR.RoleId " +
                "where ANU.Id = @paraRoleID " +
                "Order by EMP.Employee_ID";


            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraRoleID", role_id);

            DataSet ds = new DataSet();
            da.Fill(ds);

            int rec_cnt = ds.Tables[0].Rows.Count;
            string[] account = new string[2];

            UserAccount myUserAccount = null;

            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];

                string obj_userID = row["user_id"].ToString();
                string obj_roleName = row["role_name"].ToString();
                string obj_roleID = row["role_id"].ToString();
                string obj_name = row["name"].ToString();
                string obj_department = row["department"].ToString();
                string obj_position = row["position"].ToString();

                string obj_status = "";

                if (row["status"] == Convert.DBNull)
                {
                    obj_status = "Active";
                }
                else
                {
                    obj_status = Convert.ToBoolean(row["status"]) ? "Disabled" : "Active";
                }


                myUserAccount = new UserAccount(obj_userID, obj_roleID, obj_roleName, obj_name, obj_department, obj_position, obj_status);
            }
            return myUserAccount;
        }

        public DataTable SelectRoleListTableViewByRoleID(string role_id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select ANU.Id AS user_id, ANR.Name AS role_name,  concat(EMP.First_Name, ' ', EMP.Last_Name) name, EMP.Department " +
                "from AspNetUsers AS ANU " +
                "Inner join AspNetUserRoles AS ANUR on ANUR.UserId = ANU.Id " +
                "Inner join EMPLOYEE AS EMP on EMP.ASPNET_ID = ANU.Id " +
                "Inner join AspNetRoles AS ANR on ANR.Id = ANUR.RoleId " +
                "where ANUR.RoleId = @paraRoleID " +
                "Order by EMP.Employee_ID";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraRoleID", role_id);

            DataTable dt = new DataTable();
            dt.TableName = "UserRoleList";
            da.Fill(dt);

            return dt;
        }

        public DataTable SelectAllUserListTableView()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select ANU.Id AS AccountID, concat(EMP.First_Name, ' ', EMP.Last_Name) Name, ANR.Name AS Role, EMP.Department AS Department " +
                "from AspNetUsers AS ANU " +
                "Inner join AspNetUserRoles AS ANUR on ANUR.UserId = ANU.Id " +
                "Inner join EMPLOYEE AS EMP on EMP.ASPNET_ID = ANU.Id " +
                "Inner join AspNetRoles AS ANR on ANR.Id = ANUR.RoleId " +
                "Order by EMP.Employee_ID";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            DataTable dt = new DataTable();
            dt.TableName = "UserList";
            da.Fill(dt);

            return dt;
        }

        public void updateUserAccountStatusById(string user_id, bool status)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;

            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                using (SqlCommand command = new SqlCommand("Update AspNetUsers SET isUserDisabled=@paraIsUserDisabled where Id=@paraUserID", myConn))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@paraUserID", user_id);
                    command.Parameters.AddWithValue("@paraIsUserDisabled", status);
                    myConn.Open();
                    command.ExecuteNonQuery();
                    myConn.Close();
                }
            }
        }

        public DataTable selectAllNoAccountUser()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;

            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                string sqlstmt = "Select concat(First_Name, ' ', Last_Name) name, Employee_ID, Department, Email " +
                   "from EMPLOYEE " +
                   "where ASPNET_ID is NULL " +
                   "Order by Employee_ID";
                using (SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int rec_cnt = ds.Tables[0].Rows.Count;
                    DataTable dt = new DataTable();

                    dt.TableName = "noAccList";
                    dt.Columns.Add("name");
                    dt.Columns.Add("employee_id");
                    dt.Columns.Add("department");
                    dt.Columns.Add("email");

                    for (int i = 0; i < rec_cnt; i++)
                    {
                        var dr = dt.NewRow();

                        DataRow row = ds.Tables[0].Rows[i];
                        string obj_name = row["name"].ToString();
                        string obj_empID = row["Employee_ID"].ToString();
                        string obj_department = row["Department"].ToString();
                        string obj_email = row["Email"].ToString();


                        dr["name"] = obj_name;
                        dr["employee_id"] = obj_empID;
                        dr["department"] = obj_department;
                        dr["email"] = obj_email;
                        dt.Rows.Add(dr);

                    }
                    return dt;

                }
                    


            }
        }

        public string[] getAccountCreationDetails(string emp_id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;

            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                string sqlstmt = "Select concat(First_Name, ' ', Last_Name) name, Employee_ID, Department, Email " +
                   "from EMPLOYEE " +
                   "where Employee_ID = @paraID";

                using (SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@paraID",Convert.ToInt32(emp_id));

                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int rec_cnt = ds.Tables[0].Rows.Count;
                    string[] account = new string[4];

                    if (rec_cnt == 1)
                    {

                        DataRow row = ds.Tables[0].Rows[0];
                        string obj_name = row["name"].ToString();
                        string obj_empID = row["Employee_ID"].ToString();
                        string obj_department = row["Department"].ToString();
                        string obj_email = row["Email"].ToString();


                        account[0] = obj_name;
                        account[1] = obj_empID;
                        account[2] = obj_department;
                        account[3] = obj_email;

                    }
                    return account;

                }



            }
        }

        public void updateAccountCreationDetails(string asp_id, string emp_id)
        {
            
            string DBConnect = ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;

            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                using (SqlCommand command = new SqlCommand("Update Employee SET ASPNET_ID=@paraASPNETID where Employee_ID=@paraEmpID", myConn))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@paraASPNETID", asp_id);
                    command.Parameters.AddWithValue("@paraEmpID", emp_id);
                    myConn.Open();
                    command.ExecuteNonQuery();
                    myConn.Close();
                }
            }

        }

        public int getEmpIDusingAccID(string account_id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;

            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                string sqlstmt = "Select Employee_ID " +
                   "from EMPLOYEE " +
                   "where ASPNET_ID = @paraID";

                using (SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@paraID", account_id);

                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int rec_cnt = ds.Tables[0].Rows.Count;
                    int emp_id = -1;

                    if (rec_cnt == 1)
                    {

                        DataRow row = ds.Tables[0].Rows[0];

                        emp_id = Convert.ToInt32(row["Employee_ID"]);


                    }

                    return emp_id;

                }



            }
        }

        // HF end


    }





}
