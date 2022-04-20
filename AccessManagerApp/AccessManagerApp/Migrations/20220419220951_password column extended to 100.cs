using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessManagerApp.Migrations
{
    public partial class passwordcolumnextendedto100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(30)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(100)");
        }
    }
}
