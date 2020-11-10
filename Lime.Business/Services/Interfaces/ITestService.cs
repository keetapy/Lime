using Lime.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.Business.Services.Interfaces
{
    public interface ITestService
    {
        List<ApartmentView> GetData();
        //ApartmentView GetApartmentById(int id);
    }
}
