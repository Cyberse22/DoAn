using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "PrescriptionDetails");

            migrationBuilder.DropColumn(
                name: "Symptoms",
                table: "PrescriptionDetails");

            migrationBuilder.RenameColumn(
                name: "Diagnosis",
                table: "Prescriptions",
                newName: "Conclusion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Conclusion",
                table: "Prescriptions",
                newName: "Diagnosis");

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
    }
}
