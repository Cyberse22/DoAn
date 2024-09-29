using DoAnBackend.Data;

namespace DoAnBackend.Repositories.Interface
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetPrescriptionsByDateAsync(DateOnly appointmentDate);
        Task AddPrescriptionAsync(Prescription prescription);
    }
}
