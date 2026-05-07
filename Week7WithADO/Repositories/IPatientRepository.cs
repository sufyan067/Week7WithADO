using Week7WithADO.Entities;
using Week7WithADO.Models.Special;
namespace Week7WithADO.Repositories
{
    public interface IPatientRepository
    {
       
        Task<int> CreatePatient(Patient patient);
        Task<List<Patient>> GetPatients();
        Task<Patient?> GetPatientById(int id);
        Task<bool> UpdatePatient(Patient patient);
        Task<bool> DeletePatient(int id);
        Task<List<PatientWithAppointments>> GetPatientsWithAppointments();
        Task<List<PatientsWithoutAppointments>> GetPatientsWithoutAppointments();
    }
}


//Special queries DTO return kary gi 
//Projection already SQL/SP me ho rahi hai - DTO directly return