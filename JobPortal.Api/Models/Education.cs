namespace JobPortal.Api.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string? SchoolName { get; set; }
        public string? SchoolLocation { get; set; }
        public string? SchoolLevel { get; set; }
        public string? SchoolDegree { get; set; }
        public DateTime? SchoolStartDate { get; set; }
        public DateTime? SchoolEndDate { get; set; }
        public List<UserEducation> UserEducations { get; } = new();
    }
}
