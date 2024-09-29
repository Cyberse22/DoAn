using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorFirstName",
                table: "Appointments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorLastName",
                table: "Appointments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NurseFirstName",
                table: "Appointments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NurseLastName",
                table: "Appointments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientEmail",
                table: "Appointments",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorFirstName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DoctorLastName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "NurseFirstName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "NurseLastName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PatientEmail",
                table: "Appointments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
