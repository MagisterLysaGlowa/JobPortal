namespace JobPortal.Api.Models
{
    public class UserAbility
    {
        public int UserId { get; set; }
        public int AbilityId { get; set; }
        public User? User { get; set; }
        public Ability? Ability { get; set; }
    }
}
