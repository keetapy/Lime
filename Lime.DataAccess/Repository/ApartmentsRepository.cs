using Dapper;
using Lime.DataAccess.Entities;
using Lime.DataAccess.Repository.Interfaces;
using Lime.ViewModels.Views;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Lime.ViewModels.ViewItems;
using Lime.ViewModels.ViewModels;
using Microsoft.Data.SqlClient.Server;

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
        public async Task<GetApartmentView> GetById(int id)
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
                SqlCommand Command = new SqlCommand();
                var apartment = await connection.QueryAsync<Apartment, ApartmentAddress, ApartmentType, InternetProvider, DealType, GetApartmentView>(
             $@"SELECT a.[Id], a.FlatNumber, a.Price, a.ApartmentSquare, a.ApartmentTypeId, a.InternetProviderId, a.DealTypeId,
                aa.Id, aa.PostalCode, aa.Country, aa.City, aa.Street, aa.HouseNumber,
                at.Id, at.Name,
                ip.Id, ip.Name, ip.Phone,ip.Email,
                dt.Id, dt.Name
                FROM Apartments a
                INNER JOIN ApartmentAddresses aa ON aa.Id=a.Id
                INNER JOIN ApartmentTypes at ON at.Id=a.ApartmentTypeId
                INNER JOIN InternetProviders ip ON ip.Id=a.InternetProviderId
                INNER JOIN DealTypes dt ON dt.Id=a.DealTypeId WHERE a.id=@Id", (a, aa, at, ip, dt) =>
                {
                    return new GetApartmentView
                    {
                        ApartmentAddress = new ApartmentAddressViewItem
                        {
                            PostalCode = aa.PostalCode,
                            Country = aa.Country,
                            City = aa.City,
                            Street = aa.Street,
                            HouseNumber = aa.HouseNumber
                        },
                        InternetProvider = new InternetProviderViewItem
                        {
                            Id = ip.Id,
                            Name = ip.Name,
                            Phone = ip.Phone,
                            Email = ip.Email
                        },
                        FlatNumber = a.FlatNumber,
                        ApartmentType = at.Name,
                        Price = a.Price,
                        ApartmentSquare = a.ApartmentSquare,
                        DealType = dt.Name,
                        Id = a.Id
                    };
                }, new {Id=id } );
                return apartment.AsQueryable().FirstOrDefault();
            }
        }
       
        public async Task<List<Apartment>> Set(List<SetApartmentsViewModel> setApartments)
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
               
                var dt = new DataTable();
                dt = SetColumns(dt);
                foreach (var item in setApartments)
                {
                    dt.Rows.Add(item.Id,item.ApartmentTypeId,item.FlatNumber,item.Price,item.ApartmentSquare,item.Photo,item.InternetProviderId,item.DealTypeId);

                }
                await connection.ExecuteAsync("dbo.NewApartmentSet", new { newSet = dt.AsTableValuedParameter("[dbo].[TempApartment]") }, commandType: CommandType.StoredProcedure);
                return await Get();
            }
        }
        private DataTable SetColumns(DataTable dt)
        {
            dt.Columns.Add(new DataColumn("Id", typeof(int)));
            dt.Columns.Add(new DataColumn("ApartmentTypeId", typeof(int)));
            dt.Columns.Add(new DataColumn("FlatNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(double)));
            dt.Columns.Add(new DataColumn("ApartmentSquare", typeof(int)));
            dt.Columns.Add(new DataColumn("Photo", typeof(string)));
            dt.Columns.Add(new DataColumn("InternetProviderId", typeof(int)));
            dt.Columns.Add(new DataColumn("DealTypeId", typeof(int)));

            return dt;
        }
        
    }
}
