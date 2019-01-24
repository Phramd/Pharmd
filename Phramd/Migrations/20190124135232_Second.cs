using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Phramd.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(maxLength: 100, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    password = table.Column<string>(maxLength: 100, nullable: false),
                    signupdate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    canceldate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CalendarModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    gmail = table.Column<string>(maxLength: 100, nullable: true),
                    apple = table.Column<string>(maxLength: 100, nullable: true),
                    microsoft = table.Column<string>(maxLength: 100, nullable: true),
                    emailadded = table.Column<DateTime>(nullable: false),
                    emailremoved = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_CalendarModel_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhotoAccounts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    gmail = table.Column<string>(maxLength: 100, nullable: true),
                    apple = table.Column<string>(maxLength: 100, nullable: true),
                    microsoft = table.Column<string>(maxLength: 100, nullable: true),
                    emailadded = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    emailremoved = table.Column<DateTime>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoAccounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_PhotoAccounts_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarModel_UserID",
                table: "CalendarModel",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoAccounts_UserID",
                table: "PhotoAccounts",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarModel");

            migrationBuilder.DropTable(
                name: "PhotoAccounts");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
