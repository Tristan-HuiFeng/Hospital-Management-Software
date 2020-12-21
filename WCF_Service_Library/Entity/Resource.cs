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
    public class Resource
    {
        public int ID { get; set; }
        public string name { get; set; }

        public Resource() { }
        public Resource(int id, string name)
        {
            this.ID = id;
            this.name = name;
        }

        public List<Resource> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from RESOURCE";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Resource> resourceList = new List<Resource>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  
                int obj_id = Convert.ToInt32(row["Resource_ID"]);
                string obj_name = row["Resource_Name"].ToString();
                Resource obj = new Resource(obj_id, obj_name);
                resourceList.Add(obj);
            }
            return resourceList;
        }

    }
}
