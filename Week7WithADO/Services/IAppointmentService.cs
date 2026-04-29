using Week7WithADO.Models.Appointment;
using Week7WithADO.Models.Special;

namespace Week7WithADO.Services
{
    public interface IAppointmentService
    {
        Task<List<AppointmentDto>> GetAppointments();
        Task<AppointmentDto?> GetAppointmentById(int id);
        Task<int> CreateAppointment(CreateAppointmentModel model);
        Task<bool> UpdateAppointment(UpdateAppointmentModel model);
        Task<bool> DeleteAppointment(int id);
        Task<List<AppointmentByDoctor>> GetAppointmentsByDoctor(int doctorId);
    }
}
