using DoAnBackend.Models;

namespace DoAnBackend.Services.Interface
{
    public interface IPrescriptionService
    {
        Task CreatePrescriptionAsync(PrescriptionModel model);
        Task<IEnumerable<PrescriptionModel>> GetPrescriptionsByDateAsync(DateOnly appointmentDate);
    }
}
