using Dapper;
using Lime.DataAccess.Entities;
using Lime.DataAccess.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository
{
    public class InternetProvidersRepository :IInternetProvidersRepository
    {
        IDatabaseConnection _connectionString;
        public InternetProvidersRepository(IDatabaseConnection connection)
        {
            _connectionString = connection;
        }
        public async Task<List<InternetProvider>> Get()
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
                var result = await connection.QueryAsync<InternetProvider>("SELECT * FROM InternetProviders;",
                     commandType: CommandType.Text);

                return result.AsList();
            }
        }
    }
}
