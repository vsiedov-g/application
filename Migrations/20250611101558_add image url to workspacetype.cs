using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace application.Migrations
{
    /// <inheritdoc />
    public partial class addimageurltoworkspacetype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkspaceTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "WorkspaceTypes",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "WorkspaceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/open-space/openSpace.jpg");

            migrationBuilder.UpdateData(
                table: "WorkspaceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/open-space/privateRoom.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "WorkspaceTypes");

            migrationBuilder.InsertData(
                table: "WorkspaceTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Meeting Room" });
        }
    }
}
