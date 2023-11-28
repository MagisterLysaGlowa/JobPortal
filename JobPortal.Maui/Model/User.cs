using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public string Location { get; set; }
        public string Password { get; set; }
        public string Access { get; set; }
        public DateTime BirthDate { get; set; }
        public string Proffesion { get; set; }
        public string Company { get; set; }
        public DateTime ProffesionSince { get; set; }
        public string ProffesionDescription { get; set; }
        public string Industry { get; set; }
    }
}
