using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnBackend.Migrations
{
    /// <inheritdoc />
    public partial class EditBlogTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogsTags_Blogs_BlogId",
                table: "BlogsTags");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogsTags_Tags_TagId",
                table: "BlogsTags");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsTags_Blogs_BlogId",
                table: "BlogsTags",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsTags_Tags_TagId",
                table: "BlogsTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogsTags_Blogs_BlogId",
                table: "BlogsTags");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogsTags_Tags_TagId",
                table: "BlogsTags");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsTags_Blogs_BlogId",
                table: "BlogsTags",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsTags_Tags_TagId",
                table: "BlogsTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
