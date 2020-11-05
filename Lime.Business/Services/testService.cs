using Lime.Business.Services.Interfaces;
using Lime.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime.Business.Services
{
    public class testService
    {
        IRepository repository;
        public testService(IRepository repository)
        {
            this.repository = repository;
        }

       public object gettestdata()
        {
            return repository.GetData();
        }

        
    }
}
