using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoard.Data.Migrations
{
    public partial class SeedingBoardsAndTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ID of the board")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Name of the board")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ID of the task"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Title of the task"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Description of the task"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the task was created"),
                    BoardId = table.Column<int>(type: "int", nullable: false, comment: "ID of the board of the task"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "ID of the owner of the task")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Done" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("0ac34aeb-61e8-4d94-8e14-84e6eb2e8013"), 1, new DateTime(2023, 6, 20, 0, 40, 58, 422, DateTimeKind.Utc).AddTicks(2924), "Implement better styling for all public pages", "0430e6cf-b8d7-4a77-8d32-fccd1ea74279", "Improve CSS styles" },
                    { new Guid("51e6d6e3-8466-4ddf-b997-ec52facac2da"), 3, new DateTime(2023, 3, 7, 0, 40, 58, 422, DateTimeKind.Utc).AddTicks(2944), "Implement [Create Task] page for adding tasks", "3f39c124-5996-4125-a43a-68976db12d50", "Create Tasks" },
                    { new Guid("9999bb72-2ea1-4cb5-8f95-7f3b5bb6d1be"), 2, new DateTime(2023, 9, 23, 0, 40, 58, 422, DateTimeKind.Utc).AddTicks(2942), "Create Desktop client App for the RESTful TaskBoard service", "3f39c124-5996-4125-a43a-68976db12d50", "Desktop Client App" },
                    { new Guid("a2467a51-0fe2-4988-b5ad-2f9b6aa64714"), 1, new DateTime(2023, 6, 10, 0, 40, 58, 422, DateTimeKind.Utc).AddTicks(2941), "Create Android client App for the RESTful TaskBoard service", "2a7f468e-0771-4fab-b387-d9722d98daa3", "Android Client App" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
