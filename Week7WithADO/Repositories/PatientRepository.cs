using Microsoft.Data.SqlClient;
using System.Data;
using Week7WithADO.Data;
using Week7WithADO.Entities;
using Week7WithADO.Models.Special;

namespace Week7WithADO.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DBHelper _dbHelper;
        public PatientRepository(DBHelper dBHelper)
        {
            _dbHelper = dBHelper;
        }
        public async Task<List<Patient>> GetPatients()
        {
            var patients = new List<Patient>();

            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetPatients", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            patients.Add(new Patient
                            {
                                PatientId = Convert.ToInt32(reader["PatientId"]),
                                FirstName = reader["FirstName"].ToString()!,
                                LastName = reader["LastName"].ToString()!,
                                Email = reader["Email"] as string,
                                City = reader["City"] as string,
                                PhoneNumber = reader["PhoneNumber"] as string,
                                DateOfBirth = reader["DateOfBirth"] as DateTime?
                            });
                        }
                    }
                }
            }

            return patients;
        }
        public async Task<int> CreatePatient(Patient patient)
        {
            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_CreatePatient", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 🔹 Parameters add karna
                    cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                    cmd.Parameters.AddWithValue("@Email", (object?)patient.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@City", (object?)patient.City ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneNumber", (object?)patient.PhoneNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", (object?)patient.DateOfBirth ?? DBNull.Value);

                    // 🔹 Execute + return new ID
                    var result = await cmd.ExecuteScalarAsync();

                    return Convert.ToInt32(result);
                }
            }
        }
        public async Task<Patient?> GetPatientById(int id)
        {
            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetPatientById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PatientId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Patient
                            {
                                PatientId = Convert.ToInt32(reader["PatientId"]),
                                FirstName = reader["FirstName"].ToString()!,
                                LastName = reader["LastName"].ToString()!,
                                Email = reader["Email"] as string,
                                City = reader["City"] as string,
                                PhoneNumber = reader["PhoneNumber"] as string,
                                DateOfBirth = reader["DateOfBirth"] as DateTime?
                            };
                        }
                    }
                }
            }

            return null;
        }
        public async Task<bool> UpdatePatient(Patient patient)
        {
            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdatePatient", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PatientId", patient.PatientId);
                    cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                    cmd.Parameters.AddWithValue("@Email", (object?)patient.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@City", (object?)patient.City ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneNumber", (object?)patient.PhoneNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", (object?)patient.DateOfBirth ?? DBNull.Value);

                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }
        public async Task<bool> DeletePatient(int id)
        {
            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeletePatient", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PatientId", id);

                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }
        public async Task<List<PatientWithAppointments>> GetPatientsWithAppointments()
        {
            var result = new List<PatientWithAppointments>();

            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetPatientsWithAppointments", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new PatientWithAppointments
                            {
                                PatientId = Convert.ToInt32(reader["PatientId"]),
                                FirstName = reader["FirstName"].ToString()!,
                                AppointmentCount = Convert.ToInt32(reader["AppointmentCount"])
                            });
                        }
                    }
                }
            }

            return result;
        }
        public async Task<List<PatientsWithoutAppointments>> GetPatientsWithoutAppointments()
        {
            var result = new List<PatientsWithoutAppointments>();

            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetPatientsWithoutAppointments", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new PatientsWithoutAppointments
                            {
                                PatientId = Convert.ToInt32(reader["PatientId"]),
                                FirstName = reader["FirstName"].ToString()!
                            });
                        }
                    }
                }
            }

            return result;
        }
    }
}
