namespace JobPortal.Api.Models
{
    public class UserExperience
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public int ExperienceId { get; set; }
        public Experience? Experience { get; set; }
    }
}
