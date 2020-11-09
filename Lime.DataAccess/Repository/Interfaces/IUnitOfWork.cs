using Lime.DataAccess.Repository.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        UserManagerIdentity UserManager { get; }
        IUserManager IUserManager { get; }
        RoleManagerIdentity RoleManager { get; }
        Task SaveAsync();
    }
}
