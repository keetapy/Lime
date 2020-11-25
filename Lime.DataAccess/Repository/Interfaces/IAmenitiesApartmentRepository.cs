using Lime.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository.Interfaces
{
    public interface IAmenitiesApartmentRepository
    {
        Task<List<AmenitiesApartment>> Get();
    }
}
