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
    public class RolePermission
    {
        public int resourceID { get; set; }
        public int roleID { get; set; }
        public bool view { get; set; }
        public bool add { get; set; }
        public bool edit { get; set; }
        public bool delete { get; set; }

        public RolePermission() { }
        public RolePermission(int resourceID, int roleID, bool view, bool add, bool edit, bool delete)
        {
            this.resourceID = resourceID;
            this.roleID = roleID;
            this.view = view;
            this.add = add;
            this.edit = edit;
            this.delete = delete;
        }

        public List<RolePermission> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from ROLE_PERMISSION";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<RolePermission> rolePermissionList = new List<RolePermission>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int obj_resourceID = Convert.ToInt32(row["Resource_ID"]);
                int obj_roleID = Convert.ToInt32(row["Role_ID"]);
                bool obj_view = Convert.ToBoolean(row["View"]);
                bool obj_add = Convert.ToBoolean(row["Add"]);
                bool obj_edit = Convert.ToBoolean(row["Edit"]);
                bool obj_delete = Convert.ToBoolean(row["Delete"]);
                RolePermission obj = new RolePermission(obj_resourceID, obj_roleID, obj_view, obj_add, obj_edit, obj_delete);
                rolePermissionList.Add(obj);
            }
            return rolePermissionList;
        }
    }
}
