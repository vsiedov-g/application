using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace application.Migrations
{
    /// <inheritdoc />
    public partial class addadditionalseededdataandremovenamefromworkspace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Workspaces");

            migrationBuilder.UpdateData(
                table: "Coworkings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "ImageUrl" },
                values: new object[] { "123 Yaroslav Val St, Kyiv", "https://www.mindspace.me/wp-content/uploads/2023/08/Screenshot-2023-08-17-at-08.57.35.png" });

            migrationBuilder.InsertData(
                table: "Coworkings",
                columns: new[] { "Id", "Address", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 2, "78 Naberezhno-Khreshachatytska ST, Kyiv", "A creative riverside hub ideal for freelancers and small startups", "https://mlgucbjxeu1m.i.optimole.com/cb:B7VA.3e989/w:1024/h:682/q:mauto/ig:avif/f:best/https://flydesk.com/wp-content/uploads/2021/01/lavaca-barcelona-coworking.jpg", "UrbanSpace Podil" },
                    { 3, "12 Lvivska Square,Kyiv", "A compact, desight-focused space with open desks and strong community vibes", "https://www.servcorp.com.au/media/31088/socialising-in-a-coworking-space.jpg", "Creative Hub Lvivska" }
                });

            migrationBuilder.InsertData(
                table: "WorkspaceTypes",
                columns: new[] { "Id", "CoworkingId", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 3, 1, "Ideal for focused work, video calls, or small team huddles. These fully enclosed room offer privacy and come in a variety of sizes to fit your needs", "https://www.appliedglobal.com/wp-content/uploads/How-to-Create-a-Modern-Meeting-Room-Setup.png", "Meeting Room" },
                    { 4, 2, "A vibrant shared are perfect for freelancers or small teams who enjoy a collaborative atmosphere. Choose any available desk and get to work with flexibility and ease", "/images/open-space/openSpace.jpg", "Open Space" },
                    { 5, 2, "Ideal for focused work, video calls, or small team huddles. These fully enclosed room offer privacy and come in a variety of sizes to fit your needs", "/images/private-room/privateRoom.jpg", "Private Room" },
                    { 6, 2, "Ideal for focused work, video calls, or small team huddles. These fully enclosed room offer privacy and come in a variety of sizes to fit your needs", "https://www.appliedglobal.com/wp-content/uploads/How-to-Create-a-Modern-Meeting-Room-Setup.png", "Meeting Room" }
                });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Capacity", "WorkspaceTypeId" },
                values: new object[,]
                {
                    { 11, 1, 3 },
                    { 12, 1, 4 },
                    { 13, 1, 4 },
                    { 14, 1, 4 },
                    { 15, 1, 4 },
                    { 16, 1, 5 },
                    { 17, 2, 5 },
                    { 18, 2, 5 },
                    { 19, 5, 5 },
                    { 20, 5, 5 },
                    { 21, 10, 6 },
                    { 22, 20, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coworkings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "WorkspaceTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkspaceTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkspaceTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkspaceTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Coworkings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Workspaces",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Coworkings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "ImageUrl" },
                values: new object[] { "123 Yaroslav Val St,Kyiv", null });

            migrationBuilder.UpdateData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Desk 1");

            migrationBuilder.UpdateData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Desk 2");

            migrationBuilder.UpdateData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Desk 3");

            migrationBuilder.UpdateData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Desk 4");

            migrationBuilder.UpdateData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Desk 5");

            migrationBuilder.UpdateData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Room 1");

            migrationBuilder.UpdateData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Room 2");

            migrationBuilder.UpdateData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Room 3");

            migrationBuilder.UpdateData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Room 4");

            migrationBuilder.UpdateData(
                table: "Workspaces",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Room 5");
        }
    }
}
