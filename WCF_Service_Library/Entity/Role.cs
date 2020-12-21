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
    class Role
    {
        public int ID { get; set; }
        public string name { get; set; }

        public Role() { }
        public Role(int id, string name)
        {
            this.ID = id;
            this.name = name;
        }

        public List<Role> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from ROLE";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Role> roleList = new List<Role>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int obj_id = Convert.ToInt32(row["Role_ID"]);
                string obj_name = row["Role_Name"].ToString();
                Role obj = new Role(obj_id, obj_name);
                roleList.Add(obj);
            }
            return roleList;
        }
    }
}
