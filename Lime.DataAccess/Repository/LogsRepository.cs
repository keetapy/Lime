using Dapper;
using Lime.DataAccess.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository
{
    public class LogsRepository : ILogsRepository
    {
        IDatabaseConnection _connectionString;
        public LogsRepository(IDatabaseConnection connection)
        {
            _connectionString = connection;
        }
        public async Task<object> Set(DateTime date, string level, string message, string exception)
        {
            using (var connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = _connectionString.ConnectionString;
                    connection.Open();
                }
                catch (SqlException)
                {
                    connection.ConnectionString = _connectionString.ConnectionString;
                }

                await connection.ExecuteAsync("insert into CustomLogs(Logged, Level, Message, Exception) values (@date, @level, @Message, @exception)", new { date, level, message, exception });
                return null;
            }
        }
    }
}
