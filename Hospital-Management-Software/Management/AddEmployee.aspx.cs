﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_Software
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        static string EmployeeImage = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddPhoto_Click(object sender, EventArgs e)
        {
            string[] validFileTypes = { "png",  "jpeg" };
            string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            bool isValidFile = false;

            if (ext.Length < 1)
            {
                isValidFile = true;
            }
            else
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }

                if (!isValidFile)
                {
                    Label13.ForeColor = System.Drawing.Color.Red;
                    Label13.Text = "Invalid File. Please upload a File with extension " +
                                   string.Join(",", validFileTypes);
                }
                else
                {
                    Label13.ForeColor = System.Drawing.Color.Green;
                    Label13.Text = "File uploaded successfully.";
                }
            }

            if (FileUpload1.HasFile && isValidFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/Management/EmployeeImages/") + filename);
                    imgEmployee.ImageUrl = "~/Management/EmployeeImages/" + filename;
                    EmployeeImage = "~/Management/EmployeeImages/" + filename;
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            bool nricDoesNotExist = false;
            if (client.GetEmployeeByNRIC(tbNric.Text).ToList().Count < 1)
            {
                nricDoesNotExist = true;
            } else
            {
                Label12.Text = "NRIC already exist!";
            }

            string[] validFileTypes = { "pdf" };
            string ext = System.IO.Path.GetExtension(uploadMedical.PostedFile.FileName);
            bool isValidFile = false;

            if (ext.Length < 1)
            {
                isValidFile = true;
            } else
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }

                if (!isValidFile)
                {
                    Label12.ForeColor = System.Drawing.Color.Red;
                    Label12.Text = "Invalid File. Please upload a File with extension " +
                                   string.Join(",", validFileTypes);
                }
                else
                {
                    Label12.ForeColor = System.Drawing.Color.Green;
                    Label12.Text = "File uploaded successfully.";
                }
            }

            bool textboxValid = true;
            if (String.IsNullOrEmpty(tbNric.Text) || String.IsNullOrEmpty(tbEmail.Text) || String.IsNullOrEmpty(tbFname.Text) ||
                    String.IsNullOrEmpty(tbLname.Text) || String.IsNullOrEmpty(tbDOB.Text) || String.IsNullOrEmpty(tbAddress.Text) ||
                    String.IsNullOrEmpty(tbDepartment.Text) || String.IsNullOrEmpty(tbPosition.Text) || String.IsNullOrEmpty(tbNationality.Text))
            {
                textboxValid = false;
                Label12.Text = "Please make sure no fields are empty!";
            }

            if (Page.IsValid && isValidFile && textboxValid && nricDoesNotExist)
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
                string healthdeclaration = "";
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

                //MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                //System.Diagnostics.Debug.WriteLine(EmployeeImage);
                int cnt = client.CreateEmployee(nric, firstname, lastname, email, dob, gender,
                            address, department, position, nationality, healthdeclaration, /*loginid, password, */jobfunction, EmployeeImage);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Employee Created!'); window.location='" + Request.ApplicationPath + "Management/Employees.aspx';", true);

            }

        }

        private static readonly int[] Multiples = { 2, 7, 6, 5, 4, 3, 2 };

        public static bool IsNRICValid(string nric)
        {
            if (string.IsNullOrEmpty(nric))
            {
                return false;
            }

            //	check length must be 9 digits
            if (nric.Length != 9)
            {
                return false;
            }

            int total = 0
                , count = 0
                , numericNric;
            char first = nric[0]
                , last = nric[nric.Length - 1];

            // first chat alwatas T or S
            if (first != 'S' && first != 'T')
            {
                return false;
            }

            // ensure first chars is char and last

            if (!int.TryParse(nric.Substring(1, nric.Length - 2), out numericNric))
            {
                return false;
            }

            while (numericNric != 0)
            {
                total += numericNric % 10 * Multiples[Multiples.Length - (1 + count++)];

                numericNric /= 10;
            }

            char[] outputs;
            // first S, pickup different array( read specification)
            if (first == 'S')
            {
                outputs = new char[] { 'J', 'Z', 'I', 'H', 'G', 'F', 'E', 'D', 'C', 'B', 'A' };
            }
            // T pickup different arrary ( read specification)
            else
            {
                outputs = new char[] { 'G', 'F', 'E', 'D', 'C', 'B', 'A', 'J', 'Z', 'I', 'H' };
            }

            return last == outputs[total % 11];

        }

        protected void validateNRIC_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (IsNRICValid(args.Value))
            {
                args.IsValid = true;
            } else
            {
                args.IsValid = false;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employees");
        }
    }
}