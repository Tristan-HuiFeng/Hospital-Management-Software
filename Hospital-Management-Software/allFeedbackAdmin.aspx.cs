﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace EDP_Presentation
{
    public partial class allFeedbackAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            string message = "Are you sure you resolved these feedback?";
            string title = "Resolved feedback";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                // if yes, delete record and refresh the page
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            //else
            //{
            //    // Do something  
            //}

            //foreach (GridViewRow gvrow in GridView1.Rows)
            //{

            //    CheckBox chck = gvrow.FindControl("CheckBox1") as CheckBox;
            //    if (chck.Checked)
            //    {

            //    }
            //}
        }
    }
}