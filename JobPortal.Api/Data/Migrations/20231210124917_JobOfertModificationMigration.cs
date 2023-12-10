using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class JobOfertModificationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmploymentContract",
                table: "JobOferts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmploymentType",
                table: "JobOferts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobType",
                table: "JobOferts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositionLevel",
                table: "JobOferts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositionName",
                table: "JobOferts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SalaryMaximum",
                table: "JobOferts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SalaryMinimum",
                table: "JobOferts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkDays",
                table: "JobOferts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkEndHour",
                table: "JobOferts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkStartHour",
                table: "JobOferts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmploymentContract",
                table: "JobOferts");

            migrationBuilder.DropColumn(
                name: "EmploymentType",
                table: "JobOferts");

            migrationBuilder.DropColumn(
                name: "JobType",
                table: "JobOferts");

            migrationBuilder.DropColumn(
                name: "PositionLevel",
                table: "JobOferts");

            migrationBuilder.DropColumn(
                name: "PositionName",
                table: "JobOferts");

            migrationBuilder.DropColumn(
                name: "SalaryMaximum",
                table: "JobOferts");

            migrationBuilder.DropColumn(
                name: "SalaryMinimum",
                table: "JobOferts");

            migrationBuilder.DropColumn(
                name: "WorkDays",
                table: "JobOferts");

            migrationBuilder.DropColumn(
                name: "WorkEndHour",
                table: "JobOferts");

            migrationBuilder.DropColumn(
                name: "WorkStartHour",
                table: "JobOferts");
        }
    }
}
