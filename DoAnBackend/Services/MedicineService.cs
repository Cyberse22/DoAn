using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Models;
using DoAnBackend.Repositories.Interface;
using DoAnBackend.Services.Interface;

namespace DoAnBackend.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IMapper _mapper;
        public MedicineService(IMedicineRepository medicineRepository, IMapper mapper)
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;
        }

        public async Task AddMedicineAsync(MedicineModel model)
        {
            var medicine = _mapper.Map<Medicine>(model);
            await _medicineRepository.AddMedicineAsync(medicine);
        }

        public async Task<IEnumerable<MedicineModel>> SearchMedicineAsync(string searchTerm)
        {
            var results = await _medicineRepository.SearchMedicineAsync(searchTerm);
            return _mapper.Map<IEnumerable<MedicineModel>>(results);
        }

        public async Task UpdateMedicineAsync(MedicineModel model)
        {
            var medicine = _mapper.Map<Medicine>(model);
            await _medicineRepository.UpdateMedicineAsync(medicine);
        }
    }
}
