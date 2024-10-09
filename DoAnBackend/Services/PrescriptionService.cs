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
        private readonly IAppointmentRepository _appointmentRepository;
        public PrescriptionService(IPrescriptionRepository prescriptionRepository, IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            _prescriptionRepository = prescriptionRepository;
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }

        public async Task AddMedicineToPrescriptionDetailsAsync(string prescriptionName, List<PrescriptionModel.CreatePrescriptionDetails> medicines)
        {
            var prescriptionDetails = medicines.Select(m => new PrescriptionDetail
            {
                PrescriptionName = prescriptionName,
                MedicineName = m.MedicineID,
                Quantity = m.Quantity,
            }).ToList();
            await _prescriptionRepository.AddPrescriptionDetailsAsync(prescriptionDetails);
        }

        public async Task<PrescriptionModel> CreatePrescriptionAsync(PrescriptionModel.CreatePrescription prescriptionModel, string appointmentName)
        {
            // Lấy thông tin chi tiết của Appointment bằng tên
            var appointment = await _appointmentRepository.GetByAppointmentNameDetailsAsync(appointmentName);

            // Nếu không tìm thấy Appointment, ném Exception
            if (appointment == null)
            {
                throw new Exception("Appointment not found");
            }

            // Tạo tên Prescription theo quy tắc mong muốn
            var emailPatient = appointment.PatientEmail.Split('@')[0];
            var formattedDate = appointment.AppointmentDate.ToString("ddMMyyyy");
            var prescriptionName = $"d{formattedDate}p{emailPatient}";

            // Ánh xạ từ PrescriptionModel.CreatePrescription sang Prescription Entity
            var prescription = new Prescription
            {
                PrescriptionName = prescriptionName,
                Conclusion = prescriptionModel.Conclusion,
                NextAppointment = prescriptionModel.NextAppointment,
                AppointmentId = appointment.Id, // Lấy trực tiếp từ Appointment
                AppointmentName = appointmentName,
                PatientId = appointment.PatientId,
                PatientName = appointment.PatientName,
                DoctorId = appointment.DoctorId,
                DoctorName = appointment.DoctorName,
                DoctorEmail = appointment.DoctorEmail
            };

            // Tạo Prescription mới trong cơ sở dữ liệu
            var createdPrescription = await _prescriptionRepository.CreatePrescriptionAsync(prescription);

            // Trả về PrescriptionModel sau khi ánh xạ từ Prescription Entity
            return _mapper.Map<PrescriptionModel>(createdPrescription);
        }
        public async Task<PrescriptionModel> GetPrescriptionByAppointmentName(string appointmentName)
        {
            var prescription = await _prescriptionRepository.GetPrescriptionByAppointmentName(appointmentName);
            return _mapper.Map<PrescriptionModel>(prescription);
        }
        public async Task UpdatePrescription(PrescriptionModel prescriptionModel)
        {
            var prescription = await _prescriptionRepository.GetPrescriptionByAppointmentName(prescriptionModel.AppointmentName);
            _mapper.Map(prescriptionModel, prescription);

            if(prescriptionModel.PrescriptionDetails != null)
            {
                var updatedDetails = prescriptionModel.PrescriptionDetails.Select(detailModel =>
                _mapper.Map<PrescriptionDetail>(detailModel)).ToList();
                prescription.PrescriptionDetails = updatedDetails;
            }
            await _prescriptionRepository.UpdatePrescription(prescription);
        }
        private string ReverseAppointmentName(string appointmentName)
        {
            var name = _appointmentRepository.GetByAppointmentNameDetailsAsync(appointmentName);
            if (name == null) throw new ArgumentNullException("name");
            
            var patientEmailStartIndex = appointmentName.IndexOf("p") + 1;
            var doctorDateIndex = appointmentName.IndexOf("d");

            var patientEmail = appointmentName.Substring(patientEmailStartIndex, doctorDateIndex - patientEmailStartIndex);
            var appointmentDateStr = appointmentName.Substring(doctorDateIndex + 1);

            var appointmentDate = DateOnly.ParseExact(appointmentDateStr, "ddMMyyyy");
            return $"d{appointmentDate:ddMMyyyy}p{patientEmail}";
        }
    }
}
