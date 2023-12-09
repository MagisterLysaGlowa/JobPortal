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
        public DbSet<UserExperience> UserExperience { get; set; } = default!;
        public DbSet<UserEducation> UserEducation { get; set; } = default!;
        public DbSet<Experience> Experience { get; set; } = default!;
        public DbSet<Education> Education { get; set; } = default!;
        public DbSet<UserLanguage> UserLanguage { get; set; } = default!;
        public DbSet<Ability> Ability { get; set; } = default!;
        public DbSet<UserAbility> UserAbility { get; set; } = default!;
        public DbSet<Language> Language { get; set; } = default!;
        public DbSet<Course> Course { get; set; } = default!;
        public DbSet<UserCourse> UserCourse { get; set; } = default!;
        public DbSet<Link> Link { get; set; } = default!;
        public DbSet<UserLink> UserLink { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*SETUP ONE TO ONE USER TO WORK RELATION*/
            modelBuilder.Entity<User>()
                .HasOne(u => u.Work)
                .WithOne(a => a.User)
                .HasForeignKey<Work>(a => a.UserId);

            /*SETUP ONE TO ONE USER TO CARRIER RELATION*/
            modelBuilder.Entity<User>()
                .HasOne(u => u.Carrier)
                .WithOne(a => a.User)
                .HasForeignKey<Carrier>(a => a.UserId);

            /*SETUP MANY TO MANY USER TO EXPERIENCE RELATION*/
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

            /*SETUP MANY TO MANY USER TO EDUCATION RELATION*/
            modelBuilder.Entity<UserEducation>()
                .HasKey(ue => new { ue.UserId, ue.EducationId });

            modelBuilder.Entity<UserEducation>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserEducations)
                .HasForeignKey(ue => ue.UserId);

            modelBuilder.Entity<UserEducation>()
                .HasOne(ue => ue.Education)
                .WithMany(e => e.UserEducations)
                .HasForeignKey(ue => ue.EducationId);

            /*SETUP MANY TO MANY USER TO LANGUAGE RELATION*/
            modelBuilder.Entity<UserLanguage>()
                .HasKey(ue => new { ue.UserId, ue.LanguageId });

            modelBuilder.Entity<UserLanguage>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserLanguages)
                .HasForeignKey(ue => ue.UserId);

            modelBuilder.Entity<UserLanguage>()
                .HasOne(ue => ue.Language)
                .WithMany(e => e.UserLanguages)
                .HasForeignKey(ue => ue.LanguageId);

            /*SETUP MANY TO MANY USER TO ABILITY RELATION*/
            modelBuilder.Entity<UserAbility>()
                .HasKey(ue => new { ue.UserId, ue.AbilityId });

            modelBuilder.Entity<UserAbility>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserAbilities)
                .HasForeignKey(ue => ue.UserId);

            modelBuilder.Entity<UserAbility>()
                .HasOne(ue => ue.Ability)
                .WithMany(e => e.UserAbilities)
                .HasForeignKey(ue => ue.AbilityId);

            /*SETUP MANY TO MANY USER TO COURSE RELATION*/
            modelBuilder.Entity<UserCourse>()
                .HasKey(ue => new { ue.UserId, ue.CourseId });

            modelBuilder.Entity<UserCourse>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserCourses)
                .HasForeignKey(ue => ue.UserId);

            modelBuilder.Entity<UserCourse>()
                .HasOne(ue => ue.Course)
                .WithMany(e => e.UserCourses)
                .HasForeignKey(ue => ue.CourseId);

            /*SETUP MANY TO MANY USER TO LINK RELATION*/
            modelBuilder.Entity<UserLink>()
                .HasKey(ue => new { ue.UserId, ue.LinkId });

            modelBuilder.Entity<UserLink>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserLinks)
                .HasForeignKey(ue => ue.UserId);

            modelBuilder.Entity<UserLink>()
                .HasOne(ue => ue.Link)
                .WithMany(e => e.UserLinks)
                .HasForeignKey(ue => ue.LinkId);
        }
    }
}
