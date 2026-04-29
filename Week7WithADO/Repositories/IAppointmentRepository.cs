using Week7WithADO.Entities;
using Week7WithADO.Models.Special;

namespace Week7WithADO.Repositories
{
    public interface IAppointmentRepository
    {
        Task<int> CreateAppointment(Appointment appointment);
        Task<List<Appointment>> GetAppointments();
        Task<Appointment?> GetAppointmentById(int id);
        Task<bool> UpdateAppointment(Appointment appointment);
        Task<bool> DeleteAppointment(int id);
        Task<List<AppointmentByDoctor>> GetAppointmentsByDoctor(int doctorId);
    }
}
