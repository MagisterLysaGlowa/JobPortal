using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Model
{
    public class UserJobOfertApplication
    {
        public int UserId { get; set; }
        public int JobOfertId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
