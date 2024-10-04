using DoAnBackend.Data;

namespace DoAnBackend.Repositories.Interface
{
    public interface IPrescriptionRepository
    {
        Task<Prescription> GetPrescriptionByAppointmentName(string appointmentName);
        Task<Prescription> CreatePrescriptionAsync(Prescription prescription);
        Task UpdatePrescription(Prescription prescription);
    }
}
