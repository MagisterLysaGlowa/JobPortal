namespace JobPortal.Api.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string? LinkContent { get; set; }
        public List<UserLink> UserLinks { get; set; } = new();
    }
}
