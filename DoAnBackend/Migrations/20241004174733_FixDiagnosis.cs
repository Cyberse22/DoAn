using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixDiagnosis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Diagnsis",
                table: "Prescriptions",
                newName: "Diagnosis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Diagnosis",
                table: "Prescriptions",
                newName: "Diagnsis");
        }
    }
}
