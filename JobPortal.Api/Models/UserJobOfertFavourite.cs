namespace JobPortal.Api.Models
{
    public class UserJobOfertFavourite
    {
        public User? User { get; set; }
        public JobOfert? JobOfert { get; set; }
        public int UserId { get; set; }
        public int JobOfertId { get; set; }
    }
}
