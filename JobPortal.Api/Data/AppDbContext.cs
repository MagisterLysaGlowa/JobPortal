using JobPortal.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = default!;
    }
}
