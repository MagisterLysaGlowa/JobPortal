namespace JobPortal.Api.Models
{
    public class Benefit
    {
        public int Id { get; set; }
        public string? BenefitName { get; set; }
        public List<JobOfertBenefit> JobOfertBenefits { get; set; } = new();
    }
}
