using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_Software.HealthProfessional
{
    public partial class CreateMedicalRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tb_patientFirstName.Attributes["disabled"] = "disabled";
            tb_patientLastName.Attributes["disabled"] = "disabled";
        }
    }
}