using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Models;
using DoAnBackend.Repositories.Interface;
using DoAnBackend.Services.Interface;

namespace DoAnBackend.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMapper _mapper;
        public PrescriptionService(IPrescriptionRepository prescriptionRepository, IMapper mapper)
        {
            _prescriptionRepository = prescriptionRepository;
            _mapper = mapper;
        }

        public async Task CreatePrescriptionAsync(PrescriptionModel model)
        {
            var prescription = _mapper.Map<Prescription>(model);
            await _prescriptionRepository.AddPrescriptionAsync(prescription);
        }

        public async Task<IEnumerable<PrescriptionModel>> GetPrescriptionsByDateAsync(DateOnly appointmentDate)
        {
            var prescriptions = await _prescriptionRepository.GetPrescriptionsByDateAsync(appointmentDate);
            return _mapper.Map<IEnumerable<PrescriptionModel>>(prescriptions);
        }
    }
}
