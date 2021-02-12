using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_Software.Views.EPR
{
    public partial class UpdateEPR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lb_genMsg.Visible = true;
            lb_genMsg.Text = $"You are editing patient record with id number: {Session["patientID"]}";
            if (!Page.IsPostBack)
            {
                loadPatient();
            };
        }

        protected void loadPatient()
        {
            int patientId = Convert.ToInt32(Session["patientID"].ToString());
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            var patient = client.GetPatientRecordByID(patientId);

            //populate data
            tb_FirstName.Text = patient.firstName;
            tb_LastName.Text = patient.lastName;
            tb_DOB.Text = patient.DOB.ToString("yyyy-MM-dd");
            tb_NRIC.Text = patient.NRIC;
            tb_age.Text = calAge(patient.DOB).ToString();
            rad_Sex.SelectedValue = patient.sex;
            ddl_nationality.SelectedValue = patient.nationality;
            ddl_citizenship.SelectedValue = patient.citizenship;
            tb_PostalCode.Text = patient.postalCode;
            tb_Address.Text = patient.address;
            tb_Allergies.Text = patient.allergies;
            tb_MedicalConditon.Text = patient.medicalHistory;
            tb_phoneNumber.Text = patient.phoneNumber;
            tb_homeNumber.Text = patient.homeNumber;
            tb_email.Text = patient.email;
        }

        protected int savePatient()
        {
            int patientId = Convert.ToInt32(Session["patientID"].ToString());
            DateTime dob = Convert.ToDateTime(tb_DOB.Text);
            DateTime updatedDate = DateTime.Now;
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            System.Diagnostics.Debug.WriteLine("Reached client init"); 
            var result = client.UpdatePatientByID(
                    patientId, tb_FirstName.Text, tb_LastName.Text, tb_NRIC.Text,
                    rad_Sex.SelectedValue, dob,
                    ddl_nationality.SelectedValue, ddl_citizenship.SelectedValue,
                    tb_PostalCode.Text, tb_Address.Text,
                    tb_Allergies.Text, tb_MedicalConditon.Text,
                    tb_phoneNumber.Text, tb_homeNumber.Text, tb_email.Text, updatedDate);
            System.Diagnostics.Debug.WriteLine("Reached client saving");
            return result;
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            
            if (ValidateInput() == 0) {
                System.Diagnostics.Debug.WriteLine("Reached validation");
                var result = savePatient();
                if (result == 1) {
                    System.Diagnostics.Debug.WriteLine("Reached Saving");
                    Session["SuccessPatientMsg"] = $"Patient record for {tb_FirstName.Text} {tb_LastName.Text} has been updated.";
                    Session["patientID"] = null;
                    Response.Redirect("Dashboard", false);
                }
            }

        }

        private int ValidateInput()
        {
            int Error = 0;
            string fname = tb_FirstName.Text.ToString().Trim();
            string lname = tb_LastName.Text.ToString().Trim();
            string nric = tb_NRIC.Text.ToString().Trim();
            string postalCode = tb_PostalCode.Text.ToString().Trim();
            string address = tb_Address.Text.ToString().Trim();
            string allergies = tb_Allergies.Text.ToString().Trim();
            string medicalCondition = tb_MedicalConditon.Text.ToString().Trim();
            string phoneNumber = tb_phoneNumber.Text.ToString().Trim();
            string homeNumber = tb_homeNumber.Text.ToString().Trim();
            string email = tb_email.Text.ToString().Trim();

            if (String.IsNullOrEmpty(fname))
            {
                Error += 1;
                err_fName.Visible = true;
                err_fName.ForeColor = Color.Red;
                err_fName.Text = "Please enter a First Name.";
            }
            else
            {
                err_fName.Visible = false;
            }

            if (String.IsNullOrEmpty(lname))
            {
                Error += 1;
                err_lName.Visible = true;
                err_lName.ForeColor = Color.Red;
                err_lName.Text = "Please enter a Last Name.";
            }
            else
            {
                err_lName.Visible = false;
            }

            if (String.IsNullOrEmpty(nric))
            {
                Error += 1;
                err_NRIC.Visible = true;
                err_NRIC.ForeColor = Color.Red;
                err_NRIC.Text = "Please enter an NRIC.";
            }
            else if (!Regex.IsMatch(nric, "[STFG/d{7}A-Z]")) //check NRIC against regex
            {
                Error += 1;
                err_NRIC.Visible = true;
                err_NRIC.ForeColor = Color.Red;
                err_NRIC.Text = "Please enter an valid NRIC.";
            }
            else
            {
                err_NRIC.Visible = false;
            }

            if (String.IsNullOrEmpty(postalCode))
            {
                Error += 1;
                err_postalCode.Visible = true;
                err_postalCode.ForeColor = Color.Red;
                err_postalCode.Text = "Please enter a postal code.";
            }
            else if (!Regex.IsMatch(postalCode, "[/d{6}]")) //check postalCode against Regex
            {
                Error += 1;
                err_postalCode.Visible = true;
                err_postalCode.Text = "Please enter a valid postal code.";
            }
            else
            {
                err_postalCode.Visible = false;
            }

            if (String.IsNullOrEmpty(address))
            {
                Error += 1;
                err_Address.Visible = true;
                err_Address.ForeColor = Color.Red;
                err_Address.Text = "Pleae enter an Address";
            }
            else
            {
                err_Address.Visible = false;
            }

            if (String.IsNullOrEmpty(allergies))
            {
                Error += 1;
                err_Allergies.Visible = true;
                err_Allergies.ForeColor = Color.Red;
                err_Allergies.Text = "Pleae enter an allergy.<br>If there is none please enter Nil.";
            }
            else
            {
                err_Allergies.Visible = false;
            }

            if (String.IsNullOrEmpty(medicalCondition))
            {
                Error += 1;
                err_medicalCondition.Visible = true;
                err_medicalCondition.ForeColor = Color.Red;
                err_medicalCondition.Text = "Pleae enter a medical condition.<br>If there is none please enter Nil.";
            }
            else
            {
                err_medicalCondition.Visible = false;
            }

            if (String.IsNullOrEmpty(phoneNumber))
            {
                Error += 1;
                err_phoneNumber.Visible = true;
                err_phoneNumber.ForeColor = Color.Red;
                err_phoneNumber.Text = "Please enter a phone number.<br>If there is none please enter Nil.";
            }
            else
            {
                err_phoneNumber.Visible = false;
            }

            if (String.IsNullOrEmpty(homeNumber))
            {
                Error += 1;
                err_homeNumber.Visible = true;
                err_homeNumber.ForeColor = Color.Red;
                err_homeNumber.Text = "Please enter a home number.<br>If there is none please enter Nil.";
            }
            else
            {
                err_homeNumber.Visible = false;
            }

            if (String.IsNullOrEmpty(email))
            {
                Error += 1;
                err_Email.Visible = true;
                err_Email.ForeColor = Color.Red;
                err_Email.Text = "Please enter an email.<br>If there is none please enter Nil.";
            }
            else if (email != "Nil")
            {
                if (!IsValidEmail(email))
                {
                    Error += 1;
                    err_Email.Visible = true;
                    err_Email.ForeColor = Color.Red;
                    err_Email.Text = "Please enter a valid email address.";
                }
                err_Email.Visible = false;
            }


            if (rad_Sex.SelectedItem == null)
            {
                Error += 1;
                err_sex.Visible = true;
                err_sex.ForeColor = Color.Red;
                err_sex.Text = "Pleae select a gender.";
            }
            else
            {
                err_sex.Visible = false;
            }

            if (ddl_citizenship.SelectedValue == "select")
            {
                Error += 1;
                err_citizenship.Visible = true;
                err_citizenship.ForeColor = Color.Red;
                err_citizenship.Text = "Please select a citizenship.";
            }
            else
            {
                err_citizenship.Visible = false;
            }

            if (ddl_nationality.SelectedValue == "select")
            {
                Error += 1;
                err_country.Visible = true;
                err_country.ForeColor = Color.Red;
                err_country.Text = "Pleae select a nationality.";
            }
            else
            {
                err_country.Visible = false;
            }

            if (String.IsNullOrEmpty(tb_DOB.Text.ToString()))
            {
                Error += 1;
                err_DOB.Visible = true;
                err_DOB.ForeColor = Color.Red;
                err_DOB.Text = "Pleae enter a Date of Birth.";
            }
            else
            {
                DateTime DOB = Convert.ToDateTime(tb_DOB.Text);
                err_DOB.Visible = false;
                int age = calAge(DOB);
                tb_age.Text = age.ToString();
                if (!(DOB < DateTime.Today))
                {
                    Error += 1;
                    err_Age.Visible = true;
                    err_Age.ForeColor = Color.Red;
                    err_Age.Text = "Pleae enter a valid DOB";
                }
            }

            System.Diagnostics.Debug.WriteLine($"{Error}");
            return 0;
        }
        private int calAge(DateTime dob)
        {
            int age = 0;
            DateTime tdy = DateTime.Today;
            age = tdy.Year - dob.Year;

            return age;
        }
        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}