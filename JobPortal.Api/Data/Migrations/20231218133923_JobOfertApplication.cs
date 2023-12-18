using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class JobOfertApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserJobOfertApplication",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    JobOfertId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJobOfertApplication", x => new { x.UserId, x.JobOfertId });
                    table.ForeignKey(
                        name: "FK_UserJobOfertApplication_JobOferts_JobOfertId",
                        column: x => x.JobOfertId,
                        principalTable: "JobOferts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJobOfertApplication_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserJobOfertApplication_JobOfertId",
                table: "UserJobOfertApplication",
                column: "JobOfertId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserJobOfertApplication");
        }
    }
}
