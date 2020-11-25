using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.ViewModels.Views
{
    public class GetApartmentDapperView
    {
        public int Id { get; set; }
        public int? ApartmentTypeId { get; set; }
        public int ApartmentAddressId { get; set; }
        public string FlatNumber { get; set; }
        public double Price { get; set; }
        public int ApartmentSquare { get; set; }
        public string Photo { get; set; }
        public int? InternetProviderId { get; set; }
        public int? DealTypeId { get; set; }
    }
}
