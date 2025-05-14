using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplyLog.Migrations
{
    /// <inheritdoc />
    public partial class BewerbungClassUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Firma_firmaID",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "whenapplied",
                table: "Applications",
                newName: "WhenApplied");

            migrationBuilder.RenameColumn(
                name: "result",
                table: "Applications",
                newName: "Result");

            migrationBuilder.RenameColumn(
                name: "positionComment",
                table: "Applications",
                newName: "PositionComment");

            migrationBuilder.RenameColumn(
                name: "position",
                table: "Applications",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "jobort",
                table: "Applications",
                newName: "JobOrt");

            migrationBuilder.RenameColumn(
                name: "homeoffice",
                table: "Applications",
                newName: "HomeOffice");

            migrationBuilder.RenameColumn(
                name: "gehalt",
                table: "Applications",
                newName: "Gehalt");

            migrationBuilder.RenameColumn(
                name: "firmaID",
                table: "Applications",
                newName: "FirmaID");

            migrationBuilder.RenameColumn(
                name: "applicationlink",
                table: "Applications",
                newName: "ApplicationLink");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Applications",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_firmaID",
                table: "Applications",
                newName: "IX_Applications_FirmaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Firma_FirmaID",
                table: "Applications",
                column: "FirmaID",
                principalTable: "Firma",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Firma_FirmaID",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "WhenApplied",
                table: "Applications",
                newName: "whenapplied");

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "Applications",
                newName: "result");

            migrationBuilder.RenameColumn(
                name: "PositionComment",
                table: "Applications",
                newName: "positionComment");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Applications",
                newName: "position");

            migrationBuilder.RenameColumn(
                name: "JobOrt",
                table: "Applications",
                newName: "jobort");

            migrationBuilder.RenameColumn(
                name: "HomeOffice",
                table: "Applications",
                newName: "homeoffice");

            migrationBuilder.RenameColumn(
                name: "Gehalt",
                table: "Applications",
                newName: "gehalt");

            migrationBuilder.RenameColumn(
                name: "FirmaID",
                table: "Applications",
                newName: "firmaID");

            migrationBuilder.RenameColumn(
                name: "ApplicationLink",
                table: "Applications",
                newName: "applicationlink");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Applications",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_FirmaID",
                table: "Applications",
                newName: "IX_Applications_firmaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Firma_firmaID",
                table: "Applications",
                column: "firmaID",
                principalTable: "Firma",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
