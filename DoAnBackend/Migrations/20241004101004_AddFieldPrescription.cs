using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldPrescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppointmentName",
                table: "Prescriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorEmail",
                table: "Prescriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "Prescriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "Prescriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrescriptionName",
                table: "Prescriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicineName",
                table: "PrescriptionDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrescriptionName",
                table: "PrescriptionDetails",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentName",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "DoctorEmail",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PrescriptionName",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "MedicineName",
                table: "PrescriptionDetails");

            migrationBuilder.DropColumn(
                name: "PrescriptionName",
                table: "PrescriptionDetails");
        }
    }
}
