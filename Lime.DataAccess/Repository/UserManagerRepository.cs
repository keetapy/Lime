using Lime.DataAccess.Entities;
using Lime.DataAccess.Infrastructure;
using Lime.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository
{
    public class UserManagerRepository : IUserManager
    {
        public UsersDBContext Database { get; set; }
        public UserManagerRepository(UsersDBContext db)
        {
            Database = db;
        }
        public void Create(User item)
        {
            Database.Users.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
