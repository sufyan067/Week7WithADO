using Week7WithADO.Models;
using Week7WithADO.Models.Special;

namespace Week7WithADO.Services
{
    public interface IPatientService
    {
        Task<List<PatientDto>> GetPatients();
        Task<int> CreatePatient(CreatePatientModel model);
        Task<PatientDto?> GetPatientById(int id);
        Task<bool> UpdatePatient(UpdatePatientModel model);
        Task<bool> DeletePatient(int id);
        Task<List<PatientWithAppointments>> GetPatientsWithAppointments();
        Task<List<PatientsWithoutAppointments>> GetPatientsWithoutAppointments();
    }
}
