using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace application.Migrations
{
    /// <inheritdoc />
    public partial class adddescriptiontocoworking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Coworkings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Coworkings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Modern coworking in the heart of Pechersk with quiet rooms and coffee on tap");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Coworkings");
        }
    }
}
