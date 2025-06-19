using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace application.Migrations
{
    /// <inheritdoc />
    public partial class addcoworkingentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoworkingId",
                table: "WorkspaceTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Coworkings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coworkings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Coworkings",
                columns: new[] { "Id", "Address", "ImageUrl", "Name" },
                values: new object[] { 1, "123 Yaroslav Val St,Kyiv", null, "WorkClub Perchersk" });

            migrationBuilder.UpdateData(
                table: "WorkspaceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CoworkingId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "WorkspaceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CoworkingId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_WorkspaceTypes_CoworkingId",
                table: "WorkspaceTypes",
                column: "CoworkingId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkspaceTypes_Coworkings_CoworkingId",
                table: "WorkspaceTypes",
                column: "CoworkingId",
                principalTable: "Coworkings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkspaceTypes_Coworkings_CoworkingId",
                table: "WorkspaceTypes");

            migrationBuilder.DropTable(
                name: "Coworkings");

            migrationBuilder.DropIndex(
                name: "IX_WorkspaceTypes_CoworkingId",
                table: "WorkspaceTypes");

            migrationBuilder.DropColumn(
                name: "CoworkingId",
                table: "WorkspaceTypes");
        }
    }
}
