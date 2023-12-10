namespace JobPortal.Api.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public List<JobOfertCategory> JobOfertCategories { get; set; } = new();
    }
}
