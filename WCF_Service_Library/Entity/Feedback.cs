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
    public class FeedbackList
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Feedback { get; set; }

        public FeedbackList()
        {

        }

        public FeedbackList(string name, string email, string subject, string feedback)
        {
            Name = name;
            Email = email;
            Subject = subject;
            Feedback = feedback;
        }

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            // string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\roygo\Downloads\Hospital-Management-Software\Hospital-Management-Software\Hospital-Management-Software\App_Data\EDP_DB.mdf;Integrated Security=True");

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO FEEDBACK (name, email, subject, feedback, dateCreated) " +
                "VALUES (@paraName,@paraEmail, @paraSubject, @paraFeedback, @paraDateTime)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraName", Name);
            sqlCmd.Parameters.AddWithValue("@paraEmail", Email);
            sqlCmd.Parameters.AddWithValue("@paraSubject", Subject);
            sqlCmd.Parameters.AddWithValue("@paraFeedback", Feedback);
            sqlCmd.Parameters.AddWithValue("@paraDateTime", DateTime.Now);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public List<FeedbackList> GetAllFeedback()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from FEEDBACK";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<FeedbackList> empList = new List<FeedbackList>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string name = row["name"].ToString();
                string email = row["email"].ToString();
                string subject = row["subject"].ToString();
                string feedback = row["feedback"].ToString();
                FeedbackList obj = new FeedbackList(name, email, subject, feedback);
                empList.Add(obj);
            }
            return empList;
        }
    }
}
