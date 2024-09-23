using DoAnBackend.Helpers;
using DoAnBackend.Services;
using DoAnBackend.Services.Interface;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace DoAnBackend.Models
{
    public class AppointmentModel
    {
        public Guid Id { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? TimeSpan { get; set; }
        public string? Reason { get; set; }
        public string? FormattedDate => Date?.ToString("dd/MM/yyyy");

        private AppointmentModel() 
        {
            Id = Guid.NewGuid();
        }

        [JsonConstructor]
        public AppointmentModel(Guid id, DateTime? date, TimeSpan? timeSpan, string? reason)
        {
            Id = id;
            Date = date;
            TimeSpan = timeSpan;
            Reason = reason;
        }


        public class AppointmentDetails : AppointmentModel
        {
            public string Status { get; set; } = "Pending";
        }

        public class NurseAccept : AppointmentModel
        {
            private readonly IAccountService _accountService;

            public string? NurseId { get; set; }
            public void setNurseId(ClaimsPrincipal user)
            {
                var currentUser = Helpers.Helper.CreateCurrentUserModel(_accountService, user).Result;
                NurseId = currentUser.Id;
            }
        }

        public class DoctorGet : NurseAccept 
        {
            private readonly IAccountService _accountService;
            public string? DoctorId { get; set; }
            public void SetDoctorId(ClaimsPrincipal user)
            {
                var currentUser = Helpers.Helper.CreateCurrentUserModel(_accountService, user).Result; // Gọi hàm để lấy thông tin người dùng
                DoctorId = currentUser.Id; // Gán DoctorId
            }
        }
    }


}
