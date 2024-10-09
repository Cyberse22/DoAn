using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnBackend.Migrations
{
    /// <inheritdoc />
    public partial class NewField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "PrescriptionDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicineId",
                table: "Medicines",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "PrescriptionDetails");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "Medicines");
        }
    }
}
