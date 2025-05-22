using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplyLog.Migrations
{
    /// <inheritdoc />
    public partial class AddUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Firma_Kontakt_Kontaktid",
                table: "Firma");

            migrationBuilder.RenameColumn(
                name: "website",
                table: "Kontakt",
                newName: "Website");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Kontakt",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Kontakt",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Kontakt",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Kontaktid",
                table: "Firma",
                newName: "KontaktId");

            migrationBuilder.RenameIndex(
                name: "IX_Firma_Kontaktid",
                table: "Firma",
                newName: "IX_Firma_KontaktId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Todos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Applications",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UserId",
                table: "Todos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_AspNetUsers_UserId",
                table: "Applications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Firma_Kontakt_KontaktId",
                table: "Firma",
                column: "KontaktId",
                principalTable: "Kontakt",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_AspNetUsers_UserId",
                table: "Todos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_AspNetUsers_UserId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Firma_Kontakt_KontaktId",
                table: "Firma");

            migrationBuilder.DropForeignKey(
                name: "FK_Todos_AspNetUsers_UserId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_UserId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Applications_UserId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "Website",
                table: "Kontakt",
                newName: "website");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Kontakt",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Kontakt",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Kontakt",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "KontaktId",
                table: "Firma",
                newName: "Kontaktid");

            migrationBuilder.RenameIndex(
                name: "IX_Firma_KontaktId",
                table: "Firma",
                newName: "IX_Firma_Kontaktid");

            migrationBuilder.AddForeignKey(
                name: "FK_Firma_Kontakt_Kontaktid",
                table: "Firma",
                column: "Kontaktid",
                principalTable: "Kontakt",
                principalColumn: "id");
        }
    }
}
