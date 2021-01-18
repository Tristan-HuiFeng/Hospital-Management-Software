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
            return 1;
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            int Error = ValidateInput();
            if (Error == 0)
            {
                ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();


            }
        }
    }
}