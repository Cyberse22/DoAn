using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NurseLastName",
                table: "Appointments",
                newName: "NurseName");

            migrationBuilder.RenameColumn(
                name: "NurseFirstName",
                table: "Appointments",
                newName: "NurseEmail");

            migrationBuilder.RenameColumn(
                name: "DoctorLastName",
                table: "Appointments",
                newName: "DoctorName");

            migrationBuilder.RenameColumn(
                name: "DoctorFirstName",
                table: "Appointments",
                newName: "DoctorEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NurseName",
                table: "Appointments",
                newName: "NurseLastName");

            migrationBuilder.RenameColumn(
                name: "NurseEmail",
                table: "Appointments",
                newName: "NurseFirstName");

            migrationBuilder.RenameColumn(
                name: "DoctorName",
                table: "Appointments",
                newName: "DoctorLastName");

            migrationBuilder.RenameColumn(
                name: "DoctorEmail",
                table: "Appointments",
                newName: "DoctorFirstName");
        }
    }
}
