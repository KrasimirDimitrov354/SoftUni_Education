using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoard.Data.Migrations
{
    public partial class TaskBoardIdRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("0ac34aeb-61e8-4d94-8e14-84e6eb2e8013"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("51e6d6e3-8466-4ddf-b997-ec52facac2da"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("9999bb72-2ea1-4cb5-8f95-7f3b5bb6d1be"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a2467a51-0fe2-4988-b5ad-2f9b6aa64714"));

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("43d7ce2c-61d2-40cc-ae21-0e96704eea58"), 3, new DateTime(2023, 3, 7, 13, 0, 50, 318, DateTimeKind.Utc).AddTicks(8263), "Implement [Create Task] page for adding tasks", "3f39c124-5996-4125-a43a-68976db12d50", "Create Tasks" },
                    { new Guid("572d1c82-52ed-4ab3-ab43-6a9ff4970098"), 1, new DateTime(2023, 6, 10, 13, 0, 50, 318, DateTimeKind.Utc).AddTicks(8257), "Create Android client App for the RESTful TaskBoard service", "2a7f468e-0771-4fab-b387-d9722d98daa3", "Android Client App" },
                    { new Guid("80b91733-9f49-44c9-ad48-68e48695fa6f"), 2, new DateTime(2023, 9, 23, 13, 0, 50, 318, DateTimeKind.Utc).AddTicks(8260), "Create Desktop client App for the RESTful TaskBoard service", "3f39c124-5996-4125-a43a-68976db12d50", "Desktop Client App" },
                    { new Guid("f1b123f9-9208-4c99-aef6-e2f1a931a632"), 1, new DateTime(2023, 6, 20, 13, 0, 50, 318, DateTimeKind.Utc).AddTicks(8246), "Implement better styling for all public pages", "0430e6cf-b8d7-4a77-8d32-fccd1ea74279", "Improve CSS styles" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("43d7ce2c-61d2-40cc-ae21-0e96704eea58"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("572d1c82-52ed-4ab3-ab43-6a9ff4970098"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("80b91733-9f49-44c9-ad48-68e48695fa6f"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("f1b123f9-9208-4c99-aef6-e2f1a931a632"));

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
        }
    }
}
