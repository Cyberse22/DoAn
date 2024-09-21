using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnBackend.Migrations
{
    /// <inheritdoc />
    public partial class Rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_AspNetUsers_DoctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_AspNetUsers_NurseId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_AspNetUsers_PatientId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_invoiceMedicines_invoices_InvoiceId",
                table: "invoiceMedicines");

            migrationBuilder.DropForeignKey(
                name: "FK_invoiceMedicines_medicines_MedicineId",
                table: "invoiceMedicines");

            migrationBuilder.DropForeignKey(
                name: "FK_invoices_AspNetUsers_NurseId",
                table: "invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_invoices_appointments_AppointmentId",
                table: "invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_invoices_prescriptions_PrescriptionId",
                table: "invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_invoicesServices_invoices_InvoicedId",
                table: "invoicesServices");

            migrationBuilder.DropForeignKey(
                name: "FK_invoicesServices_services_ServiceId",
                table: "invoicesServices");

            migrationBuilder.DropForeignKey(
                name: "FK_prescriptionDetails_medicines_MedicineId",
                table: "prescriptionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_prescriptionDetails_prescriptions_PrescriptionId",
                table: "prescriptionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_prescriptions_AspNetUsers_DoctorId",
                table: "prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_prescriptions_AspNetUsers_PatientId",
                table: "prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_prescriptions_appointments_AppointmentId",
                table: "prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_services",
                table: "services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_prescriptions",
                table: "prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_prescriptionDetails",
                table: "prescriptionDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_medicines",
                table: "medicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_invoicesServices",
                table: "invoicesServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_invoices",
                table: "invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_invoiceMedicines",
                table: "invoiceMedicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.RenameTable(
                name: "services",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "prescriptions",
                newName: "Prescriptions");

            migrationBuilder.RenameTable(
                name: "prescriptionDetails",
                newName: "PrescriptionDetails");

            migrationBuilder.RenameTable(
                name: "medicines",
                newName: "Medicines");

            migrationBuilder.RenameTable(
                name: "invoicesServices",
                newName: "InvoicesServices");

            migrationBuilder.RenameTable(
                name: "invoices",
                newName: "Invoices");

            migrationBuilder.RenameTable(
                name: "invoiceMedicines",
                newName: "InvoiceMedicines");

            migrationBuilder.RenameTable(
                name: "appointments",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_prescriptions_PatientId",
                table: "Prescriptions",
                newName: "IX_Prescriptions_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_prescriptions_DoctorId",
                table: "Prescriptions",
                newName: "IX_Prescriptions_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_prescriptions_AppointmentId",
                table: "Prescriptions",
                newName: "IX_Prescriptions_AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_prescriptionDetails_PrescriptionId",
                table: "PrescriptionDetails",
                newName: "IX_PrescriptionDetails_PrescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_prescriptionDetails_MedicineId",
                table: "PrescriptionDetails",
                newName: "IX_PrescriptionDetails_MedicineId");

            migrationBuilder.RenameIndex(
                name: "IX_invoicesServices_ServiceId",
                table: "InvoicesServices",
                newName: "IX_InvoicesServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_invoicesServices_InvoicedId",
                table: "InvoicesServices",
                newName: "IX_InvoicesServices_InvoicedId");

            migrationBuilder.RenameIndex(
                name: "IX_invoices_PrescriptionId",
                table: "Invoices",
                newName: "IX_Invoices_PrescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_invoices_NurseId",
                table: "Invoices",
                newName: "IX_Invoices_NurseId");

            migrationBuilder.RenameIndex(
                name: "IX_invoices_AppointmentId",
                table: "Invoices",
                newName: "IX_Invoices_AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_invoiceMedicines_MedicineId",
                table: "InvoiceMedicines",
                newName: "IX_InvoiceMedicines_MedicineId");

            migrationBuilder.RenameIndex(
                name: "IX_invoiceMedicines_InvoiceId",
                table: "InvoiceMedicines",
                newName: "IX_InvoiceMedicines_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_PatientId",
                table: "Appointments",
                newName: "IX_Appointments_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_NurseId",
                table: "Appointments",
                newName: "IX_Appointments_NurseId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_DoctorId",
                table: "Appointments",
                newName: "IX_Appointments_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrescriptionDetails",
                table: "PrescriptionDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicines",
                table: "Medicines",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoicesServices",
                table: "InvoicesServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceMedicines",
                table: "InvoiceMedicines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_NurseId",
                table: "Appointments",
                column: "NurseId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceMedicines_Invoices_InvoiceId",
                table: "InvoiceMedicines",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceMedicines_Medicines_MedicineId",
                table: "InvoiceMedicines",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Appointments_AppointmentId",
                table: "Invoices",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_NurseId",
                table: "Invoices",
                column: "NurseId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Prescriptions_PrescriptionId",
                table: "Invoices",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesServices_Invoices_InvoicedId",
                table: "InvoicesServices",
                column: "InvoicedId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesServices_Services_ServiceId",
                table: "InvoicesServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionDetails_Medicines_MedicineId",
                table: "PrescriptionDetails",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionDetails_Prescriptions_PrescriptionId",
                table: "PrescriptionDetails",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Appointments_AppointmentId",
                table: "Prescriptions",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_AspNetUsers_DoctorId",
                table: "Prescriptions",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_AspNetUsers_PatientId",
                table: "Prescriptions",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_NurseId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceMedicines_Invoices_InvoiceId",
                table: "InvoiceMedicines");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceMedicines_Medicines_MedicineId",
                table: "InvoiceMedicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Appointments_AppointmentId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_NurseId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Prescriptions_PrescriptionId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesServices_Invoices_InvoicedId",
                table: "InvoicesServices");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesServices_Services_ServiceId",
                table: "InvoicesServices");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionDetails_Medicines_MedicineId",
                table: "PrescriptionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionDetails_Prescriptions_PrescriptionId",
                table: "PrescriptionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Appointments_AppointmentId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_AspNetUsers_DoctorId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_AspNetUsers_PatientId",
                table: "Prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrescriptionDetails",
                table: "PrescriptionDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicines",
                table: "Medicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoicesServices",
                table: "InvoicesServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceMedicines",
                table: "InvoiceMedicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "services");

            migrationBuilder.RenameTable(
                name: "Prescriptions",
                newName: "prescriptions");

            migrationBuilder.RenameTable(
                name: "PrescriptionDetails",
                newName: "prescriptionDetails");

            migrationBuilder.RenameTable(
                name: "Medicines",
                newName: "medicines");

            migrationBuilder.RenameTable(
                name: "InvoicesServices",
                newName: "invoicesServices");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "invoices");

            migrationBuilder.RenameTable(
                name: "InvoiceMedicines",
                newName: "invoiceMedicines");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "appointments");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_PatientId",
                table: "prescriptions",
                newName: "IX_prescriptions_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_DoctorId",
                table: "prescriptions",
                newName: "IX_prescriptions_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_AppointmentId",
                table: "prescriptions",
                newName: "IX_prescriptions_AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_PrescriptionDetails_PrescriptionId",
                table: "prescriptionDetails",
                newName: "IX_prescriptionDetails_PrescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_PrescriptionDetails_MedicineId",
                table: "prescriptionDetails",
                newName: "IX_prescriptionDetails_MedicineId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoicesServices_ServiceId",
                table: "invoicesServices",
                newName: "IX_invoicesServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoicesServices_InvoicedId",
                table: "invoicesServices",
                newName: "IX_invoicesServices_InvoicedId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_PrescriptionId",
                table: "invoices",
                newName: "IX_invoices_PrescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_NurseId",
                table: "invoices",
                newName: "IX_invoices_NurseId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_AppointmentId",
                table: "invoices",
                newName: "IX_invoices_AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceMedicines_MedicineId",
                table: "invoiceMedicines",
                newName: "IX_invoiceMedicines_MedicineId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceMedicines_InvoiceId",
                table: "invoiceMedicines",
                newName: "IX_invoiceMedicines_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PatientId",
                table: "appointments",
                newName: "IX_appointments_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_NurseId",
                table: "appointments",
                newName: "IX_appointments_NurseId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DoctorId",
                table: "appointments",
                newName: "IX_appointments_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_services",
                table: "services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_prescriptions",
                table: "prescriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_prescriptionDetails",
                table: "prescriptionDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_medicines",
                table: "medicines",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_invoicesServices",
                table: "invoicesServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_invoices",
                table: "invoices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_invoiceMedicines",
                table: "invoiceMedicines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_AspNetUsers_DoctorId",
                table: "appointments",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_AspNetUsers_NurseId",
                table: "appointments",
                column: "NurseId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_AspNetUsers_PatientId",
                table: "appointments",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_invoiceMedicines_invoices_InvoiceId",
                table: "invoiceMedicines",
                column: "InvoiceId",
                principalTable: "invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_invoiceMedicines_medicines_MedicineId",
                table: "invoiceMedicines",
                column: "MedicineId",
                principalTable: "medicines",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_AspNetUsers_NurseId",
                table: "invoices",
                column: "NurseId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_appointments_AppointmentId",
                table: "invoices",
                column: "AppointmentId",
                principalTable: "appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_prescriptions_PrescriptionId",
                table: "invoices",
                column: "PrescriptionId",
                principalTable: "prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_invoicesServices_invoices_InvoicedId",
                table: "invoicesServices",
                column: "InvoicedId",
                principalTable: "invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_invoicesServices_services_ServiceId",
                table: "invoicesServices",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_prescriptionDetails_medicines_MedicineId",
                table: "prescriptionDetails",
                column: "MedicineId",
                principalTable: "medicines",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_prescriptionDetails_prescriptions_PrescriptionId",
                table: "prescriptionDetails",
                column: "PrescriptionId",
                principalTable: "prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_prescriptions_AspNetUsers_DoctorId",
                table: "prescriptions",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_prescriptions_AspNetUsers_PatientId",
                table: "prescriptions",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_prescriptions_appointments_AppointmentId",
                table: "prescriptions",
                column: "AppointmentId",
                principalTable: "appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
