using Lime.DataAccess.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime.DataAccess.Infrastructure
{
    public class UsersDBContext: IdentityDbContext<User>
    {
        public UsersDBContext(): base("IdentityDb")
        {

        }
        static UsersDBContext()
        {
            System.Data.Entity.Database.SetInitializer<UsersDBContext>(new IdentityDbInit());
        }
        public static UsersDBContext Create()
        {
            return new UsersDBContext();
        }
    }
}
