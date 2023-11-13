namespace JobPortal.Api.Models
{
    public class JobOfert
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? DateOfPublic { get; set; }
        public bool Active { get; set; }
        public string? Location { get; set; }
        public string? Position { get; set; }
        public string? Category { get; set; }
        public int? Payment { get; set; }
        public string? CompanyInfo { get; set; }
    }
}
