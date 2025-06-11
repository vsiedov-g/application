using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace application.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkspaceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkspaceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AmenityWorkspaceType",
                columns: table => new
                {
                    AmenityId = table.Column<int>(type: "integer", nullable: false),
                    WorkspaceTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityWorkspaceType", x => new { x.AmenityId, x.WorkspaceTypeId });
                    table.ForeignKey(
                        name: "FK_AmenityWorkspaceType_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenityWorkspaceType_WorkspaceTypes_WorkspaceTypeId",
                        column: x => x.WorkspaceTypeId,
                        principalTable: "WorkspaceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workspaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    WorkspaceTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workspaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workspaces_WorkspaceTypes_WorkspaceTypeId",
                        column: x => x.WorkspaceTypeId,
                        principalTable: "WorkspaceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    UserEmail = table.Column<string>(type: "text", nullable: false),
                    WorkspaceId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "High-Speed Wi-Fi" },
                    { 2, "Power Outlets" },
                    { 3, "Coffee Machine" },
                    { 4, "Air Conditioning" }
                });

            migrationBuilder.InsertData(
                table: "WorkspaceTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open Space" },
                    { 2, "Private Room" },
                    { 3, "Meeting Room" }
                });

            migrationBuilder.InsertData(
                table: "AmenityWorkspaceType",
                columns: new[] { "AmenityId", "WorkspaceTypeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Capacity", "Name", "WorkspaceTypeId" },
                values: new object[,]
                {
                    { 1, 1, "Desk 1", 1 },
                    { 2, 1, "Desk 2", 1 },
                    { 3, 1, "Desk 3", 1 },
                    { 4, 1, "Desk 4", 1 },
                    { 5, 1, "Desk 5", 1 },
                    { 6, 1, "Room 1", 2 },
                    { 7, 1, "Room 2", 2 },
                    { 8, 2, "Room 3", 2 },
                    { 9, 5, "Room 4", 2 },
                    { 10, 10, "Room 5", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmenityWorkspaceType_WorkspaceTypeId",
                table: "AmenityWorkspaceType",
                column: "WorkspaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_WorkspaceId",
                table: "Bookings",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Workspaces_WorkspaceTypeId",
                table: "Workspaces",
                column: "WorkspaceTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenityWorkspaceType");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Workspaces");

            migrationBuilder.DropTable(
                name: "WorkspaceTypes");
        }
    }
}
