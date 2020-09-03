using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProMS.CORE.Migrations
{
    public partial class PmsDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(maxLength: 20, nullable: false),
                    password = table.Column<string>(maxLength: 30, nullable: false),
                    firstname = table.Column<string>(maxLength: 20, nullable: false),
                    lastname = table.Column<string>(maxLength: 25, nullable: false),
                    email = table.Column<string>(maxLength: 20, nullable: false),
                    phone_num = table.Column<string>(maxLength: 15, nullable: false),
                    skype_contact = table.Column<string>(maxLength: 20, nullable: true),
                    birth_date = table.Column<string>(nullable: false),
                    role = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_name = table.Column<string>(nullable: false),
                    project_height = table.Column<int>(nullable: false),
                    project_width = table.Column<int>(nullable: false),
                    project_depth = table.Column<int>(nullable: false),
                    project_create_date = table.Column<DateTime>(nullable: false),
                    project_last_modified = table.Column<DateTime>(nullable: false),
                    project_folder = table.Column<string>(nullable: false),
                    project_orderer = table.Column<string>(nullable: false),
                    project_comment = table.Column<string>(nullable: false),
                    project_image_path = table.Column<string>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "birth_date", "email", "firstname", "lastname", "password", "phone_num", "role", "skype_contact", "username" },
                values: new object[] { 1, "4/24/1989 12:00:00 AM", "besysfx@gmail.com", "ბესიკ", "ქრისტესიაშვილი", "UJEs6M6$", "+995595191690", "Admin", "besusfx", "befx" });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AuthorId",
                table: "Projects",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
