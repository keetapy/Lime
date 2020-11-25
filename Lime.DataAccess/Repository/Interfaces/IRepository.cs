using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> Get();
    }
}
