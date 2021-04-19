using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SprintNumber = table.Column<int>(nullable: false),
                    PointValue = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true),
                    StatusId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { "work", "Work" },
                    { "home", "Home" },
                    { "ex", "Exercise" },
                    { "shop", "Shopping" },
                    { "call", "Contact" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { "todo", "To Do" },
                    { "inprogress", "In Progress" },
                    { "qualityassurance", "Quality Assurance" },
                    { "done", "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CategoryId", "Description", "DueDate", "Name", "PointValue", "SprintNumber", "StatusId" },
                values: new object[] { 1, "work", "The first ticket", new DateTime(2021, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "First Ticket", 1, 1, "todo" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CategoryId", "Description", "DueDate", "Name", "PointValue", "SprintNumber", "StatusId" },
                values: new object[] { 3, null, "The third ticket", null, "Third Ticket", 8, 6, "todo" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CategoryId", "Description", "DueDate", "Name", "PointValue", "SprintNumber", "StatusId" },
                values: new object[] { 2, null, "The second ticket", null, "Second Ticket", 7, 3, "inprogress" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CategoryId",
                table: "Tickets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
