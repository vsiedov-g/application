using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace application.Migrations
{
    /// <inheritdoc />
    public partial class seeddatafix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WorkspaceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/private-room/privateRoom.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WorkspaceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/privateRoom/privateRoom.jpg");
        }
    }
}
