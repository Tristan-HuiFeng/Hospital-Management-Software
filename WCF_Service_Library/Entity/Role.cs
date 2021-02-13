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
    public class Role
    {
        public string ID { get; set; }
        public string name { get; set; }

        public Role() { }
        public Role(string id, string name)
        {
            this.ID = id;
            this.name = name;
        }


        public List<Role> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from AspNetRoles";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Role> roleList = new List<Role>();
            int rec_cnt = ds.Tables[0].Rows.Count;

            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                string obj_id = row["Id"].ToString();
                string obj_name = row["Name"].ToString();
               

                Role obj = new Role(obj_id, obj_name);
                roleList.Add(obj);
            }
            return roleList;
        }

        public Role SelectRoleById(string roleID)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from AspNetRoles where Id=@paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", roleID);

            DataSet ds = new DataSet();
            da.Fill(ds);

            Role role = new Role();
            int rec_cnt = ds.Tables[0].Rows.Count;

            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string obj_id = row["Id"].ToString();
                string obj_name = row["Name"].ToString();

                role = new Role(obj_id, obj_name);
            }
            return role;
        }

        public DataTable SelectAllRoleTableView()
        {
            /*
            string DBConnect = ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from AspNetRoles";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            int rec_cnt = ds.Tables[0].Rows.Count;
            DataTable dt = new DataTable();
            dt.TableName = "RoleList";

            dt.Columns.Add("Role_Name");
            dt.Columns.Add("Role_ID");
            //dt.Columns.Add("num_user");

            for (int i = 0; i < rec_cnt; i++)
            {
                var dr = dt.NewRow();

                DataRow row = ds.Tables[0].Rows[i];
                string obj_id = row["Id"].ToString();
                string obj_name = row["Name"].ToString();

                dr["Role_Name"] = obj_name;
                dr["Role_ID"] = obj_id;
                dt.Rows.Add(dr);

            }

            return dt;*/

            string DBConnect = ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;

            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                string sqlStmt = "Select * from AspNetRoles";

                using (SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    int rec_cnt = ds.Tables[0].Rows.Count;
                    DataTable dt = new DataTable();
                    dt.TableName = "RoleList";

                    dt.Columns.Add("Role_Name");
                    dt.Columns.Add("Role_ID");
                    //dt.Columns.Add("num_user");

                    for (int i = 0; i < rec_cnt; i++)
                    {
                        var dr = dt.NewRow();

                        DataRow row = ds.Tables[0].Rows[i];
                        string obj_id = row["Id"].ToString();
                        string obj_name = row["Name"].ToString();

                        dr["Role_Name"] = obj_name;
                        dr["Role_ID"] = obj_id;
                        dt.Rows.Add(dr);

                    }

                    return dt;
                }
            }


        }



        /*
        public void updateRoleStatusById(string roleID, bool isDisabled)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;

            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                using (SqlCommand command = new SqlCommand("Update AspNetRoles SET isRoleDisabled=@paraIsRoleDisabled where Id=@paraRoleID", myConn))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@paraRoleID", roleID);
                    command.Parameters.AddWithValue("@paraIsRoleDisabled", isDisabled);
                    myConn.Open();
                    command.ExecuteNonQuery();
                    myConn.Close();
                }
            }
        }*/
    }
}
