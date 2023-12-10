﻿// <auto-generated />
using System;
using JobPortal.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobPortal.Api.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobPortal.Api.Models.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AbilityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ability");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Benefit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BenefitName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Benefit");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Carrier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateSince")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Carrier");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CourseEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseOrganizer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CourseStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Duty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DutyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Duty");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SchoolDegree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SchoolEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SchoolLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SchoolStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proffesion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmploymentContract")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmploymentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositionLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecruitmentEndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("SalaryMaximum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SalaryMinimum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WorkDays")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkEndHour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkStartHour")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobOferts");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertBenefit", b =>
                {
                    b.Property<int>("JobOfertId")
                        .HasColumnType("int");

                    b.Property<int>("BenefitId")
                        .HasColumnType("int");

                    b.HasKey("JobOfertId", "BenefitId");

                    b.HasIndex("BenefitId");

                    b.ToTable("JobOfertBenefit");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertCategory", b =>
                {
                    b.Property<int>("JobOfertId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("JobOfertId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("JobOfertCategory");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertDuty", b =>
                {
                    b.Property<int>("JobOfertId")
                        .HasColumnType("int");

                    b.Property<int>("DutyId")
                        .HasColumnType("int");

                    b.HasKey("JobOfertId", "DutyId");

                    b.HasIndex("DutyId");

                    b.ToTable("JobOfertDuty");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertRequirement", b =>
                {
                    b.Property<int>("JobOfertId")
                        .HasColumnType("int");

                    b.Property<int>("RequirementId")
                        .HasColumnType("int");

                    b.HasKey("JobOfertId", "RequirementId");

                    b.HasIndex("RequirementId");

                    b.ToTable("JobOfertRequirement");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LanguageLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LinkContent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Requirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RequirementName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Requirement");
                });

            modelBuilder.Entity("JobPortal.Api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Access")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserAbility", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("AbilityId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "AbilityId");

                    b.HasIndex("AbilityId");

                    b.ToTable("UserAbility");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserCourse", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("UserCourse");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserEducation", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("EducationId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "EducationId");

                    b.HasIndex("EducationId");

                    b.ToTable("UserEducation");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserExperience", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ExperienceId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ExperienceId");

                    b.HasIndex("ExperienceId");

                    b.ToTable("UserExperience");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserJobOfert", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("JobOfertId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "JobOfertId");

                    b.HasIndex("JobOfertId");

                    b.ToTable("UserJobOfert");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserLanguage", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("UserLanguage");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserLink", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("LinkId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "LinkId");

                    b.HasIndex("LinkId");

                    b.ToTable("UserLink");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proffesion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProffesionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProffesionSince")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Work");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Carrier", b =>
                {
                    b.HasOne("JobPortal.Api.Models.User", "User")
                        .WithOne("Carrier")
                        .HasForeignKey("JobPortal.Api.Models.Carrier", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertBenefit", b =>
                {
                    b.HasOne("JobPortal.Api.Models.Benefit", "Benefit")
                        .WithMany("JobOfertBenefits")
                        .HasForeignKey("BenefitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.JobOfert", "JobOfert")
                        .WithMany("JobOfertBenefits")
                        .HasForeignKey("JobOfertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benefit");

                    b.Navigation("JobOfert");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertCategory", b =>
                {
                    b.HasOne("JobPortal.Api.Models.Category", "Category")
                        .WithMany("JobOfertCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.JobOfert", "JobOfert")
                        .WithMany("JobOfertCategories")
                        .HasForeignKey("JobOfertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("JobOfert");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertDuty", b =>
                {
                    b.HasOne("JobPortal.Api.Models.Duty", "Duty")
                        .WithMany("JobOfertDuties")
                        .HasForeignKey("DutyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.JobOfert", "JobOfert")
                        .WithMany("JobOfertDuties")
                        .HasForeignKey("JobOfertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Duty");

                    b.Navigation("JobOfert");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertRequirement", b =>
                {
                    b.HasOne("JobPortal.Api.Models.JobOfert", "JobOfert")
                        .WithMany("JobOfertRequirements")
                        .HasForeignKey("JobOfertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.Requirement", "Requirement")
                        .WithMany("JobOfertRequirements")
                        .HasForeignKey("RequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobOfert");

                    b.Navigation("Requirement");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserAbility", b =>
                {
                    b.HasOne("JobPortal.Api.Models.Ability", "Ability")
                        .WithMany("UserAbilities")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.User", "User")
                        .WithMany("UserAbilities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ability");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserCourse", b =>
                {
                    b.HasOne("JobPortal.Api.Models.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserEducation", b =>
                {
                    b.HasOne("JobPortal.Api.Models.Education", "Education")
                        .WithMany("UserEducations")
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.User", "User")
                        .WithMany("UserEducations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Education");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserExperience", b =>
                {
                    b.HasOne("JobPortal.Api.Models.Experience", "Experience")
                        .WithMany("UserExperiences")
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.User", "User")
                        .WithMany("UserExperiences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Experience");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserJobOfert", b =>
                {
                    b.HasOne("JobPortal.Api.Models.JobOfert", "JobOfert")
                        .WithMany("userJobOferts")
                        .HasForeignKey("JobOfertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.User", "User")
                        .WithMany("userJobOferts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobOfert");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserLanguage", b =>
                {
                    b.HasOne("JobPortal.Api.Models.Language", "Language")
                        .WithMany("UserLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.User", "User")
                        .WithMany("UserLanguages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserLink", b =>
                {
                    b.HasOne("JobPortal.Api.Models.Link", "Link")
                        .WithMany("UserLinks")
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.User", "User")
                        .WithMany("UserLinks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Link");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Work", b =>
                {
                    b.HasOne("JobPortal.Api.Models.User", "User")
                        .WithOne("Work")
                        .HasForeignKey("JobPortal.Api.Models.Work", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Ability", b =>
                {
                    b.Navigation("UserAbilities");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Benefit", b =>
                {
                    b.Navigation("JobOfertBenefits");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Category", b =>
                {
                    b.Navigation("JobOfertCategories");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Course", b =>
                {
                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Duty", b =>
                {
                    b.Navigation("JobOfertDuties");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Education", b =>
                {
                    b.Navigation("UserEducations");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Experience", b =>
                {
                    b.Navigation("UserExperiences");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfert", b =>
                {
                    b.Navigation("JobOfertBenefits");

                    b.Navigation("JobOfertCategories");

                    b.Navigation("JobOfertDuties");

                    b.Navigation("JobOfertRequirements");

                    b.Navigation("userJobOferts");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Language", b =>
                {
                    b.Navigation("UserLanguages");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Link", b =>
                {
                    b.Navigation("UserLinks");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Requirement", b =>
                {
                    b.Navigation("JobOfertRequirements");
                });

            modelBuilder.Entity("JobPortal.Api.Models.User", b =>
                {
                    b.Navigation("Carrier");

                    b.Navigation("UserAbilities");

                    b.Navigation("UserCourses");

                    b.Navigation("UserEducations");

                    b.Navigation("UserExperiences");

                    b.Navigation("UserLanguages");

                    b.Navigation("UserLinks");

                    b.Navigation("Work");

                    b.Navigation("userJobOferts");
                });
#pragma warning restore 612, 618
        }
    }
}
