namespace JobPortal.Api.Models
{
    public class UserJobOfert
    {
        public int UserId { get; set; }
        public int JobOfertId { get; set; }
        public User? User { get; set; }
        public JobOfert? JobOfert { get; set; }
    }
}
