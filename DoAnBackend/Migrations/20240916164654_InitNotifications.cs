using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogsNotifications_AspNetUsers_UserId",
                table: "BlogsNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogsNotifications",
                table: "BlogsNotifications");

            migrationBuilder.RenameTable(
                name: "BlogsNotifications",
                newName: "Notifications");

            migrationBuilder.RenameIndex(
                name: "IX_BlogsNotifications_UserId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "BlogsNotifications");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "BlogsNotifications",
                newName: "IX_BlogsNotifications_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogsNotifications",
                table: "BlogsNotifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsNotifications_AspNetUsers_UserId",
                table: "BlogsNotifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
