namespace JobPortal.Api.Models
{
    public class Duty
    {
        public int Id { get; set; } 
        public string? DutyName { get; set; }
        public List<JobOfertDuty> JobOfertDuties { get; set; } = new();
    }
}
