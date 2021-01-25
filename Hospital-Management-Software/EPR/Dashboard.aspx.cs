using Hospital_Management_Software.MyDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_Software.Views.EPR
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshGridView();
        }

        private void RefreshGridView()
        {
            List<PatientRecord> eList = new List<PatientRecord>();
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            eList = client.GetAllPatientRecords().ToList<PatientRecord>();

            // using gridview to bind to the list of employee objects
            GV_patients.Visible = true;
            GV_patients.DataSource = eList;
            GV_patients.DataBind();
        }

        

        protected void GV_patients_RowDeleting(object sender, EventArgs e)
        {
            GridViewRow row = GV_patients.SelectedRow;
            // The first cell (index 0) contains the TD Account.
            Session["SSTDAcNo"] = row.Cells[0].Text;
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();

        }
    }
}