using Lime.DataAccess.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository.Identity
{
    public class RoleManagerIdentity:RoleManager<Role>
    {
        public RoleManagerIdentity(RoleStore<Role> store):base(store)
        {

        }
    }
}
