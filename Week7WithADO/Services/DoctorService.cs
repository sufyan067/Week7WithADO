using AutoMapper;
using Week7WithADO.Entities;
using Week7WithADO.Models.Doctor;
using Week7WithADO.Repositories;

namespace Week7WithADO.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repo;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<List<DoctorDto>> GetDoctors()
        {
            var doctors = await _repo.GetDoctors();
            return _mapper.Map<List<DoctorDto>>(doctors);
        }
        public async Task<DoctorDto?> GetDoctorById(int id)
        {
            var doctor = await _repo.GetDoctorById(id);

            if (doctor == null)
                return null;

            return _mapper.Map<DoctorDto>(doctor);
        }
        public async Task<int> CreateDoctor(CreateDoctorModel model)
        {
            var entity = _mapper.Map<Doctor>(model);
            return await _repo.CreateDoctor(entity);
        }
        public async Task<bool> UpdateDoctor(UpdateDoctorModel model)
        {
            var entity = _mapper.Map<Doctor>(model);
            return await _repo.UpdateDoctor(entity);
        }
        public async Task<bool> DeleteDoctor(int id)
        {
            return await _repo.DeleteDoctor(id);
        }
    }
}
