using Microsoft.Data.SqlClient;
using System.Data;
using Week7WithADO.Data;
using Week7WithADO.Entities;

namespace Week7WithADO.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DBHelper _dbHelper;
        public AuthRepository(DBHelper dBHelper)
        {
            _dbHelper = dBHelper;
        }
        public async Task<User?> GetUserByCredentials(string username, string password)
        {
            using (SqlConnection con = await _dbHelper.GetConnectionAsync())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetUserByCredentials", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new User
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Username = reader["Username"].ToString()!,
                                Password = reader["Password"].ToString()!
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
