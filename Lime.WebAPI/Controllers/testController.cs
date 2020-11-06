using Lime.Business.Services.Interfaces;
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
        [Route("test/getdata")]
        public object GetData()
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
