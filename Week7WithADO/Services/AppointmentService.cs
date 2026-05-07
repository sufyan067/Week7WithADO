using AutoMapper;
using Week7WithADO.Entities;
using Week7WithADO.Models.Appointment;
using Week7WithADO.Models.Special;
using Week7WithADO.Repositories;

namespace Week7WithADO.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repo;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<List<AppointmentDto>> GetAppointments()
        {
            var data = await _repo.GetAppointments();
            return _mapper.Map<List<AppointmentDto>>(data);
        }

        public async Task<AppointmentDto?> GetAppointmentById(int id)
        {
            var data = await _repo.GetAppointmentById(id);

            if (data == null)
                return null;

            return _mapper.Map<AppointmentDto>(data);
        }

        public async Task<int> CreateAppointment(CreateAppointmentModel model)
        {
            var entity = _mapper.Map<Appointment>(model);
            return await _repo.CreateAppointment(entity);
        }

        public async Task<bool> UpdateAppointment(UpdateAppointmentModel model)
        {
            var entity = _mapper.Map<Appointment>(model);
            return await _repo.UpdateAppointment(entity);
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            return await _repo.DeleteAppointment(id);
        }
        public async Task<List<AppointmentByDoctor>> GetAppointmentsByDoctor(int doctorId)
        {
            return await _repo.GetAppointmentsByDoctor(doctorId);
        }
    }
}
