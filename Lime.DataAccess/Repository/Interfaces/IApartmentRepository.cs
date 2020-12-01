﻿using Lime.DataAccess.Entities;
using Lime.ViewModels.ViewModels;
using Lime.ViewModels.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository.Interfaces
{
    public interface IApartmentRepository
    {
        Task<List<Apartment>> Get();
        Task<GetApartmentView> GetById(int id);
        Task<List<Apartment>> Set(List<SetApartmentsViewModel> setApartments);
    }
}
