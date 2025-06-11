using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace application.Migrations
{
    /// <inheritdoc />
    public partial class adddescriptiontoworkspacetype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WorkspaceTypes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "WorkspaceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A vibrant shared are perfect for freelancers or small teams who enjoy a collaborative atmosphere. Choose any available desk and get to work with flexibility and ease");

            migrationBuilder.UpdateData(
                table: "WorkspaceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Ideal for focused work, video calls, or small team huddles. These fully enclosed room offer privacy and come in a variety of sizes to fit your needs", "/images/privateRoom/privateRoom.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "WorkspaceTypes");

            migrationBuilder.UpdateData(
                table: "WorkspaceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/open-space/privateRoom.jpg");
        }
    }
}
