using Lime.DataAccess.Infrastructure;
using Lime.DataAccess.Repository.Identity;
using Lime.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository
{
    class UnitOfWorkRepository : IUnitOfWork
    {
        private UsersDBContext db;
        private UserManagerIdentity userManagerIdentity;
        private RoleManagerIdentity roleManagerIdentity;
        private IUserManager userManager;
        private bool disposed = false;

        public UserManagerIdentity UserManager { get { return userManagerIdentity; } }
        public IUserManager IUserManager { get{ return userManager; } }
        public RoleManagerIdentity RoleManager { get { return roleManagerIdentity; } }

        public UnitOfWorkRepository()
        {
            db = new UsersDBContext();
            userManagerIdentity = new UserManagerIdentity(new Microsoft.AspNet.Identity.EntityFramework.UserStore<Entities.User>(db));
            roleManagerIdentity = new RoleManagerIdentity(new Microsoft.AspNet.Identity.EntityFramework.RoleStore<Entities.Role>(db));
            userManager = new UserManagerRepository(db);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManagerIdentity.Dispose();
                    roleManagerIdentity.Dispose();
                    userManager.Dispose();
                }
                this.disposed = true;
            }
        }
        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
