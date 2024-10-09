using DoAnBackend.Data;
using DoAnBackend.Models;

namespace DoAnBackend.Services.Interface
{
    public interface IPrescriptionService
    {
        Task<PrescriptionModel> CreatePrescriptionAsync(PrescriptionModel.CreatePrescription prescriptionModel, string appointmentName);
        Task<PrescriptionModel> GetPrescriptionByAppointmentName(string appointmentName);
        Task UpdatePrescription(PrescriptionModel prescriptionModel);
        Task AddMedicineToPrescriptionDetailsAsync(string prescriptionName, List<PrescriptionModel.CreatePrescriptionDetails> medicines);
    }
}
