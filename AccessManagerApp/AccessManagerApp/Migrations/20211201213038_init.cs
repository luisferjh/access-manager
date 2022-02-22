using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessManagerApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    IdAccountType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nchar(4)", nullable: false),
                    TypeName = table.Column<string>(type: "nchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.IdAccountType);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    IdAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAccountType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nchar(100)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.IdAccount);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_IdAccountType",
                        column: x => x.IdAccountType,
                        principalTable: "AccountTypes",
                        principalColumn: "IdAccountType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccCard",
                columns: table => new
                {
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    CardType = table.Column<string>(type: "nchar(10)", nullable: false),
                    Franchise = table.Column<string>(type: "nchar(20)", nullable: false),
                    Bank = table.Column<string>(type: "nchar(20)", nullable: false),
                    CCV = table.Column<string>(type: "nchar(50)", nullable: false),
                    ExpirationDate = table.Column<string>(type: "nchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccCard", x => x.IdAccount);
                    table.ForeignKey(
                        name: "FK_AccCard_Accounts_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Accounts",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccNormal",
                columns: table => new
                {
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccNormal", x => x.IdAccount);
                    table.ForeignKey(
                        name: "FK_AccNormal_Accounts_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Accounts",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountDetails",
                columns: table => new
                {
                    IdAccountDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSensitive = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDetails", x => x.IdAccountDetail);
                    table.ForeignKey(
                        name: "FK_AccountDetails_Accounts_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Accounts",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccWebAssociated",
                columns: table => new
                {
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccWebAssociated", x => x.IdAccount);
                    table.ForeignKey(
                        name: "FK_AccWebAssociated_Accounts_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Accounts",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccWebSite",
                columns: table => new
                {
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    WebSiteName = table.Column<string>(type: "nchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccWebSite", x => x.IdAccount);
                    table.ForeignKey(
                        name: "FK_AccWebSite_Accounts_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Accounts",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountDetails_IdAccount",
                table: "AccountDetails",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdAccountType",
                table: "Accounts",
                column: "IdAccountType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccCard");

            migrationBuilder.DropTable(
                name: "AccNormal");

            migrationBuilder.DropTable(
                name: "AccountDetails");

            migrationBuilder.DropTable(
                name: "AccWebAssociated");

            migrationBuilder.DropTable(
                name: "AccWebSite");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountTypes");
        }
    }
}
