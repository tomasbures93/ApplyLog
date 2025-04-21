using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplyLog.Migrations
{
    /// <inheritdoc />
    public partial class positionCommentAddToBewerbung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "applicationlink",
                table: "Applications",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "positionComment",
                table: "Applications",
                type: "TEXT",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "positionComment",
                table: "Applications");

            migrationBuilder.AlterColumn<string>(
                name: "applicationlink",
                table: "Applications",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
