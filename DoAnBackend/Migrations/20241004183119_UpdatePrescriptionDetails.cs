using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePrescriptionDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "PrescriptionDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Symptoms",
                table: "PrescriptionDetails",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "PrescriptionDetails");

            migrationBuilder.DropColumn(
                name: "Symptoms",
                table: "PrescriptionDetails");
        }
    }
}
