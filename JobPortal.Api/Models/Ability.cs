namespace JobPortal.Api.Models
{
    public class Ability
    {
        public int Id { get; set; }
        public string? AbilityName { get; set; }
        public List<UserAbility> UserAbilities { get; set; } = new();
    }
}
