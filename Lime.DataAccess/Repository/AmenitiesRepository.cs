using Dapper;
using Lime.DataAccess.Entities;
using Lime.DataAccess.Repository.Interfaces;
using Lime.ViewModels.Views;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository
{
    public class AmenitiesRepository : IAmenitiesRepository
    {
        IDatabaseConnection _connectionString;
        public AmenitiesRepository(IDatabaseConnection connection)
        {
            _connectionString = connection;
        }
        public async Task<List<Amenities>> Get()
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
                var result = await connection.QueryAsync<Amenities>("SELECT * FROM Amenities;",
                     commandType: CommandType.Text);

                return result.AsList();
            }
        }
        
    }
}
