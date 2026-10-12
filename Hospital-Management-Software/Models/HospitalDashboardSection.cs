using System.Collections.Generic;

namespace Hospital_Management_Software.Models
{
    public class HospitalDashboardSection
    {
        public HospitalDashboardSection(string title, string description, string icon, IEnumerable<string> highlights)
        {
            Title = title;
            Description = description;
            Icon = icon;
            Highlights = new List<string>(highlights ?? new string[0]);
        }

        public string Title { get; }

        public string Description { get; }

        public string Icon { get; }

        public IList<string> Highlights { get; }
    }
}
