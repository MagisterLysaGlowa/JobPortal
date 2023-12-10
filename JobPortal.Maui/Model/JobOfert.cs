using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Model
{
    public class JobOfert
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyLocation { get; set; }
        public string CompanyDescription { get; set; }
        public DateTime RecruitmentEndDate { get; set; }

        public string PositionName { get; set; }
        public string PositionLevel { get; set; }
        public string EmploymentContract { get; set; }
        public string EmploymentType { get; set; }
        public string JobType { get; set; }
        public decimal SalaryMinimum { get; set; }
        public decimal SalaryMaximum { get; set; }
        public string WorkDays { get; set; }
        public string WorkStartHour { get; set; }
        public string WorkEndHour { get; set; }
    }
}
