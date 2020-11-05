using Lime.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lime.WebAPI.Controllers
{
    public class testController
    {
        ITestService testService;
        public testController(ITestService testService)
        {
            this.testService = testService;
        }
        public object gettestdata()
        {
            return testService.GetData();
        }
    }
}
