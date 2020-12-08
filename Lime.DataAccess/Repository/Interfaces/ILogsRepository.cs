using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository.Interfaces
{
    public interface ILogsRepository
    {
        Task<object> Set(DateTime date, string level, string message, string exception);
    }
}
