using Lime.Business.Services.Interfaces;
using Lime.DataAccess.Entities;
using Lime.DataAccess.Repository.Interfaces;
using Lime.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.Business.Services
{
    class TestService: ITestService
    {
        private readonly IRepository _repository;
        public TestService(IRepository repository)
        {
            _repository = repository;
        }

        //public ApartmentView GetApartmentById(int id)
        //{
        //    return new ApartmentView { Id = id, Price = _repository.GetApartmentById(id).Price };
        //}

        public List<ApartmentView> GetData()
        {
            List<ApartmentView> tmp = new List<ApartmentView>();
            foreach (Apartment item in _repository.GetData().Result)
            {
                tmp.Add(new ApartmentView { Id = item.Id, Price = item.Price });
            }
            return tmp;

        }
        // public void testMethod(ApartmentView apartment)
        //{
        //    _repository.SetTest(apartment.id);
        //}

    }
}
