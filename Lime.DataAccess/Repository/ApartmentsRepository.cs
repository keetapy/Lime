using Dapper;
using Lime.DataAccess.Entities;
using Lime.DataAccess.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository
{
    public class ApartmentsRepository : IApartmentRepository
    {
        IDatabaseConnection _connectionString;
        public ApartmentsRepository(IDatabaseConnection connection)
        {
            _connectionString = connection;
        }
        public async Task<List<Apartment>> Get()
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
                var result = await connection.QueryAsync<Apartment>("SELECT * FROM Apartments;",
                     commandType: CommandType.Text);

                return result.AsList();
            }
        }
        // InternetProvidersRepository
       
        // ClientsRepository
       
        // ApartmentsTypesRepository
        // DealTypesRepository
        // ApartmentsAddressesRepository
        
        // RentalDealsRepository
    }
}
