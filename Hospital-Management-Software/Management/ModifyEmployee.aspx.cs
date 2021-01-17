using Hospital_Management_Software.MyDBServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_Software
{
    public partial class ModifyEmployee : System.Web.UI.Page
    {
        static string healthdeclaration = "asd";
        static string EmployeeImage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nric = Request.QueryString["nric"];
                if (nric != null)
                {
                    List<Employee> eList = new List<Employee>();
                    MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                    eList = client.GetEmployeeByNRIC(nric).ToList<Employee>();

                    imgEmployee.ImageUrl = eList[0].Image;
                    EmployeeImage = eList[0].Image;
                    tbNric.Text = eList[0].Nric;
                    tbEmail.Text = eList[0].Email;
                    tbFname.Text = eList[0].FirstName;
                    tbLname.Text = eList[0].LastName;
                    tbDOB.Text = eList[0].DOB.ToShortDateString();
                    System.Diagnostics.Debug.WriteLine(eList[0].DOB.ToShortDateString());
                    switch (eList[0].Gender.ToString())
                    {
                        case "M":
                            ddlGender.SelectedIndex = 0;
                            break;
                        case "F":
                            ddlGender.SelectedIndex = 1;
                            break;
                    }
                    tbAddress.Text = eList[0].Address;
                    tbDepartment.Text = eList[0].Department;
                    tbPosition.Text = eList[0].Position;
                    tbNationality.Text = eList[0].Nationality;
                    if (eList[0].HealthDeclaration != "")
                    {
                        healthdeclaration = eList[0].HealthDeclaration;
                    }
                    else
                    {
                        btnViewHealthDeclaration.Enabled = false;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string nric = tbNric.Text;
            string firstname = tbFname.Text;
            string lastname = tbLname.Text;
            string email = tbEmail.Text;
            DateTime dob = Convert.ToDateTime(tbDOB.Text);
            char gender = char.Parse(ddlGender.SelectedValue);
            string address = tbAddress.Text;
            string department = tbDepartment.Text;
            string position = tbPosition.Text;
            string nationality = tbNationality.Text;
            string loginid = "";
            string password = "";
            string jobfunction = "";

            if (uploadMedical.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(uploadMedical.FileName);
                    uploadMedical.SaveAs(Server.MapPath("~/Management/HealthDeclaration/") + filename);
                    healthdeclaration = "~/Management/HealthDeclaration/" + filename;
                }
                catch (Exception ex)
                {

                }
            }

            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            System.Diagnostics.Debug.WriteLine("save button");
            System.Diagnostics.Debug.WriteLine(healthdeclaration);
            System.Diagnostics.Debug.WriteLine("save button");
            int cnt = client.UpdateEmployee(nric, firstname, lastname, email, dob, gender,
                        address, department, position, nationality, healthdeclaration, loginid, password, jobfunction, EmployeeImage);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Employee Saved!'); window.location='" + Request.ApplicationPath + "Management/Employees.aspx';", true);

        }

        protected void btnViewHealthDeclaration_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/pdf";
            System.Diagnostics.Debug.WriteLine("bruvhere");
            System.Diagnostics.Debug.WriteLine(healthdeclaration);
            System.Diagnostics.Debug.WriteLine("bruvhere");
            Response.WriteFile(healthdeclaration);
            Response.End();
        }

        protected void btnChangePhoto_Click(object sender, EventArgs e)
        {
            if (uploadPhoto.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(uploadPhoto.FileName);
                    uploadPhoto.SaveAs(Server.MapPath("~/Management/EmployeeImages/") + filename);
                    imgEmployee.ImageUrl = "~/Management/EmployeeImages/" + filename;
                    EmployeeImage = "~/Management/EmployeeImages/" + filename;
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employees");
        }
    }
}