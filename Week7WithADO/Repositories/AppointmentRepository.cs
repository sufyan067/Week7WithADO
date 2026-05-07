using Microsoft.Data.SqlClient;
using System.Data;
using Week7WithADO.Data;
using Week7WithADO.Entities;
using Week7WithADO.Models.Special;

namespace Week7WithADO.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DBHelper _dbHelper;

        public AppointmentRepository(DBHelper dBHelper ) 
        {
            _dbHelper = dBHelper;
        }
        public async Task<int> CreateAppointment(Appointment appointment)
        {
            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_CreateAppointment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@Status", appointment.Status);
                    cmd.Parameters.AddWithValue("@VisitType", appointment.VisitType);
                    cmd.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                    cmd.Parameters.AddWithValue("@DoctorId", (object?)appointment.DoctorId ?? DBNull.Value);

                    var result = await cmd.ExecuteScalarAsync();

                    return Convert.ToInt32(result);
                }
            }
        }
        public async Task<List<Appointment>> GetAppointments()
        {
            var list = new List<Appointment>();

            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAppointments", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            list.Add(new Appointment
                            {
                                AppointmentId = Convert.ToInt32(reader["AppointmentId"]),
                                AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                                Status = reader["Status"].ToString()!,
                                VisitType = reader["VisitType"].ToString()!,
                                PatientId = Convert.ToInt32(reader["PatientId"]),
                                DoctorId = reader["DoctorId"] as int?
                            });
                        }
                    }
                }
            }

            return list;
        }
        public async Task<Appointment?> GetAppointmentById(int id)
        {
            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAppointmentById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AppointmentId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Appointment
                            {
                                AppointmentId = Convert.ToInt32(reader["AppointmentId"]),
                                AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                                Status = reader["Status"].ToString()!,
                                VisitType = reader["VisitType"].ToString()!,
                                PatientId = Convert.ToInt32(reader["PatientId"]),
                                DoctorId = reader["DoctorId"] as int?
                            };
                        }
                    }
                }
            }

            return null;
        }
        public async Task<bool> UpdateAppointment(Appointment appointment)
        {
            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateAppointment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);
                    cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@Status", appointment.Status);
                    cmd.Parameters.AddWithValue("@VisitType", appointment.VisitType);
                    cmd.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                    cmd.Parameters.AddWithValue("@DoctorId", (object?)appointment.DoctorId ?? DBNull.Value);

                    int rows = await cmd.ExecuteNonQueryAsync();

                    return rows > 0;
                }
            }
        }
        public async Task<bool> DeleteAppointment(int id)
        {
            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteAppointment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AppointmentId", id);

                    int rows = await cmd.ExecuteNonQueryAsync();

                    return rows > 0;
                }
            }
        }
        public async Task<List<AppointmentByDoctor>> GetAppointmentsByDoctor(int doctorId)
        {
            var list = new List<AppointmentByDoctor>();

            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAppointmentsByDoctor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DoctorId", doctorId);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            list.Add(new AppointmentByDoctor
                            {
                                AppointmentId = Convert.ToInt32(reader["AppointmentId"]),
                                AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                                Status = reader["Status"].ToString()!,
                                VisitType = reader["VisitType"].ToString()!,
                                PatientId = Convert.ToInt32(reader["PatientId"])
                            });
                        }
                    }
                }
            }

            return list;
        }
    }
}
