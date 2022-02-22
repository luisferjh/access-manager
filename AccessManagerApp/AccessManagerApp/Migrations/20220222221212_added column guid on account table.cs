using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessManagerApp.Migrations
{
    public partial class addedcolumnguidonaccounttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GuidAccount",
                table: "Accounts",
                type: "UNIQUEIDENTIFIER",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuidAccount",
                table: "Accounts");
        }
    }
}
