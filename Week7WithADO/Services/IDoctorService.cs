using Week7WithADO.Models.Doctor;

namespace Week7WithADO.Services
{
    public interface IDoctorService
    {
        Task<List<DoctorDto>> GetDoctors();
        Task<DoctorDto?> GetDoctorById(int id);
        Task<int> CreateDoctor(CreateDoctorModel model);
        Task<bool> UpdateDoctor(UpdateDoctorModel model);
        Task<bool> DeleteDoctor(int id);
    }
}
