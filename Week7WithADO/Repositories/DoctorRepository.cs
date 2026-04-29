using Microsoft.Data.SqlClient;
using System.Data;
using Week7WithADO.Data;
using Week7WithADO.Entities;

namespace Week7WithADO.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DBHelper _dbHelper;
        public DoctorRepository(DBHelper dBHelper)
        {
            _dbHelper = dBHelper;
        }
        public async Task<int> CreateDoctor(Doctor doctor)
        {
            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_CreateDoctor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", doctor.LastName);
                    cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
                    cmd.Parameters.AddWithValue("@ConsultationFee", doctor.ConsultationFee);
                    cmd.Parameters.AddWithValue("@IsAvailable", doctor.IsAvailable);

                    var result = await cmd.ExecuteScalarAsync();
                    return Convert.ToInt32(result);
                }
            }
        }
        public async Task<List<Doctor>> GetDoctors()
        {
            var doctors = new List<Doctor>();

            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetDoctors", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            doctors.Add(new Doctor
                            {
                                DoctorId = Convert.ToInt32(reader["DoctorId"]),
                                FirstName = reader["FirstName"].ToString()!,
                                LastName = reader["LastName"].ToString()!,
                                Specialization = reader["Specialization"].ToString()!,
                                ConsultationFee = Convert.ToDecimal(reader["ConsultationFee"]),
                                IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
                            });
                        }
                    }
                }
            }

            return doctors;
        }
        public async Task<Doctor?> GetDoctorById(int id)
        {
            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetDoctorById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DoctorId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Doctor
                            {
                                DoctorId = Convert.ToInt32(reader["DoctorId"]),
                                FirstName = reader["FirstName"].ToString()!,
                                LastName = reader["LastName"].ToString()!,
                                Specialization = reader["Specialization"].ToString()!,
                                ConsultationFee = Convert.ToDecimal(reader["ConsultationFee"]),
                                IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
                            };
                        }
                    }
                }
            }

            return null;
        }
        public async Task<bool> UpdateDoctor(Doctor doctor)
        {
            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateDoctor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DoctorId", doctor.DoctorId);
                    cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", doctor.LastName);
                    cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
                    cmd.Parameters.AddWithValue("@ConsultationFee", doctor.ConsultationFee);
                    cmd.Parameters.AddWithValue("@IsAvailable", doctor.IsAvailable);

                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }
        public async Task<bool> DeleteDoctor(int id)
        {
            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteDoctor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DoctorId", id);

                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }
    }
}
