using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbsenceRequests.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbsenceTypes",
                columns: table => new
                {
                    AbsenceTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceTypes", x => x.AbsenceTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "AbsenceRequests",
                columns: table => new
                {
                    AbsenceRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    AbsenceTypeID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceRequests", x => x.AbsenceRequestID);
                    table.ForeignKey(
                        name: "FK_AbsenceRequests_AbsenceTypes_AbsenceTypeID",
                        column: x => x.AbsenceTypeID,
                        principalTable: "AbsenceTypes",
                        principalColumn: "AbsenceTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbsenceRequests_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AbsenceTypes",
                columns: new[] { "AbsenceTypeID", "Title" },
                values: new object[,]
                {
                    { 1, "Vacation" },
                    { 2, "Family" },
                    { 3, "Medical" },
                    { 4, "Personal" },
                    { 5, "Military" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, "simon.johansson@mail.com", "Simon", "123 456 78 91", "Johansson" },
                    { 2, "elon.musk@mail.com", "Elon", "123 456 78 92", "Musk" },
                    { 3, "jeff.bezos@mail.com", "Jeff", "123 456 78 93", "Bezos" },
                    { 4, "steve.jobs@mail.com", "Steve", "123 456 78 94", "Jobs" }
                });

            migrationBuilder.InsertData(
                table: "AbsenceRequests",
                columns: new[] { "AbsenceRequestID", "AbsenceTypeID", "EmployeeID", "EndDate", "StartDate" },
                values: new object[] { 1, 1, 1, new DateTime(2022, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequests_AbsenceTypeID",
                table: "AbsenceRequests",
                column: "AbsenceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequests_EmployeeID",
                table: "AbsenceRequests",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbsenceRequests");

            migrationBuilder.DropTable(
                name: "AbsenceTypes");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
