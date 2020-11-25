using Lime.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository.Interfaces
{
    public interface IApartmentsAddressesRepository
    {
        Task<List<ApartmentAddress>> Get();

    }
}
