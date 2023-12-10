namespace JobPortal.Api.Models
{
    public class JobOfertBenefit
    {
        public int JobOfertId { get; set; }
        public int BenefitId { get; set; }
        public JobOfert? JobOfert { get; set; }
        public Benefit? Benefit { get; set; }
    }
}
