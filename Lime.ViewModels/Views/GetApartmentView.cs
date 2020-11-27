using Lime.ViewModels.ViewItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.ViewModels.Views
{
    public class GetApartmentView
    {
        public int ApartmentId { get; set; }
        public ApartmentAddressViewItem ApartmentAddress { get; set; }
        public string FlatNumber { get; set; }
        public string ApartmentType { get; set; }
        public double Price { get; set; }
        public int ApartmentSquare { get; set; }
        public InternetProviderViewItem InternetProvider { get; set; }
        public string DealType { get; set; }
    }
}
