using Lime.Business.Services.Interfaces;
using Lime.DataAccess.DbContext;
using Lime.DataAccess.Entities;
using Lime.DataAccess.Repository;
using Lime.DataAccess.Repository.Interfaces;
using Lime.ViewModels.ViewItems;
using Lime.ViewModels.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime.Business.Services
{
    public class ApartmentsService : IApartmentsService
    {
        private readonly IApartmentRepository _apartmentsRepository;
        public ApartmentsService(IApartmentRepository repository)
        {
            _apartmentsRepository = repository;
        }
        public async Task<List<GetApartmentDapperView>> GetApartments()
        {
            List<GetApartmentDapperView> apartments = new List<GetApartmentDapperView>();
            foreach (var apartment in await _apartmentsRepository.Get())
            {
                apartments.Add(new GetApartmentDapperView
                {
                    Id=apartment.Id,
                    ApartmentAddressId=apartment.Id,
                    ApartmentTypeId=apartment.ApartmentTypeId,
                    FlatNumber=apartment.FlatNumber,
                    Price=apartment.Price,
                    ApartmentSquare=apartment.ApartmentSquare,
                    Photo=apartment.Photo,
                    InternetProviderId=apartment.InternetProviderId,
                    DealTypeId=apartment.DealTypeId
                });
            }
            return apartments;
        }
        public async Task<GetApartmentView> GetApartmentById(int id)
        {
            var result = await _apartmentsRepository.GetById(id);
            if (result == null)
                throw new ApplicationException("Apartment not found.");
            return result;
        }
    }
}
