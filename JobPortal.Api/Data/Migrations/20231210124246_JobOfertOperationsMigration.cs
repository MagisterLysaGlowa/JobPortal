using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class JobOfertOperationsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "JobOferts");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "JobOferts");

            migrationBuilder.DropColumn(
                name: "CompanyInfo",
                table: "JobOferts");

            migrationBuilder.DropColumn(
                name: "DateOfPublic",
                table: "JobOferts");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "JobOferts");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "JobOferts",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "JobOferts",
                newName: "CompanyLocation");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "JobOferts",
                newName: "CompanyDescription");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "JobOferts",
                newName: "CompanyAddress");

            migrationBuilder.AddColumn<DateTime>(
                name: "RecruitmentEndDate",
                table: "JobOferts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Benefit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenefitName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Duty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DutyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requirement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobOfertBenefit",
                columns: table => new
                {
                    JobOfertId = table.Column<int>(type: "int", nullable: false),
                    BenefitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfertBenefit", x => new { x.JobOfertId, x.BenefitId });
                    table.ForeignKey(
                        name: "FK_JobOfertBenefit_Benefit_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOfertBenefit_JobOferts_JobOfertId",
                        column: x => x.JobOfertId,
                        principalTable: "JobOferts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOfertCategory",
                columns: table => new
                {
                    JobOfertId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfertCategory", x => new { x.JobOfertId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_JobOfertCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOfertCategory_JobOferts_JobOfertId",
                        column: x => x.JobOfertId,
                        principalTable: "JobOferts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOfertDuty",
                columns: table => new
                {
                    JobOfertId = table.Column<int>(type: "int", nullable: false),
                    DutyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfertDuty", x => new { x.JobOfertId, x.DutyId });
                    table.ForeignKey(
                        name: "FK_JobOfertDuty_Duty_DutyId",
                        column: x => x.DutyId,
                        principalTable: "Duty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOfertDuty_JobOferts_JobOfertId",
                        column: x => x.JobOfertId,
                        principalTable: "JobOferts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOfertRequirement",
                columns: table => new
                {
                    JobOfertId = table.Column<int>(type: "int", nullable: false),
                    RequirementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfertRequirement", x => new { x.JobOfertId, x.RequirementId });
                    table.ForeignKey(
                        name: "FK_JobOfertRequirement_JobOferts_JobOfertId",
                        column: x => x.JobOfertId,
                        principalTable: "JobOferts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOfertRequirement_Requirement_RequirementId",
                        column: x => x.RequirementId,
                        principalTable: "Requirement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobOfertBenefit_BenefitId",
                table: "JobOfertBenefit",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfertCategory_CategoryId",
                table: "JobOfertCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfertDuty_DutyId",
                table: "JobOfertDuty",
                column: "DutyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfertRequirement_RequirementId",
                table: "JobOfertRequirement",
                column: "RequirementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobOfertBenefit");

            migrationBuilder.DropTable(
                name: "JobOfertCategory");

            migrationBuilder.DropTable(
                name: "JobOfertDuty");

            migrationBuilder.DropTable(
                name: "JobOfertRequirement");

            migrationBuilder.DropTable(
                name: "Benefit");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Duty");

            migrationBuilder.DropTable(
                name: "Requirement");

            migrationBuilder.DropColumn(
                name: "RecruitmentEndDate",
                table: "JobOferts");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "JobOferts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "CompanyLocation",
                table: "JobOferts",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "CompanyDescription",
                table: "JobOferts",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "CompanyAddress",
                table: "JobOferts",
                newName: "Description");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "JobOferts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "JobOferts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyInfo",
                table: "JobOferts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateOfPublic",
                table: "JobOferts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Payment",
                table: "JobOferts",
                type: "int",
                nullable: true);
        }
    }
}
