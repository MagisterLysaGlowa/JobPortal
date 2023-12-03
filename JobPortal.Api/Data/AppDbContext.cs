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
        public DbSet<JobOfert> JobOferts { get; set; } = default!;
        public DbSet<Work> Work { get; set; } = default!;
        public DbSet<Carrier> Carrier { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Work)
                .WithOne(a => a.User)
                .HasForeignKey<Work>(a => a.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Carrier)
                .WithOne(a => a.User)
                .HasForeignKey<Carrier>(a => a.UserId);


            modelBuilder.Entity<UserExperience>()
                .HasKey(ue => new { ue.UserId, ue.ExperienceId });

            modelBuilder.Entity<UserExperience>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserExperiences)
                .HasForeignKey(ue => ue.UserId);

            modelBuilder.Entity<UserExperience>()
                .HasOne(ue => ue.Experience)
                .WithMany(e => e.UserExperiences)
                .HasForeignKey(ue => ue.ExperienceId);
        }
    }
}
