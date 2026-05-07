using Week7WithADO.Entities;

namespace Week7WithADO.Repositories
{
    public interface IDoctorRepository
    {
        Task<int> CreateDoctor(Doctor doctor);
        Task<List<Doctor>> GetDoctors();
        Task<Doctor?> GetDoctorById(int id);
        Task<bool> UpdateDoctor(Doctor doctor);
        Task<bool> DeleteDoctor(int id);
    }
}
