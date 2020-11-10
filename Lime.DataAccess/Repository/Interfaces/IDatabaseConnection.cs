using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.DataAccess.Repository.Interfaces
{
    public interface IDatabaseConnection
    {
        string ConnectionString { get; set; }
    }
}
