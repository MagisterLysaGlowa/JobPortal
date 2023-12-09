namespace JobPortal.Maui.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseOrganizer { get; set; }
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }
    }
}
