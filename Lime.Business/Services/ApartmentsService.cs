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
        //private readonly UsersDbContext _context;
        private readonly IApartmentRepository _apartmentsRepository;
        //UsersDbContext context
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
            #region GetWithContext
            //List<GetApartmentView> apartments = new List<GetApartmentView>();
            //foreach (var apartment in _context.Apartments.ToList())
            //{
            //    apartment.InternetProvider = _context.InternetProviders.FirstOrDefault(x => x.Id == apartment.InternetProviderId);
            //    apartment.ApartmentAddress = _context.ApartmentAddresses.FirstOrDefault(x => x.Id == apartment.Id);
            //    GetApartmentView newView = new GetApartmentView
            //    {
            //        Price = apartment.Price,
            //        DealType = _context.DealTypes.FirstOrDefault(x => x.Id == apartment.DealTypeId).Name,
            //        ApartmentAddress = new ApartmentAddressViewItem
            //        {
            //            PostalCode = apartment.ApartmentAddress.PostalCode,
            //            City = apartment.ApartmentAddress.City,
            //            Country = apartment.ApartmentAddress.Country,
            //            Street = apartment.ApartmentAddress.Street,
            //            HouseNumber = apartment.ApartmentAddress.HouseNumber
            //        },
            //        FlatNumber = apartment.FlatNumber,
            //        ApartmentType = _context.ApartmentTypes.FirstOrDefault(x => x.Id == apartment.ApartmentTypeId).Name,
            //        ApartmentSquare = apartment.ApartmentSquare,
            //        InternetProvider = new InternetProviderViewItem
            //        {
            //            Id = apartment.InternetProvider.Id,
            //            Name = apartment.InternetProvider.Name,
            //            Phone = apartment.InternetProvider.Phone,
            //            Email = apartment.InternetProvider.Email
            //        }
            //    };

            //    apartments.Add(newView);
            //}

            #endregion
            return apartments;
            //throw new NotImplementedException();
        }
    }
}
