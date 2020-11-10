using Dapper;
using Lime.DataAccess.Entities;
using Lime.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository
{
    class TestRepository:IRepository
    {
        IDatabaseConnection _connectionString;
        public TestRepository(IDatabaseConnection connection)
        {
            _connectionString = connection;
        }
       // public string connectionString { get; set; }

        // private string connectionString = @"Data Source=LAPTOP-8OT09GEB\SQLEXPRESS;Initial Catalog=ApartmentsDB;Integrated Security=True";

        /*public Apartment GetApartmentById(int id)
        {
            return GetData().FirstOrDefault(x => x.Id == id);
        }*/

        public async Task<List<Apartment>> GetData()
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
                //istal dapper
                var result = await connection.QueryAsync<Apartment>("SELECT * FROM Apartments;",
                     commandType: CommandType.Text);

                return result.AsList();
            }
        }

        //DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
        /*public List<Apartment> GetData()
        {
            List<Apartment> Apartments = new List<Apartment>();
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                }
                catch (SqlException)
                {
                    connection.ConnectionString = connectionString;
                }
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "SELECT * FROM Apartments;";
                Command.Connection = connection;
                SqlDataReader DataReader = Command.ExecuteReader();
                try
                {
                    do
                    {
                        while (DataReader.Read())
                        {
                            Apartments.Add(new Apartment
                            {
                                Id = Convert.ToInt32(DataReader.GetValue(0)),
                                Price = Convert.ToDouble(DataReader.GetValue(1)),
                                ApartmentsAddressId = Convert.ToInt32(DataReader.GetValue(2)),
                                ApartmentTypeId = Convert.ToInt32(DataReader.GetValue(3)),
                                FlatNumber = DataReader.GetValue(4).ToString(),
                                ApartmentSquare = Convert.ToInt32(DataReader.GetValue(5)),
                                Photo = DataReader.GetValue(6).ToString(),
                                InternetProviderId = Convert.ToInt32(DataReader.GetValue(7)),
                                DealTypeId = Convert.ToInt32(DataReader.GetValue(8)),
                            });
                        }

                    } while (DataReader.NextResult());
                }
                finally
                {
                    DataReader.Close();

                }
                return Apartments;
            }*/
    }
}
