using Lime.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository.Interfaces
{
    public interface IRepository
    {
        Task<List<Apartment>> GetData();
        //Apartment GetApartmentById(int id);
    }
}
