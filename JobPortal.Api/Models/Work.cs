namespace JobPortal.Api.Models
{
    public class Work
    {
        public int Id { get; set; } 
        public string? Proffesion { get; set; }
        public string? ProffesionDescription { get; set; }
        public string? CompanyName { get; set; }
        public DateTime? ProffesionSince { get; set; }
        public string? Industry { get; set; }
        public User? User { get; set; }
        public int? UserId { get; set; }
    }
}
