using Microsoft.Data.SqlClient;

namespace Week7WithADO.Data
{
    public class DBHelper
    {
        private readonly string _connectionString;
        public DBHelper(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("dbcs")
                 ?? throw new Exception("Connection string 'dbcs' not found.");
        }
        public async Task<SqlConnection> GetConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
