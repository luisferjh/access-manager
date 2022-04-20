using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessManagerApp.Migrations
{
    public partial class usertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nchar(15)", nullable: false),
                    Password = table.Column<string>(type: "nchar(30)", nullable: false),
                    Email = table.Column<string>(type: "nchar(40)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdUser",
                table: "Accounts",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_IdUser",
                table: "Accounts",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_IdUser",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_IdUser",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Accounts");
        }
    }
}
