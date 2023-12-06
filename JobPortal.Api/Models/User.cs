namespace JobPortal.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImagePath { get; set; }
        public string? Location { get; set; }
        public string? Password { get; set; }
        public string? Access { get; set; }
        public DateTime? BirthDate { get; set; }
        public Work? Work { get; set; } 
        public Carrier? Carrier { get; set; }
        public List<UserExperience> UserExperiences { get; } = new();
        public List<UserEducation> UserEducations { get; } = new();
        public List<UserLanguage> UserLanguages { get; set; } = new();
        public List<UserAbility> UserAbilities { get; set; } = new();
    }
}
