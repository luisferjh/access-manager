using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessManagerApp.Migrations
{
    public partial class requiredcolumnmanualremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
               name: "ExpirationDate",
               table: "AccCard",
               type: "nchar(50)",
               nullable: true,
               oldClrType: typeof(string),
               oldType: "nchar(50)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
              name: "ExpirationDate",
              table: "AccCard",
              type: "nchar(50)",
              nullable: false,
              defaultValue: "",
              oldClrType: typeof(string),
              oldType: "nchar(50)",
              oldNullable: true);
        }
    }
}
