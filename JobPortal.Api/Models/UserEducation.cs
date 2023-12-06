namespace JobPortal.Api.Models
{
    public class UserEducation
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public int EducationId { get; set; }
        public Education? Education { get; set; }
    }
}
