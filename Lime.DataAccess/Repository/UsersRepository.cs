using Lime.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.DataAccess.Repository
{
    public class UsersRepository : IRepository
    {
        IDatabaseConnection _connectionString;
        public UsersRepository(IDatabaseConnection connection)
        {
            _connectionString = connection;
        }
    }
}
