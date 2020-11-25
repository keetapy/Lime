using Dapper;
using Lime.DataAccess.Entities;
using Lime.DataAccess.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository
{
    public class ClientsRepository : IClientsRepository
    {
        IDatabaseConnection _connectionString;
        public ClientsRepository(IDatabaseConnection connection)
        {
            _connectionString = connection;
        }
        public async Task<List<Client>> Get()
        {
            using (SqlConnection connection = new SqlConnection())
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
                SqlCommand Command = new SqlCommand();
                var result = await connection.QueryAsync<Client>("SELECT * FROM Clients;",
                     commandType: CommandType.Text);

                return result.AsList();
            }
        }
    }
}
