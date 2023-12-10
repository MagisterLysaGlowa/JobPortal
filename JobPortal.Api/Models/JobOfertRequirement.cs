namespace JobPortal.Api.Models
{
    public class JobOfertRequirement
    {
        public int JobOfertId { get; set; }
        public int RequirementId { get; set; }
        public JobOfert? JobOfert { get; set; }
        public Requirement? Requirement { get; set; }
    }
}
