using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoard.Data.Migrations
{
    public partial class AddedTaskField_EditedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedOn",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date and time when the task was edited");

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "EditedOn", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("20bd3507-eb08-4075-af87-1d0edc750c3a"), 2, new DateTime(2023, 3, 8, 11, 2, 0, 996, DateTimeKind.Utc).AddTicks(4067), "Create Desktop client App for the RESTful TaskBoard service", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3f39c124-5996-4125-a43a-68976db12d50", "Desktop Client App" },
                    { new Guid("2a443239-bc36-4148-b337-943178636a17"), 1, new DateTime(2023, 6, 6, 11, 2, 0, 996, DateTimeKind.Utc).AddTicks(4046), "Implement better styling for all public pages", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0430e6cf-b8d7-4a77-8d32-fccd1ea74279", "Improve CSS styles" },
                    { new Guid("329a729f-0913-4104-9a7c-1728ff497269"), 3, new DateTime(2023, 3, 8, 11, 2, 0, 996, DateTimeKind.Utc).AddTicks(4069), "Implement [Create Task] page for adding tasks", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3f39c124-5996-4125-a43a-68976db12d50", "Create Tasks" },
                    { new Guid("71c15e0a-795b-4c0c-9981-5410db299a57"), 1, new DateTime(2023, 6, 11, 11, 2, 0, 996, DateTimeKind.Utc).AddTicks(4065), "Create Android client App for the RESTful TaskBoard service", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2a7f468e-0771-4fab-b387-d9722d98daa3", "Android Client App" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("20bd3507-eb08-4075-af87-1d0edc750c3a"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("2a443239-bc36-4148-b337-943178636a17"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("329a729f-0913-4104-9a7c-1728ff497269"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("71c15e0a-795b-4c0c-9981-5410db299a57"));

            migrationBuilder.DropColumn(
                name: "EditedOn",
                table: "Tasks");

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
    }
}
