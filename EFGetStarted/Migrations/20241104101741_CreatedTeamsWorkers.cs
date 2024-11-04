using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFGetStarted.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTeamsWorkers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "worker",
                columns: table => new
                {
                    WorkerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_worker", x => x.WorkerID);
                });

            migrationBuilder.CreateTable(
                name: "Teamworker",
                columns: table => new
                {
                    TeamsTeamID = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamsWorkerID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teamworker", x => new { x.TeamsTeamID, x.TeamsWorkerID });
                    table.ForeignKey(
                        name: "FK_Teamworker_Team_TeamsTeamID",
                        column: x => x.TeamsTeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teamworker_worker_TeamsWorkerID",
                        column: x => x.TeamsWorkerID,
                        principalTable: "worker",
                        principalColumn: "WorkerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teamworker_TeamsWorkerID",
                table: "Teamworker",
                column: "TeamsWorkerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teamworker");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "worker");
        }
    }
}
