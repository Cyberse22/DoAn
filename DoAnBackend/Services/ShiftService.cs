using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Models;
using DoAnBackend.Repositories.Interface;
using DoAnBackend.Services.Interface;

namespace DoAnBackend.Services;

public class ShiftService : IShiftService
{
    private readonly IShiftRepository _shiftRepository;
    private readonly IMapper _mapper;

    public ShiftService(IShiftRepository shiftRepository, IMapper mapper)
    {
        _shiftRepository = shiftRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ShiftModel>> GetShiftsAsync()
    {
        var shifts = await _shiftRepository.GetAllShiftAsync();
        return _mapper.Map<IEnumerable<ShiftModel>>(shifts);
    }

    public async Task<ShiftModel> GetShiftByIdAsync(Guid shiftId)
    {
        var shift = await _shiftRepository.GetShiftByIdAsync(shiftId);
        return _mapper.Map<ShiftModel>(shift);
    }

    public async Task<ShiftModel> CreateShiftAsync(ShiftModel.CreateShiftModel model)
    {
        var currentDate = DateTime.Now.ToString("ddMMyyyy");
        var shiftName = $"{model.ShiftType}{currentDate}";

        var shift = new Shift
        {
            ShiftName = shiftName,
            ShiftType = model.ShiftType,
            StartTime = TimeOnly.ParseExact(model.StartTime, "HH:mm tt"),
            EndTime = TimeOnly.ParseExact(model.EndTime, "HH:mm tt"),
        }; 
        await _shiftRepository.CreateShiftAsync(shift);
        return null;
    }

    public async Task UpdateShiftAsync(string shiftName, ShiftModel.CreateShiftModel model)
    {
        var shift = await _shiftRepository.GetShiftByNameAsync(shiftName);
        if (shift == null) throw new Exception("Shift not found");
        _mapper.Map(model, shift);
        await _shiftRepository.UpdateShiftAsync(shift);
    }

    public async Task DeleteShiftAsync(string shiftName)
    {
        await _shiftRepository.DeleteShiftAsync(shiftName);
    }

    public async Task<Shift> GetShiftByNameAsync(string shiftName)
    {
        return await _shiftRepository.GetShiftByNameAsync(shiftName); 
    }
}