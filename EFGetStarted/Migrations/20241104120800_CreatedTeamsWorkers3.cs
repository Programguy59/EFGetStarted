using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFGetStarted.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTeamsWorkers3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teamworker");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teamworker",
                columns: table => new
                {
                    TeamsTeamID = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkersWorkerID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teamworker", x => new { x.TeamsTeamID, x.WorkersWorkerID });
                    table.ForeignKey(
                        name: "FK_Teamworker_Teams_TeamsTeamID",
                        column: x => x.TeamsTeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teamworker_workers_WorkersWorkerID",
                        column: x => x.WorkersWorkerID,
                        principalTable: "workers",
                        principalColumn: "WorkerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teamworker_WorkersWorkerID",
                table: "Teamworker",
                column: "WorkersWorkerID");
        }
    }
}
