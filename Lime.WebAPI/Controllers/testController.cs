using Lime.Business.Services.Interfaces;
using Lime.DataAccess.Entities;
using Lime.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lime.WebAPI.Controllers
{
    public class testController: ITestService
    {
        private readonly ITestService _testService;
        public testController(ITestService testService)
        {
            _testService = testService;
        }
       /* [Route("test/GetApartmentById/{id:int}")]
        public ApartmentView GetApartmentById(int id)
        {
            return _testService.GetApartmentById(id);
        }
       */
        [Route("test/getdata")]
        public List<ApartmentView> GetData()
        {
            return _testService.GetData();
        }

        //[HttpGet("gettestdata")]
        //public object gettestdata()
        //{
        //    return testService.GetData();
        //}
    }
}
