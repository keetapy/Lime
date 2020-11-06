using Lime.DataAccess.Entities;
using Lime.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository
{
    public class TestRepository : IRepository
    {

        private string connectionString = @"Data Source=LAPTOP-8OT09GEB\SQLEXPRESS;Initial Catalog=ApartmentsDB;Integrated Security=True";
        //DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
        public List<Apartment> GetData()
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
            }
        }
    }
}
