using Week7WithADO.Data;
using Week7WithADO.Repositories;
using Week7WithADO.Services;

namespace Week7WithADO.Extensions
{
    public static class DependencyRegistrar
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //  DB Helper
            services.AddScoped<DBHelper>();

            //  AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //  Repositories
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            //  Services
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAppointmentService, AppointmentService>();

            return services;
        }
    }
}