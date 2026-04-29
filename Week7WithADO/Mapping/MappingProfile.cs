using AutoMapper;
using Week7WithADO.Entities;
using Week7WithADO.Models;
using Week7WithADO.Models.Appointment;
using Week7WithADO.Models.Doctor;

namespace Week7WithADO.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //  Entity -> DTO
            CreateMap<Patient, PatientDto>();
            CreateMap<Doctor, DoctorDto>();
            CreateMap<Appointment, AppointmentDto>();

            //  DTO -> Entity (future use: Create/Update)
            CreateMap<CreatePatientModel, Patient>();
            CreateMap<UpdatePatientModel, Patient>();

            CreateMap<CreateDoctorModel, Doctor>();
            CreateMap<UpdateDoctorModel, Doctor>();

            CreateMap<CreateAppointmentModel, Appointment>();
            CreateMap<UpdateAppointmentModel, Appointment>();
        }
    }
}
