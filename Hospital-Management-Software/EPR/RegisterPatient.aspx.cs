using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_Software.Views
{
    public partial class RegisterPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddl_nationality.DataSource = CountryList();
            ddl_nationality.DataBind();
        }

        public static List<string> CountryList()
        {
            //Creating List
            List<String> countries = new List<string>();

            // Getting the specific cultureInof from CultureInfo Class
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach( CultureInfo getCulture in getCultureInfo)
            {
                RegionInfo GetRegionInfo = new RegionInfo(getCulture.LCID);
                //add each country name into arraylist
                if (!(countries.Contains(GetRegionInfo.EnglishName)))
                {
                    countries.Add(GetRegionInfo.EnglishName);
                }
            }
            // sorting array by using sort method
            countries.Sort();
            return countries;
        }

        private int ValidateInput()
        {
            return 0;
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            int Error = ValidateInput();


            if (Error == 0)
            {
                Random rnd = new Random();
                int patientID = rnd.Next(1, 10000000);
                DateTime dob = Convert.ToDateTime(tb_DOB.Text);
                int age = Convert.ToInt32(tb_age.Text);
                DateTime createdDate = DateTime.Now;
                DateTime updatedDate = createdDate;

                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                int result = client.CreatePatientRecord(patientID,tb_FirstName.Text, tb_LastName.Text, tb_NRIC.Text, dob,age,rad_Sex.SelectedValue,ddl_nationality.SelectedValue, ddl_citizenship.SelectedValue, tb_PostalCode.Text, tb_Address.Text, tb_Allergies.Text, tb_MedicalConditon.Text, tb_phoneNumber.Text, tb_homeNumber.Text, tb_email.Text, createdDate, updatedDate);
                if (result == 1)
                {
                    Response.Redirect("Dashboard");
                }
            }
        }
    }
}