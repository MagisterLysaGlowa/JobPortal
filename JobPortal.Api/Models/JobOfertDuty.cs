namespace JobPortal.Api.Models
{
    public class JobOfertDuty
    {
        public int JobOfertId { get; set; }
        public int DutyId { get; set; }
        public JobOfert? JobOfert { get; set; }
        public Duty? Duty { get; set; }
    }
}
