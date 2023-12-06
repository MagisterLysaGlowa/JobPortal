using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Model
{
    public class Education
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string SchoolLocation { get; set; }
        public string SchoolLevel { get; set; }
        public string SchoolDegree { get; set; }
        public DateTime SchoolStartDate { get; set; }
        public DateTime SchoolEndDate { get; set; }
    }
}
