using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFGetStarted.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTeamsWorkers2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teamworker_Team_TeamsTeamID",
                table: "Teamworker");

            migrationBuilder.DropForeignKey(
                name: "FK_Teamworker_worker_TeamsWorkerID",
                table: "Teamworker");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_Tasks_TaskId",
                table: "ToDo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_worker",
                table: "worker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDo",
                table: "ToDo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.RenameTable(
                name: "worker",
                newName: "workers");

            migrationBuilder.RenameTable(
                name: "ToDo",
                newName: "ToDos");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.RenameColumn(
                name: "TeamsWorkerID",
                table: "Teamworker",
                newName: "WorkersWorkerID");

            migrationBuilder.RenameIndex(
                name: "IX_Teamworker_TeamsWorkerID",
                table: "Teamworker",
                newName: "IX_Teamworker_WorkersWorkerID");

            migrationBuilder.RenameIndex(
                name: "IX_ToDo_TaskId",
                table: "ToDos",
                newName: "IX_ToDos_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workers",
                table: "workers",
                column: "WorkerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDos",
                table: "ToDos",
                column: "ToDoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "TeamID");

            migrationBuilder.CreateTable(
                name: "TeamWorkers",
                columns: table => new
                {
                    WorkerID = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamWorkers", x => new { x.TeamId, x.WorkerID });
                    table.ForeignKey(
                        name: "FK_TeamWorkers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamWorkers_workers_WorkerID",
                        column: x => x.WorkerID,
                        principalTable: "workers",
                        principalColumn: "WorkerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamWorkers_WorkerID",
                table: "TeamWorkers",
                column: "WorkerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teamworker_Teams_TeamsTeamID",
                table: "Teamworker",
                column: "TeamsTeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teamworker_workers_WorkersWorkerID",
                table: "Teamworker",
                column: "WorkersWorkerID",
                principalTable: "workers",
                principalColumn: "WorkerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Tasks_TaskId",
                table: "ToDos",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teamworker_Teams_TeamsTeamID",
                table: "Teamworker");

            migrationBuilder.DropForeignKey(
                name: "FK_Teamworker_workers_WorkersWorkerID",
                table: "Teamworker");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Tasks_TaskId",
                table: "ToDos");

            migrationBuilder.DropTable(
                name: "TeamWorkers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workers",
                table: "workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDos",
                table: "ToDos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "workers",
                newName: "worker");

            migrationBuilder.RenameTable(
                name: "ToDos",
                newName: "ToDo");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.RenameColumn(
                name: "WorkersWorkerID",
                table: "Teamworker",
                newName: "TeamsWorkerID");

            migrationBuilder.RenameIndex(
                name: "IX_Teamworker_WorkersWorkerID",
                table: "Teamworker",
                newName: "IX_Teamworker_TeamsWorkerID");

            migrationBuilder.RenameIndex(
                name: "IX_ToDos_TaskId",
                table: "ToDo",
                newName: "IX_ToDo_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_worker",
                table: "worker",
                column: "WorkerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDo",
                table: "ToDo",
                column: "ToDoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teamworker_Team_TeamsTeamID",
                table: "Teamworker",
                column: "TeamsTeamID",
                principalTable: "Team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teamworker_worker_TeamsWorkerID",
                table: "Teamworker",
                column: "TeamsWorkerID",
                principalTable: "worker",
                principalColumn: "WorkerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_Tasks_TaskId",
                table: "ToDo",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");
        }
    }
}
