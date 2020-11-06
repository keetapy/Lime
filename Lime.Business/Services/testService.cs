using Lime.Business.Services.Interfaces;
using Lime.DataAccess.Entities;
using Lime.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime.Business.Services
{
    public class TestService: ITestService
    {
        private readonly IRepository _repository;
        public TestService(IRepository repository)
        {
            _repository = repository;
        }
       
        public List<Apartment> GetData()
        {
            return _repository.GetData();

        }

       

        
    }
}
