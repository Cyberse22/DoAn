using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnBackend.Migrations
{
    /// <inheritdoc />
    public partial class MedicineID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MedicineID",
                table: "PrescriptionDetails",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicineID",
                table: "PrescriptionDetails");
        }
    }
}
