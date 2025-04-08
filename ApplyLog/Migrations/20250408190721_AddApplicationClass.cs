using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplyLog.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontakt",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    number = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    website = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontakt", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Firma",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    Ort = table.Column<string>(type: "TEXT", nullable: true),
                    Kontaktid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firma", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Firma_Kontakt_Kontaktid",
                        column: x => x.Kontaktid,
                        principalTable: "Kontakt",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firmaID = table.Column<int>(type: "INTEGER", nullable: false),
                    jobort = table.Column<string>(type: "TEXT", nullable: false),
                    position = table.Column<string>(type: "TEXT", nullable: false),
                    whenapplied = table.Column<DateTime>(type: "TEXT", nullable: false),
                    gehalt = table.Column<int>(type: "INTEGER", nullable: true),
                    homeoffice = table.Column<bool>(type: "INTEGER", nullable: false),
                    applicationlink = table.Column<string>(type: "TEXT", nullable: false),
                    result = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.id);
                    table.ForeignKey(
                        name: "FK_Applications_Firma_firmaID",
                        column: x => x.firmaID,
                        principalTable: "Firma",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_firmaID",
                table: "Applications",
                column: "firmaID");

            migrationBuilder.CreateIndex(
                name: "IX_Firma_Kontaktid",
                table: "Firma",
                column: "Kontaktid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Firma");

            migrationBuilder.DropTable(
                name: "Kontakt");
        }
    }
}
