using Lime.ViewModels.ViewModels;
using Lime.ViewModels.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lime.Business.Services.Interfaces
{
    public interface IApartmentsService
    {
        //Task<List<GetApartmentView>> GetApartments();
        Task<List<GetApartmentDapperView>> GetApartments();
        Task<GetApartmentView> GetApartmentById(int id);
        Task<List<GetApartmentDapperView>> SetApartments(List<SetApartmentsViewModel> setApartments);
    }
}
