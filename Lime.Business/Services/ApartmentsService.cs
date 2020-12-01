using Lime.Business.Services.Interfaces;
using Lime.DataAccess.Repository.Interfaces;
using Lime.ViewModels.ViewModels;
using Lime.ViewModels.Views;
using System;
using System.Collections.Generic;
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
        public async Task<List<GetApartmentDapperView>> SetApartments(List<SetApartmentsViewModel> setApartments)
        {
            var result = await _apartmentsRepository.Set(setApartments);
            List<GetApartmentDapperView> apartments = new List<GetApartmentDapperView>();
            foreach (var apartment in result)
            {
                apartments.Add(new GetApartmentDapperView
                {
                    Id = apartment.Id,
                    ApartmentAddressId = apartment.Id,
                    ApartmentTypeId = apartment.ApartmentTypeId,
                    FlatNumber = apartment.FlatNumber,
                    Price = apartment.Price,
                    ApartmentSquare = apartment.ApartmentSquare,
                    Photo = apartment.Photo,
                    InternetProviderId = apartment.InternetProviderId,
                    DealTypeId = apartment.DealTypeId
                });
            }
            return apartments;
        }
    }
}
