using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMSAPI.Migrations
{
    public partial class InitialMigratio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    AccountNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10001, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PAN = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    ContactNo = table.Column<long>(type: "bigint", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    JWT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.AccountNo);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "500, 1"),
                    LoanType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LoanAmount = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RateOfInterest = table.Column<float>(type: "real", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNo = table.Column<int>(type: "int", nullable: false),
                    UserAccountNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanID);
                    table.ForeignKey(
                        name: "FK_Loans_Users_UserAccountNo",
                        column: x => x.UserAccountNo,
                        principalTable: "Users",
                        principalColumn: "AccountNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserAccountNo",
                table: "Loans",
                column: "UserAccountNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
