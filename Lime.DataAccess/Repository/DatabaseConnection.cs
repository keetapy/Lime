using Lime.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.DataAccess.Repository
{
    class DatabaseConnection : IDatabaseConnection
    {
        
        public string ConnectionString { get; set; }
        public DatabaseConnection(string connection)
        {
            ConnectionString = connection;
        }
    }
}
