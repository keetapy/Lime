using Lime.Business.Services.Interfaces;
using Lime.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime.Business.Services
{
    public class testService: ITestService
    {
        private readonly IRepository _repository;
        public testService(IRepository repository)
        {
            _repository = repository;
        }
       
        public object GetData()
        {
            return _repository.GetData();

        }

       

        
    }
}
