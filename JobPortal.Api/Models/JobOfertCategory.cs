namespace JobPortal.Api.Models
{
    public class JobOfertCategory
    {
        public int JobOfertId { get; set; }
        public int CategoryId { get; set; }
        public JobOfert? JobOfert { get; set; }
        public Category? Category { get; set; } 
    }
}
