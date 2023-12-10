namespace JobPortal.Api.Models
{
    public class Requirement
    {
        public int Id { get; set; }
        public string? RequirementName { get; set; }
        public List<JobOfertRequirement> JobOfertRequirements { get; set; } = new();
    }
}
