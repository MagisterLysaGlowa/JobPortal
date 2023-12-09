namespace JobPortal.Api.Models
{
    public class UserLink
    {
        public int UserId { get; set; }
        public int LinkId { get; set; }
        public User? User { get; set; }
        public Link? Link { get; set; }
    }
}
