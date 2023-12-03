using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Api.Models
{
    public class Carrier
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateSince { get; set; }
        public User? User { get; set; }
        public int ? UserId { get; set; }
    }
}
