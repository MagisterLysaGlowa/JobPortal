namespace JobPortal.Api.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageLevel { get; set; }
        public List<UserLanguage> UserLanguages { get; set; } = new();
    }
}
