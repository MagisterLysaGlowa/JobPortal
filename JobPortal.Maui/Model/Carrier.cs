using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Model
{
    public class Carrier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateSince { get; set; }
        public int UserId { get; set; }
    }
}
