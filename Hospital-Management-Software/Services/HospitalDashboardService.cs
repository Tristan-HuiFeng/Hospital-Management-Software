using System.Collections.Generic;
using Hospital_Management_Software.Models;

namespace Hospital_Management_Software.Services
{
    public class HospitalDashboardService
    {
        public IList<HospitalDashboardSection> GetSections()
        {
            return new List<HospitalDashboardSection>
            {
                new HospitalDashboardSection(
                    "Patient Experience",
                    "A streamlined patient journey from registration to follow-up, designed to reduce administrative friction.",
                    "🏥",
                    new[]
                    {
                        "Appointment scheduling",
                        "Record updates",
                        "Transparent service pricing"
                    }),
                new HospitalDashboardSection(
                    "Clinical Operations",
                    "Clear hospital workflows for doctors and staff so patient information stays organised and accessible.",
                    "🩺",
                    new[]
                    {
                        "Medical record visibility",
                        "Queue and task coordination",
                        "Role-based access controls"
                    }),
                new HospitalDashboardSection(
                    "Administration",
                    "Operational systems that support staff planning, payroll and communication without unnecessary complexity.",
                    "📋",
                    new[]
                    {
                        "Employee workflows",
                        "Contract and payroll management",
                        "Broadcast notifications"
                    })
            };
        }
    }
}
