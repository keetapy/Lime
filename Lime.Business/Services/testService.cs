using Lime.Business.Services.Interfaces;
using Lime.DataAccess.Entities;
using Lime.DataAccess.Repository.Interfaces;
using Lime.ViewModels;
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
       
        public List<ApartmentView> GetData()
        {
            List<ApartmentView> tmp = new List<ApartmentView>();
            foreach (Apartment item in _repository.GetData())
            {
                tmp.Add(new ApartmentView { Id = item.Id, Price = item.Price });
            }
            return tmp;

        }

       

        
    }
}
