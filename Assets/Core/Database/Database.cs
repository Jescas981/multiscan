using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System;
using System.Threading.Tasks;

namespace Multiscan.Database
{
    class Database
    {
        private string _connectionString;

        public void mutate(string cmd, params IParameter[] parameters)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(cmd, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters.Select(item => item.apply()).ToArray());
            connection.Open();
            command.ExecuteNonQuery();
        }

        public async Task<T?> query<T>(string procedure, params SqlParameter[] parameters)
            where T : class, new()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = new SqlCommand(procedure, connection);

            await connection.OpenAsync();

            // Command of stored procedure
            command.CommandType = CommandType.StoredProcedure;

            // Add variables of request to command
            command.Parameters.AddRange(parameters);
            var reader = await command.ExecuteReaderAsync();

            // Get all template object properties
            var properties = typeof(T).GetProperties();

            // Create instance of template object
            var obj = new T();

            if (!reader.HasRows)
                return null;

            await reader.ReadAsync();

            // Retrieve data
            for (int i = 0; i < properties.Length; i++)
            {
                var value = reader.GetValue(i);
                properties[i].SetValue(obj, value);
            }

            return obj;
        }
    }
}
