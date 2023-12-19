using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class JobOfertFavourite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserJobOfertsFavourite",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    JobOfertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJobOfertsFavourite", x => new { x.UserId, x.JobOfertId });
                    table.ForeignKey(
                        name: "FK_UserJobOfertsFavourite_JobOferts_JobOfertId",
                        column: x => x.JobOfertId,
                        principalTable: "JobOferts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJobOfertsFavourite_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserJobOfertsFavourite_JobOfertId",
                table: "UserJobOfertsFavourite",
                column: "JobOfertId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserJobOfertsFavourite");
        }
    }
}
