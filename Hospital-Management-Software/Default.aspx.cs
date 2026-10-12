using System;
using System.Collections.Generic;
using System.Web.UI;
using Hospital_Management_Software.Models;
using Hospital_Management_Software.Services;

namespace Hospital_Management_Software
{
    public partial class _Default : Page
    {
        private readonly HospitalDashboardService _dashboardService = new HospitalDashboardService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSections();
            }
        }

        public IList<HospitalDashboardSection> Sections
        {
            get;
            private set;
        }

        private void BindSections()
        {
            Sections = _dashboardService.GetSections();
            SectionRepeater.DataSource = Sections;
            SectionRepeater.DataBind();
            DataBind();
        }
    }
}