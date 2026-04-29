using AutoMapper;
using Week7WithADO.Entities;
using Week7WithADO.Models;
using Week7WithADO.Models.Special;
using Week7WithADO.Repositories;

namespace Week7WithADO.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<List<PatientDto>> GetPatients()
        {
            var patients = await _repo.GetPatients();

            return _mapper.Map<List<PatientDto>>(patients);
        }
        public async Task<int> CreatePatient(CreatePatientModel model)
        {
            var entity = _mapper.Map<Patient>(model);

            return await _repo.CreatePatient(entity);
        }
        public async Task<PatientDto?> GetPatientById(int id)
        {
            var patient = await _repo.GetPatientById(id);

            if (patient == null)
                return null;

            return _mapper.Map<PatientDto>(patient);
        }
        public async Task<bool> UpdatePatient(UpdatePatientModel model)
        {
            var entity = _mapper.Map<Patient>(model);

            return await _repo.UpdatePatient(entity);
        }
        public async Task<bool> DeletePatient(int id)
        {
            return await _repo.DeletePatient(id);
        }
        public async Task<List<PatientWithAppointments>> GetPatientsWithAppointments()
        {
            return await _repo.GetPatientsWithAppointments();
        }
        public async Task<List<PatientsWithoutAppointments>> GetPatientsWithoutAppointments()
        {
            return await _repo.GetPatientsWithoutAppointments();
        }
    }
}
